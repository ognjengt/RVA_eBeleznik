using Common.Interfaces;
using Server.Access;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common.Data;

namespace Server
{
    class Program
    {
        private static ServiceHost serviceHostKorisnik;
        private static ServiceHost serviceHostBeleska;

        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin")) + "Database";
            Console.WriteLine(path);
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            //UserDB.Instance.AddUser(new User()
            //{
            //    Username = "ognjen",
            //    Password = "123",
            //    Ime = "Ognjen",
            //    Prezime = "Gatalo",
            //    Admin = false,
            //    Grupe = ""
            //});

            serviceHostKorisnik = new ServiceHost(typeof(UserDB));
            var binding1 = new NetTcpBinding();
            binding1.TransactionFlow = true;
            serviceHostKorisnik.AddServiceEndpoint(typeof(IUserDB), binding1, new Uri("net.tcp://localhost:50000/UserConnection"));
            serviceHostKorisnik.Open();

            serviceHostBeleska = new ServiceHost(typeof(BeleskeDB));
            var binding2 = new NetTcpBinding();
            binding2.TransactionFlow = true;
            serviceHostBeleska.AddServiceEndpoint(typeof(IBeleskeDB), binding2, new Uri("net.tcp://localhost:50001/BeleskeConnection"));
            serviceHostBeleska.Open();

            Console.ReadKey();
        }
    }
}
