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
    public class StateRepository : Repository<State>, IStateRepository
    {
        private readonly ManageProfileContext _db;
        public StateRepository(ManageProfileContext db) : base(db)
        {
            _db = db;
        }

        public void Update(State obj)
        {
            _db.States.Update(obj);
        }
        public IEnumerable<State> GetStateList()
        {
            var allStates = _db.States.FromSqlRaw("EXECUTE GetStateList").ToList();
            foreach (var state in allStates)
            {
                _db.Entry(state).Reference(s => s.Country).Load();
            }
            return allStates;
        }

        public void AddState(State state)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@StateName", state.StateName),
                new SqlParameter("@CountryId", state.CountryId)
            };

            _db.Database.ExecuteSqlRaw("EXEC AddState @StateName, @CountryId", parameters);
        }

        public void UpdateState(State state)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@StateId", state.StateId),
            new SqlParameter("@StateName", state.StateName),
                new SqlParameter("@CountryId", state.CountryId)
            };

            _db.Database.ExecuteSqlRaw("EXEC UpdateState @StateId, @StateName, @CountryId", parameters);
        }

        public void DeleteState(State obj)
        {
            _db.Database.ExecuteSqlRaw("EXEC DeleteState {0}", obj.StateId);
        }

       
    }
}
