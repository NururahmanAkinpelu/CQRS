using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User.Queries.GetAll
{
    public class GetAllUsersRequestHandler : IRequestHandler<GetAllUsersRequest, GetAllUsersRequestRespnse>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersRequestHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<GetAllUsersRequestRespnse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var getusers = await _userRepository.GetAllUsers();
            if (getusers.Count == 0) 
            {
                return new GetAllUsersRequestRespnse
                {
                    Message = "No user registered",
                    Status = false
                };
            }

            var users = getusers.Select(u => new Users
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            }).ToList();

            return new GetAllUsersRequestRespnse
            {
                Users = users,
                Message = "List of Users",
                Status = true
            };
        }
    }
}
