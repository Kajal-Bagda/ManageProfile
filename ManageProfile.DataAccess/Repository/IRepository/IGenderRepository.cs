using ManageProfile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProfile.DataAccess.Repository.IRepository
{
    public interface IGenderRepository : IRepository<Gender>
    {
        void Update(Gender obj);
    }
}
