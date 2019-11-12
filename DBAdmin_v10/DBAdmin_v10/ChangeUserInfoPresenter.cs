﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdmin_v10
{
    class ChangeUserInfoPresenter
    {
        IChangeInfoScreen _changeInfoScreen;



        public Users CreateUserFromChangeInfoScreen()
        {
            Users user = new Users();
            user.login = _changeInfoScreen.LoginText;
            user.password = _changeInfoScreen.PasswordText;
            user.surname = _changeInfoScreen.SurnameText;
            user.name = _changeInfoScreen.NameText;
            user.patronymic = _changeInfoScreen.PatronymicText;
            user.position = _changeInfoScreen.PositionText;
            return user;
        }
    }
}
