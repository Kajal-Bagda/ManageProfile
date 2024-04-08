using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProfile.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICountryRepository Country { get; }
        IStateRepository State { get; }
        ICityRepository City { get; }
        IUserRepository User { get; }
        IGenderRepository Gender { get; }
        IHobbyRepository Hobby { get; }
        void Save();
    }
}
