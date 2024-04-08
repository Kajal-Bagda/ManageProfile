using ManageProfile.Models;
using ManageProfile.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProfile.DataAccess.Repository.IRepository
{
    public interface IHobbyRepository : IRepository<Hobby>
    {
        void Update(Hobby obj);
    }
}
