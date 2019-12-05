using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Linq;
using System.Linq;
using System.Collections.Generic;

namespace DBAdmin_Tests
{
    [TestClass]
    public class DB_ModelTests
    {
        DBAdmin_v10.IDB_Model model;
        DBAdmin_v10.Users user;
        DBAdmin_v10.Users userforupdate;
        DBAdmin_v10.DataClasses1DataContext db;
        List<int> idlist;

        [TestInitialize]
        public void SetUp()
        {
            model = new DBAdmin_v10.DB_Model();
            user = new DBAdmin_v10.Users();
            userforupdate = new DBAdmin_v10.Users();
            db = new DBAdmin_v10.DataClasses1DataContext();
            idlist = new List<int>();

            user.login = "ivanov123";
            user.password = "12345678";
            user.surname = "Ivanov";
            user.name = "Ivan";
            user.patronymic = "Ivanovich";
            user.position = "Manager";

            userforupdate.login = "petrov123";
            userforupdate.password = "12345678abcdef";
            userforupdate.surname = "Petrov";
            userforupdate.name = "Petr";
            userforupdate.patronymic = "Petrovich";
            userforupdate.position = "Boss";
        }

        [TestMethod]
        public void IDB_Model_InsertSuccess_Test()
        {
            Assert.IsTrue(model.Insert(user));

            var newuser = db.Users.Where(w => w.login == user.login).FirstOrDefault();
            idlist.Add(newuser.id);
            model.Delete(idlist);
        }

        [TestMethod]
        public void IDB_Model_InsertFailed_Test()
        {
            model.Insert(user);

            Assert.IsFalse(model.Insert(user));

            var newuser = db.Users.Where(w => w.login == user.login).FirstOrDefault();
            idlist.Add(newuser.id);
            model.Delete(idlist);
        }

        [TestMethod]
        public void IDB_Model_UpdateSuccess_Test()
        {
            model.Insert(user);

            var newuser = db.Users.Where(w => w.login == user.login).FirstOrDefault();

            newuser.login = "testlogin1";
            newuser.surname = "Petrov";
            newuser.name = "Petr";
            newuser.position = "Cleaner";

            Assert.IsTrue(model.Update(newuser));

            idlist.Add(newuser.id);
            model.Delete(idlist);
        }

        [TestMethod]
        public void IDB_Model_UpdateFialed_Test()
        {
            model.Insert(user);
            model.Insert(userforupdate);

            var newuser = db.Users.Where(w => w.login == user.login).FirstOrDefault();
            var newuserforupdate = db.Users.Where(w => w.login == userforupdate.login).FirstOrDefault();

            newuserforupdate.login = user.login;
            newuserforupdate.surname = "Sidorov";
            newuserforupdate.name = "Sidor";
            newuserforupdate.position = "Student";

            Assert.IsFalse(model.Update(newuserforupdate));

            idlist.Add(newuser.id);
            idlist.Add(newuserforupdate.id);
            model.Delete(idlist);
        }

        [TestMethod]
        public void IDB_Model_Delete_Test()
        {
            model.Insert(user);
            model.Insert(userforupdate);

            var newuser = db.Users.Where(w => w.login == user.login).FirstOrDefault();
            var newuserforupdate = db.Users.Where(w => w.login == userforupdate.login).FirstOrDefault();

            idlist.Add(newuser.id);
            idlist.Add(newuserforupdate.id);

            Assert.IsTrue(model.Delete(idlist));
        }
    }
}
