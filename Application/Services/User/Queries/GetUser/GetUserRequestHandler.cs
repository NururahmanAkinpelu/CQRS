using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User.Queries.GetUser
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, GetUserRequestResponse>
    {
        private readonly IUserRepository _userRepository;
        public GetUserRequestHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserRequestResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var getuser = await _userRepository.GetUser(request.Id);
            if (getuser == null)
            {
                return new GetUserRequestResponse
                {
                    Message = "User not found",
                    Status = false
                };
            }

            var user = new Users
            {
                Id = getuser.Id,
                FirstName = getuser.FirstName,
                LastName = getuser.LastName,
                Email = getuser.Email,
            };

            return new GetUserRequestResponse
            {
                User = user,
                Message = "User found",
                Status = true
            };
        }
    }
}
