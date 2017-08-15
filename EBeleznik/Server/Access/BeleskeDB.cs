using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Data;
using Common;

namespace Server.Access
{
    public class BeleskeDB : IBeleskeDB
    {
        private static IBeleskeDB myDB;

        public static IBeleskeDB Instance
        {
            get
            {
                if (myDB == null)
                    myDB = new BeleskeDB();

                return myDB;
            }
            set
            {
                if (myDB == null)
                    myDB = value;
            }
        }

        public bool DodajBelesku(Beleska newBeleska)
        {
            using (var access = new AccessDB())
            {
                var beleske = access.Beleske;

                access.Beleske.Add(newBeleska);
                int uspesno = access.SaveChanges();

                if (uspesno > 0)
                {
                    return true;
                }
                else return false;
                
            }
        }

        public Beleska GetBeleskaById(int id)
        {
            using (var access = new AccessDB())
            {
                var beleske = access.Beleske;

                foreach (var beleska in beleske)
                {
                    if (beleska.Id == id)
                    {
                        return beleska;
                    }
                }
            }
            return null;
        }

        public List<Beleska> GetBeleskeByUser(User user)
        {
            List<Beleska> listaZaVracanje = new List<Beleska>();
            string[] korisnickeGrupe = user.Grupe.Split(';');
            using (var access = new AccessDB())
            {
                var beleske = access.Beleske;

                foreach (var beleska in beleske)
                {
                    foreach (string grupa in korisnickeGrupe)
                    {
                        if (beleska.Grupe.Contains(grupa))
                        {
                            listaZaVracanje.Add(beleska);
                            break;
                        }
                    }
                }

            }

            return listaZaVracanje;
        }

        public bool IzmeniBelesku(Beleska b)
        {
            // TODO
            return true;
            //using (var access = new AccessDB())
            //{
            //    var beleske = access.Beleske;
            //    foreach (var beleska in beleske)
            //    {
            //        if (beleska.Id == b.Id)
            //        {
            //            access.Beleske.Attach(b);
            //            access.Entry(b).Property(x => x.Naslov).IsModified = true;
            //            access.Entry(b).Property(x => x.Sadrzaj).IsModified = true;
            //            access.Entry(b).Property(x => x.Grupe).IsModified = true;
            //            int success = access.SaveChanges();
            //            if (success > 0)
            //            {
            //                return true;
            //            }
            //            return false;
            //        }
            //    }
            //}
            //return true;
        }
    }
}
