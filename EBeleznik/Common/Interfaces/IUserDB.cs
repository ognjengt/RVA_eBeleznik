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
    public interface IUserDB
    {
        [OperationContract]
        User UlogujKorisnika(string username, string password);

        [OperationContract]
        bool AddUser(User newUser);
    }
}
