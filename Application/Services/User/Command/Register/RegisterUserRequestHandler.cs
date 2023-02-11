using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User.Command.Register
{
    public class RegisterUserRequestHandler : IRequestHandler<RegisterUserRequest, UserRequestResponse>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserRequestHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }


        public async Task<UserRequestResponse> Handle(RegisterUserRequest userRequest, CancellationToken cancellationToken)
        {
            var getUser = await _userRepository.GetUserByEmail(userRequest.Email);
            if (getUser != null)
            {
                return new UserRequestResponse
                {
                    Message = "Users already exist",
                    Status = false
                };
            }

            var user = new Users
            {
                FirstName = userRequest.FirsName,
                LastName = userRequest.LastName,
                Email = userRequest.Email,
                Password = userRequest.Password,
            };
            await _userRepository.CreateUser(user);

            return new UserRequestResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Message = "User Created",
                Status = true
            };
        }
    }
}
