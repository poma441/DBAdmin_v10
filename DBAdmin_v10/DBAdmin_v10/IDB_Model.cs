﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdmin_v10
{
    public interface IDB_Model
    {
        bool Insert(Users olduser);
        bool Update(Users olduser);
        bool Delete(List<int> userlist);
    }
}
