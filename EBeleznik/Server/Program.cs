using Common.Interfaces;
using Server.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        private static ServiceHost serviceHost;

        static void Main(string[] args)
        {
            serviceHost = new ServiceHost(typeof(UserDB));
            var binding1 = new NetTcpBinding();
            binding1.TransactionFlow = true;
            serviceHost.AddServiceEndpoint(typeof(IUserDB), binding1, new Uri("net.tcp://localhost:50000/UserConnection"));
            serviceHost.Open();
            Console.ReadKey();
        }
    }
}
