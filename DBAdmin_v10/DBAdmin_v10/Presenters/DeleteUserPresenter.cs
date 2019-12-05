using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdmin_v10
{
    public class DeleteUserPresenter
    {
        IDB_Model _model;

        public DeleteUserPresenter(IDB_Model model)
        {
            _model = model;
        }

        public DeleteUserPresenter()
        {
            _model = new DB_Model();
        }

        public bool DeleteUserFromDB(List<int> id)
        {
            IDB_Model model = new DB_Model();
            return _model.Delete(id);
        }
    }
}
