using ManageProfile.DataAccess.Data;
using ManageProfile.DataAccess.Repository.IRepository;
using ManageProfile.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProfile.DataAccess.Repository
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly ManageProfileContext _db;
        public CountryRepository(ManageProfileContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Country obj)
        {
            _db.Countries.Update(obj);
        }
        public IEnumerable<Country> GetAllCountry()
        {
            return  _db.Countries.FromSqlRaw("EXEC GetAllCountries").ToList();
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            return await _db.Countries.FromSqlRaw("EXEC GetCountryByIds @CountryId", new SqlParameter("@CountryId", countryId)).FirstOrDefaultAsync();
        }

        public async Task AddCountry(string countryName)
        {
            await _db.Database.ExecuteSqlRawAsync("EXEC AddCountry @CountryName", new SqlParameter("@CountryName", countryName));
        }

        public async Task EditCountry(Country country)
        {
            // Assuming EditCountry method updates a country using a stored procedure
            await _db.Database.ExecuteSqlRawAsync("EXEC EditCountry @CountryId, @CountryName",
                new SqlParameter("@CountryId", country.CountryId),
                new SqlParameter("@CountryName", country.CountryName));
        }
        public void DeleteCountry(Country obj)
        {
            _db.Database.ExecuteSqlRaw("EXEC DeleteCountry {0}", obj.CountryId);
        }       


    }
}

