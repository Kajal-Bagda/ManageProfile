using ManageProfile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProfile.DataAccess.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User obj);
        IEnumerable<User> GetUserList();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
