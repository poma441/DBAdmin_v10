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
        IInsertScreen _insertScreen;
        IDeleteScreen _deleteScreen;
        IChangeInfoScreen _changeInfoScreen;

        public Presenter(IAppView appView, IDB_Model dB_Model)
        {
            _appView = appView;
            _dB_Model = dB_Model;
        }

        public void CreateUserFromInsertScreen()
        {
            Users user = new Users();
            user.login = _insertScreen.Login();
            user.password = _insertScreen.Password();
            user.surname = _insertScreen.Surname();
            user.name = _insertScreen.Name();
            user.patronymic = _insertScreen.Patronymic();
            user.position = _insertScreen.Position();
        }

        public void CreateUserFromDeleteScreen()
        {

        }

        public void CreateUserFromChangeInfoScreen()
        {
            Users user = new Users();
            user.login = _changeInfoScreen.Login();
            user.password = _changeInfoScreen.Password();
            user.surname = _changeInfoScreen.Surname();
            user.name = _changeInfoScreen.Name();
            user.patronymic = _changeInfoScreen.Patronymic();
            user.position = _changeInfoScreen.Position();
        }
    }
}
