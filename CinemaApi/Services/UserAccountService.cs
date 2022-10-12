using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Entities;
using CinemaApi.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CinemaApi.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly CinemaDbContext _context;
        private readonly IPasswordHasher<User> _hasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public UserAccountService(CinemaDbContext context, IPasswordHasher<User> hasher, AuthenticationSettings authenticationSettings)
        {
            _context = context;
            _hasher = hasher;
            _authenticationSettings = authenticationSettings;
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var user = new User()
            {
                Email = dto.Email,
                Name = dto.Name,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                RoleId = dto.RoleId

            };

            var hashedPassword = _hasher.HashPassword(user, dto.Password);
            user.PasswordHash = hashedPassword;

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public string LoginUser(LoginUserDto dto)
        {
            var user = _context.Users
                .Include(c => c.Role)
                .FirstOrDefault(c => c.Email == dto.Email);

            if (user is null) throw new BadRequestException("Invalid email or password");

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed) throw new BadRequestException("Invalid email or password");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{user.Name} {user.LastName}"),
                new Claim(ClaimTypes.Role,$"{user.Role.Name}"),
            };

            if (string.IsNullOrEmpty(user.DateOfBirth.Value.ToString("yyyy-MM-dd")))
            {
                claims.Add(new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.Value.ToString("yyyy-MM-dd")));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: credential);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

    }
}
