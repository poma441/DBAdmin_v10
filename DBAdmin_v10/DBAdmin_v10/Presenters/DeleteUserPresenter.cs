using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdmin_v10
{
    public class DeleteUserPresenter
    {
        public bool DeleteUserFromDB(List<int> id)
        {
            return DB_Model.Delete(id);
        }
    }
}
