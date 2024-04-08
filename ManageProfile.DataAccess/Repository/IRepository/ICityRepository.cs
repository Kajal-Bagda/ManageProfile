using ManageProfile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProfile.DataAccess.Repository.IRepository
{
    public interface ICityRepository : IRepository<City>
    {
        IEnumerable<City> GetCityList();
        void AddCity(City city);
        void UpdateCity(City city);
        void DeleteCity(City obj);
        void Update(City obj);
    }
}
