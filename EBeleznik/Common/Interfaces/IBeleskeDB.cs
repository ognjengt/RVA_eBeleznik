﻿using Common.Data;
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
        bool DodajBelesku(Beleska newBeleska);

        [OperationContract]
        List<Beleska> GetBeleskeByUser(User user);
    }
}