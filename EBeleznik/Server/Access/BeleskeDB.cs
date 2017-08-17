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

        public Beleska DodajBelesku(Beleska newBeleska)
        {
            using (var access = new AccessDB())
            {
                var beleske = access.Beleske;

                access.Beleske.Add(newBeleska);
                int uspesno = access.SaveChanges();

                List<Beleska> lista = beleske.ToList();
                if (uspesno > 0)
                {
                    return lista[lista.Count - 1];
                }
                else return null;
                
            }
        }

        public List<Beleska> GetAllBeleske()
        {
            using (var access = new AccessDB())
            {
                var beleske = access.Beleske;
                return (List<Beleska>)beleske.ToList();
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
            using (var access = new AccessDB())
            {
                Beleska bel = access.Beleske.First(x => x.Id == b.Id);
                bel.Naslov = b.Naslov;
                bel.Sadrzaj = b.Sadrzaj;
                bel.Grupe = b.Grupe;
                int i = access.SaveChanges();

                return (i > 0 ? true : false);
            }
        }

        public bool ObrisiBelesku(int id)
        {
            using (var access = new AccessDB())
            {
                var beleske = access.Beleske;

                foreach (var item in beleske)
                {
                    if (item.Id == id)
                    {
                        access.Beleske.Remove(item);
                        break;
                    }
                }

                int i = access.SaveChanges();
                if (i > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
