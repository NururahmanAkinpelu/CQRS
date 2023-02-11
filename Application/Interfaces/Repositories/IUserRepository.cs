using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<Users> CreateUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task DeleteUser(Users user);
        Task<ICollection<Users>> GetAllUsers();
        Task<Users> GetUser(int id);
        Task<Users> GetUserByEmail(string email);



    }
}
