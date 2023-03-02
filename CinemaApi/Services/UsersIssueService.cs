using AutoMapper;
using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Entities;
using CinemaApi.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Services
{
    public class UsersIssueService : IUsersIssueService
    {
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;

        public UsersIssueService(CinemaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<UsersIssues> GetAll()
        {
            var issues = _context.UsersIssues.ToList();

            if (!issues.Any()) throw new NotFoundException("There are no user issues at that moment!");

            return issues;
        }

        public UsersIssues GetById(int issueId)
        {
            var issue = _context.UsersIssues.FirstOrDefault(c => c.Id == issueId);

            if (issue is null) throw new NotFoundException("Specific user issue not found");

            return issue;
        }
        public void DeleteAll()
        {
            var deleteIssues = _context.UsersIssues.ToList();

            if (!deleteIssues.Any()) throw new NotFoundException("There are no user issues to delete at that moment!");

            _context.UsersIssues.RemoveRange(deleteIssues);
            _context.SaveChanges();
        }
        public void DeleteById(int issueId)
        {
            var deleteIssue = _context.UsersIssues.FirstOrDefault(c => c.Id == issueId);

            if (deleteIssue is null) throw new NotFoundException("The specific issue you want to delete does not exist");

            _context.UsersIssues.Remove(deleteIssue);
            _context.SaveChanges();
        }

        public void Create(CreateUserIssueDto dto)
        {
            var createIssue = _mapper.Map<UsersIssues>(dto);
            if (createIssue != null)
            {
                _context.UsersIssues.Add(createIssue);
                _context.SaveChanges();
            }
        }
    }
}
