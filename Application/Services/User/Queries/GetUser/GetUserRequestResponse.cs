using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User.Queries.GetUser
{
    public class GetUserRequestResponse
    {
        public Users? User { get; set; }
        public string? Message { get; set; }
        public bool Status { get; set; }
    }
}
