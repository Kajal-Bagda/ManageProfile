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
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly ManageProfileContext _db;
        public CityRepository(ManageProfileContext db) : base(db)
        {
            _db = db;
        }

        public void Update(City obj)
        {
            _db.Cities.Update(obj);
        }
        public IEnumerable<City> GetCityList()
        {
            var allCities = _db.Cities.FromSqlRaw("EXECUTE GetCityList").ToList();
            foreach (var city in allCities)
            {
                _db.Entry(city).Reference(s => s.Country).Load();
                _db.Entry(city).Reference(s => s.State).Load();
            }
            return allCities;
        }
        public void AddCity(City city)
        {
            _db.Database.ExecuteSqlRaw("EXEC AddCity {0},{1},{2}", city.CityName,city.StateId,city.CountryId);
        }

        public void UpdateCity(City city)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@CityId", city.CityId),
        new SqlParameter("@CityName", city.CityName),
        new SqlParameter("@StateId", city.StateId),
        new SqlParameter("@CountryId", city.CountryId)

            };
            _db.Database.ExecuteSqlRaw("EXEC UpdateCity @CityId, @CityName, @StateId,@CountryId", parameters);
        }
        public void DeleteCity(City obj)
        {
            _db.Database.ExecuteSqlRaw("EXEC DeleteCity {0}", obj.CityId);

        }

    }
}
