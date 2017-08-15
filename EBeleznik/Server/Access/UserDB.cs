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
            using(var access = new AccessDB())
            {
                var users = access.Users;

                foreach (var user in users)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        return user;
                    }
                }
            }
            return null;
        }

        public bool AddUser(User newUser)
        {
            // provera da li taj user vec postoji
            using (var access = new AccessDB())
            {
                var users = access.Users;
                foreach (var user in users)
                {
                    if (user.Username == newUser.Username)
                    {
                        return false;
                    }
                }
                access.Users.Add(newUser);
                int uspesno = access.SaveChanges();

                if (uspesno > 0)
                {
                    return true;
                }
                else return false;
            }
        }

        public bool UpdateUser(User u)
        {
            using (var access = new AccessDB())
            {
                User user = access.Users.First(x => x.Username == u.Username);
                user.Ime = u.Ime;
                user.Prezime = u.Prezime;
                int i = access.SaveChanges();

                return (i > 0 ? true : false);
            }
        }
    }
}
