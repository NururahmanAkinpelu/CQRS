using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User.Queries.Delete
{
    public class DeleteUserRequest : IRequest<DeleteUserRequestResponse>
    {
        public int Id { get; set; }
    }
}
