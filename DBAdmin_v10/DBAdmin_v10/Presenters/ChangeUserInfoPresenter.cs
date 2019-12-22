using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdmin_v10
{
    public class ChangeUserInfoPresenter
    {
        IChangeInfoScreen _changeInfoScreen;
        IDB_Model _model;

        public ChangeUserInfoPresenter(IChangeInfoScreen changeInfoScreen, IDB_Model model)
        {
            _changeInfoScreen = changeInfoScreen;
            _model = model;
        }

        public Users CreateUserFromChangeInfoScreen()
        {
            Users user = new Users();
            user.id = Convert.ToInt32(_changeInfoScreen.IDText);
            user.login = _changeInfoScreen.LoginText;
            user.password = _changeInfoScreen.PasswordText;
            user.surname = _changeInfoScreen.SurnameText;
            user.name = _changeInfoScreen.NameText;
            user.patronymic = _changeInfoScreen.PatronymicText;
            user.position = _changeInfoScreen.PositionText;
            return user;
        }

        public bool ChangeUserInfoInDB()
        {
            Users user = CreateUserFromChangeInfoScreen();
            return _model.Update(user);
        }
    }
}
