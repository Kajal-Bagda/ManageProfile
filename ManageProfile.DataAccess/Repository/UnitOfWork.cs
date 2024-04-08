using ManageProfile.DataAccess.Data;
using ManageProfile.DataAccess.Repository.IRepository;
using ManageProfile.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProfile.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ManageProfileContext _db;
        public UnitOfWork(ManageProfileContext db)
        {
            _db = db;
            Country = new CountryRepository(_db);
            State = new StateRepository(_db);
            City = new CityRepository(_db);
            User = new UserRepository(_db);
            Gender = new GenderRepository(_db);
            Hobby = new HobbyRepository(_db);
        }
        public ICountryRepository Country { get; private set; }
        public IStateRepository State { get; private set; }
        public ICityRepository City { get; private set; }
        public IUserRepository User { get; private set; }
        public IGenderRepository Gender { get; private set; }
        public IHobbyRepository  Hobby { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
