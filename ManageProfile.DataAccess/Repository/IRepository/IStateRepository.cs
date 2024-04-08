using ManageProfile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProfile.DataAccess.Repository.IRepository
{
    public interface IStateRepository : IRepository<State>
    {
        IEnumerable<State> GetStateList();
        void AddState(State state);
        void UpdateState(State state);
        void DeleteState(State obj);
        void Update(State obj);
    }
}
