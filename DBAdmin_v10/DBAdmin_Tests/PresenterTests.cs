using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DBAdmin_Tests
{
    [TestClass]
    public class InsertUserPresenterTests
    {
        [TestMethod]
        public void Test_InsertUserPresenterInsertToDB()
        {
            //setup
            var mock_DB = new Mock<DBAdmin_v10.IDB_Model>();
            var mock_Screen = new Mock<DBAdmin_v10.IInsertScreen>();
            var presenter = new DBAdmin_v10.InsertUserPresenter(mock_Screen.Object, mock_DB.Object);

            //action
            presenter.InsertUserToDB();

            //assert
            mock_DB.Verify(pr => pr.Insert(It.IsAny<DBAdmin_v10.Users>()));
        }

        [TestMethod]
        public void Test_InsertUserPresenterGetUser()
        {
            var mock_DB = new Mock<DBAdmin_v10.IDB_Model>();
            var mock_Screen = new Mock<DBAdmin_v10.IInsertScreen>();
            var presenter = new DBAdmin_v10.InsertUserPresenter(mock_Screen.Object, mock_DB.Object);

            presenter.CreateUserFromInsertScreen();

            mock_Screen.Verify(pr => pr.LoginText);
            mock_Screen.Verify(pr => pr.NameText);
            mock_Screen.Verify(pr => pr.PatronymicText);
            mock_Screen.Verify(pr => pr.PositionText);
            mock_Screen.Verify(pr => pr.SurnameText);
        }
    }

    [TestClass]
    public class DeleteUserPresenterTests
    {
        [TestMethod]
        public void Test_DeleteUserPresenterDelete()
        {
            var mock_DB = new Mock<DBAdmin_v10.IDB_Model>();
            var presenter = new DBAdmin_v10.DeleteUserPresenter(mock_DB.Object);
            List<int> list = new List<int>();
            list.Add(20);

            presenter.DeleteUserFromDB(list);

            mock_DB.Verify(pr => pr.Delete(list));
        }
    }

    [TestClass]
    public class ChangeUserPresenterTests
    {
        [TestMethod]
        public void Test_ChangeUserPresenterUpdate()
        {
            var mock_DB = new Mock<DBAdmin_v10.IDB_Model>();
            var mock_Screen = new Mock<DBAdmin_v10.IChangeInfoScreen>();
            var presenter = new DBAdmin_v10.ChangeUserInfoPresenter(mock_Screen.Object, mock_DB.Object);

            presenter.ChangeUserInfoInDB();

            mock_DB.Verify(pr => pr.Update(It.IsAny<DBAdmin_v10.Users>()));
        }

        [TestMethod]
        public void Test_ChangeUserPresenterGetUser()
        {
            var mock_DB = new Mock<DBAdmin_v10.IDB_Model>();
            var mock_Screen = new Mock<DBAdmin_v10.IChangeInfoScreen>();
            var presenter = new DBAdmin_v10.ChangeUserInfoPresenter(mock_Screen.Object, mock_DB.Object);

            presenter.CreateUserFromChangeInfoScreen();

            mock_Screen.Verify(pr => pr.LoginText);
            mock_Screen.Verify(pr => pr.NameText);
            mock_Screen.Verify(pr => pr.PatronymicText);
            mock_Screen.Verify(pr => pr.PositionText);
            mock_Screen.Verify(pr => pr.SurnameText);
        }
    }
}
