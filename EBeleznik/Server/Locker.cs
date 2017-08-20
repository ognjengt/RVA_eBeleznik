using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Locker
    {
        public static readonly object lockUser = new object();
        public static readonly object lockBeleska = new object();
    }
}
