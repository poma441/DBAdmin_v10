﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdmin_v10
{
    public class InsertUserPresenter
    {
        IInsertScreen _insertScreen;
        IDB_Model _model;

        public InsertUserPresenter(IInsertScreen insertScreen, IDB_Model model)
        {
            _insertScreen = insertScreen;
            _model = model;
        }

        public Users CreateUserFromInsertScreen()
        {
            Users user = new Users();
            user.login = _insertScreen.LoginText;
            user.password = _insertScreen.PasswordText;
            user.surname = _insertScreen.SurnameText;
            user.name = _insertScreen.NameText;
            user.patronymic = _insertScreen.PatronymicText;
            user.position = _insertScreen.PositionText;
            return user;
        }

        public bool InsertUserToDB()
        {
            Users user = CreateUserFromInsertScreen();
            return _model.Insert(user);
        }
    }
}
