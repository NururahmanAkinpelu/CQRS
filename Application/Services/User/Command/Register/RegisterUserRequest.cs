using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.Services.User.Command.Register
{
    public class RegisterUserRequest : IRequest<UserRequestResponse>
    {
        public string FirsName { get; set;}
        public string LastName { get; set;}
        public string Email { get; set;}
        public string Password { get; set;}
    }
}
