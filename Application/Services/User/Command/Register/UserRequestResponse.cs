using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User.Command.Register
{
    public class UserRequestResponse
    {
/*        public int UserId { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string Email { get; set; }*/
        public Users? User { get; set; }
        public string? Message { get; set;}
        public bool Status { get; set;}


    }
}
