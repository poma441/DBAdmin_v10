using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdmin_v10
{
    public interface IDB_Model
    {
        string GetMd5Code(string oldpasswd);
        void DataChange(Users olduser, Users newuser);
        bool Insert(Users olduser);
        bool Update(Users olduser);
        void Delete(Users olduser);
    }
}
