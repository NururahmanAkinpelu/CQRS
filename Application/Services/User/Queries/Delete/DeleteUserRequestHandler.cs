using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User.Queries.Delete
{
    internal class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, DeleteUserRequestResponse>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<DeleteUserRequestResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(request.Id);
            if (user == null)
            {
                return new DeleteUserRequestResponse
                {
                    Message = "User does not exist",
                    Success = false
                };
            }

            await _userRepository.DeleteUser(user);
            return new DeleteUserRequestResponse
            {
                Message = "User deleted",
                Success = true
            };
        }
    }
}
