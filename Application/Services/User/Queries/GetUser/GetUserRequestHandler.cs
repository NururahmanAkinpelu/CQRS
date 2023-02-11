using Application.Interfaces.Repositories;
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
            var user = await _userRepository.GetUser(request.Id);
            if (user == null)
            {
                return new GetUserRequestResponse
                {
                    Message = "User not found",
                    Status = false
                };
            }

            return new GetUserRequestResponse
            {
                Message = "User found",
                Status = true,
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }
    }
}
