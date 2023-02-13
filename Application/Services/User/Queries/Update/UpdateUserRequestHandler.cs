using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User.Queries.Update
{
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, UpdateUserRequestResponse>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserRequestHandler(IUserRepository userRepository) 
        {
            _userRepository= userRepository;
        }

        Task<UpdateUserRequestResponse> IRequestHandler<UpdateUserRequest, UpdateUserRequestResponse>.Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
