using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Globals
    {
        public static User currentUser = new User();
        public static List<Beleska> listaBeleskiUndo = new List<Beleska>();
        public static List<Beleska> listaBeleskiRedo = new List<Beleska>();
        //public static List<Beleska> listaObrisanih = new List<Beleska>();
    }
}
