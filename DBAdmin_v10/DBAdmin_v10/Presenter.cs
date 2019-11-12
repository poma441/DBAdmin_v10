using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdmin_v10
{
    public class Presenter
    {
        IAppView _appView;
        IDB_Model _dB_Model;

        public Presenter(IAppView appView, IDB_Model dB_Model)
        {
            _appView = appView;
            _dB_Model = dB_Model;
        }

        public void CreateUserFromInsertView()
        {

        }

        public void CreateUserFromDeleteView()
        {

        }

        public void CreateUserFromChangeInfoView()
        {

        }
    }
}
