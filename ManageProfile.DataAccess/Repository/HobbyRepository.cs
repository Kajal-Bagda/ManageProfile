using ManageProfile.DataAccess.Data;
using ManageProfile.DataAccess.Repository.IRepository;
using ManageProfile.Models;
using ManageProfile.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProfile.DataAccess.Repository
{
    public class HobbyRepository : Repository<Hobby>, IHobbyRepository
    {
        private readonly ManageProfileContext _db;
        public HobbyRepository(ManageProfileContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Hobby obj)
        {
            _db.Hobbies.Update(obj);
        }
    }
}
