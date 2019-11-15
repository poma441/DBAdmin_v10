using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdmin_v10
{
    public class DeleteUserPresenter
    {
        public void DeleteUserFromDB(int id)
        {
            DB_Model.Delete(id);
        }
    }
}
