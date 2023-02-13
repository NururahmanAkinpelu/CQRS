using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User.Queries.GetAll
{
    public class GetAllUsersRequestRespnse
    {
        public ICollection<Users>? Users { get; set; }
        public string? Message { get; set; }
        public bool Status { get; set; }

    }
}
