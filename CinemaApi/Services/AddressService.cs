using AutoMapper;
using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Dtos.Pagination;
using CinemaApi.Entities;
using CinemaApi.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CinemaApi.Services
{
    public class AddressService : IAddressService
    {
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;

        public AddressService(CinemaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public PagedResult<AddressDto> GetAll(int cinemaId, AddressQuery query)
        {
            var basicQuery = _context.Addresses
                .Include(c => c.Cinema)
                .Where(c=>c.CinemaId == cinemaId)
                .Where(c => query.SearchPhrase == null || (c.City.ToLower().Contains(query.SearchPhrase.ToLower()))
                || (c.Street.ToLower().Contains(query.SearchPhrase.ToLower())));
                

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Address, object>>>
                {
                    {nameof(Address.City), r=>r.City },
                    {nameof(Address.Street), r=>r.Street },
                };

                var selectedColumn = columnsSelector[query.SortBy];

                basicQuery = query.SortDirection == SortDirection.ASC
                    ? basicQuery.OrderBy(selectedColumn)
                    : basicQuery.OrderByDescending(selectedColumn);
            }

            var cinemaAddresses = basicQuery
                .Skip(query.PageItems * (query.PageNumber - 1))
                .Take(query.PageItems)
                .ToList();

            var totalCount = basicQuery.Count();

            var CinemaAddressesDtos = _mapper.Map<List<AddressDto>>(cinemaAddresses);

            var result = new PagedResult<AddressDto>(CinemaAddressesDtos, totalCount, query.PageItems, query.PageNumber);

            return result;
        }

        public AddressDto GetById(int cinemaId, int addressId)
        {
            var cinema = GetCinemaById(cinemaId);

            var AddressesDto = _mapper.Map<List<AddressDto>>(cinema.Addresses);

            var specificAddress = AddressesDto.FirstOrDefault(c => c.Id == addressId);

            if (specificAddress is null) throw new NotFoundException($"Specific address for this cinema({cinemaId}) cannot be found");

            return specificAddress;
        }

        public int Create(int cinemaId,CreateAddressDto dto)
        {
            var cinema = GetCinemaById(cinemaId);

            var newAddress = _mapper.Map<Address>(dto);

            newAddress.CinemaId = cinema.Id;

            if (newAddress is null) throw new BadRequestException("Something went wrong with creating new address");

            _context.Addresses.Add(newAddress);
            _context.SaveChanges();

            return newAddress.Id;

        }

        public void DeleteById(int cinemaId,int addressId)
        {
            var cinema = GetCinemaById(cinemaId);

            var addressToDelete = cinema.Addresses.FirstOrDefault(d => d.Id == addressId);

            if (addressToDelete is null) throw new NotFoundException($"Specific address({addressId}) not found");

            _context.Addresses.Remove(addressToDelete);
            _context.SaveChanges();
        }

        public void DeleteAll(int cinemaId)
        {
            var cinemaAddresses = GetCinemaById(cinemaId).Addresses.ToList();

            if(!cinemaAddresses.Any()) throw new NotFoundException($"Addresses for this cinema({cinemaId}) do not exist");

            _context.RemoveRange(cinemaAddresses);
            _context.SaveChanges();
        }

        public void Update(int cinemaId, int addressId, CreateAddressDto dto)
        {
            var cinema = GetCinemaById(cinemaId);

            var mapAddress = _mapper.Map<Address>(dto);

            var addressToUpdate = cinema.Addresses.FirstOrDefault(a => a.Id == addressId);

            if (addressToUpdate is null) throw new NotFoundException($"Specific address({addressId}) not found");

            addressToUpdate.City = dto.City;
            addressToUpdate.Street = dto.Street;
            addressToUpdate.PostalCode = dto.PostalCode;

            _context.SaveChanges();

        }

        private Cinema GetCinemaById(int cinemaId)
        {
            var cinema = _context.Cinemas
                .Include(a => a.Addresses)
                .FirstOrDefault(a => a.Id == cinemaId);

            if (cinema is null) throw new NotFoundException("Specific cinema not found");

            return cinema;
        }

        
    }
}
