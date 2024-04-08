using ManageProfile.DataAccess.Data;
using ManageProfile.DataAccess.Repository.IRepository;
using ManageProfile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProfile.DataAccess.Repository
{
    public class GenderRepository : Repository<Gender>, IGenderRepository
    {
        private readonly ManageProfileContext _db;
        public GenderRepository(ManageProfileContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Gender obj)
        {
            _db.Genders.Update(obj);
        }
    }
}
