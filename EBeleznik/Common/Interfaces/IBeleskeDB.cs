using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    [ServiceContract]
    public interface IBeleskeDB
    {
        [OperationContract]
        Beleska DodajBelesku(Beleska newBeleska);

        [OperationContract]
        List<Beleska> GetBeleskeByUser(User user);

        [OperationContract]
        Beleska GetBeleskaById(int id);

        [OperationContract]
        bool IzmeniBelesku(Beleska b, string userType);

        [OperationContract]
        bool ObrisiBelesku(int id);

        [OperationContract]
        List<Beleska> GetAllBeleske();
    }
}
