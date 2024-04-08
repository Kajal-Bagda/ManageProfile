using ManageProfile.DataAccess.Data;
using ManageProfile.DataAccess.Repository.IRepository;
using ManageProfile.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProfile.DataAccess.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ManageProfileContext _db;
        public UserRepository(ManageProfileContext db) : base(db)
        {
            _db = db;
        }

        public void Update(User obj)
        {
            _db.Users.Update(obj);
        }
        public IEnumerable<User> GetUserList()
        {
            var allUsers = _db.Users.FromSqlRaw("EXECUTE GetUserList").ToList();
            foreach (var user in allUsers)
            {
                _db.Entry(user).Reference(s => s.Country).Load();
                _db.Entry(user).Reference(s => s.State).Load();
                _db.Entry(user).Reference(s => s.City).Load();
                _db.Entry(user).Reference(s => s.Gender).Load();
            }
            return allUsers;
        }
        public void AddUser(User user)
        {
            _db.Database.ExecuteSqlRaw("EXEC AddUser {0},{1},{2},{3},{4},{5},{6},{7},{8}", user.FirstName, user.LastName, user.Address,user.GenderId,user.CountryId,user.StateId,user.CityId,user.ImageUrl,user.Hobby);
        }
        

        public void UpdateUser(User user)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@UserId", user.UserId),
                new SqlParameter("@FirstName", user.FirstName),
        new SqlParameter("@LastName", user.LastName),
        new SqlParameter("@Addess", user.Address),
        new SqlParameter("@GenderId", user.GenderId),

        new SqlParameter("@CityId", user.CityId),
        new SqlParameter("@StateId", user.StateId),
        new SqlParameter("@CountryId", user.CountryId),
        new SqlParameter("@ImageUrl", user.ImageUrl),
        new SqlParameter("@Hobby", user.Hobby)

            };
            _db.Database.ExecuteSqlRaw("EXEC UpdateUser @UserId, @FirstName,@LastName,@Addess,@GenderId,@CityId, @StateId,@CountryId,@ImageUrl,@Hobby", parameters);
        }
        public void DeleteUser(User obj)
        {
            _db.Database.ExecuteSqlRaw("EXEC DeleteUser {0}", obj.UserId);

        }

    }
}
