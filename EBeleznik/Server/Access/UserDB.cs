using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Data;

namespace Server.Access
{
    public class UserDB : IUserDB
    {

        private static IUserDB myDB;

        public static IUserDB Instance
        {
            get
            {
                if (myDB == null)
                    myDB = new UserDB();

                return myDB;
            }
            set
            {
                if (myDB == null)
                    myDB = value;
            }
        }

        public User UlogujKorisnika(string username, string password)
        {
            string user = username;
            string pass = password;
            using (var access = new AccessDB())
            {
                var query = from b in access.Users
                            where b.Username == user
                            select b;

                if (query.Any())
                {
                    query = from b in access.Users
                            where b.Password == pass
                            select b;

                    if (query.Any())
                    {
                        Console.WriteLine("Korisnik " + user + " je pronadjen");
                        return new User(username,password);
                    }
                }

                Console.WriteLine("Korisnik " + user + " nije pronadjen");
                return null;
            }
        }
    }
}
