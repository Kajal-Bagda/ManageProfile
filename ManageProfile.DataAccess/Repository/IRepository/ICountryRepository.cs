using ManageProfile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProfile.DataAccess.Repository.IRepository
{
    public interface ICountryRepository : IRepository<Country>
    {
        void Update(Country obj);
        IEnumerable<Country> GetAllCountry();
        Task AddCountry(string countryName);
        Task EditCountry(Country country);
        void DeleteCountry(Country obj);    
            
    }
}
