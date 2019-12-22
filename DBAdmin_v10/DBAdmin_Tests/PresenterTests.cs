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
        Mock<DBAdmin_v10.IDB_Model> mock_DB;
        Mock<DBAdmin_v10.IInsertScreen> mock_Screen;
        DBAdmin_v10.InsertUserPresenter presenter;

        [TestInitialize]
        public void SetUp()
        {
            mock_DB = new Mock<DBAdmin_v10.IDB_Model>();
            mock_Screen = new Mock<DBAdmin_v10.IInsertScreen>();
            presenter = new DBAdmin_v10.InsertUserPresenter(mock_Screen.Object, mock_DB.Object);
        }

        [TestMethod]
        public void Test_InsertUserPresenterInsertToDB()
        {
            //action
            presenter.InsertUserToDB();

            //assert
            mock_DB.Verify(pr => pr.Insert(It.IsAny<DBAdmin_v10.Users>()));
        }

        [TestMethod]
        public void Test_InsertUserPresenterGetUserLogin()
        {
            presenter.CreateUserFromInsertScreen();

            mock_Screen.Verify(pr => pr.LoginText);
        }

        [TestMethod]
        public void Test_InsertUserPresenterGetUserName()
        {
            presenter.CreateUserFromInsertScreen();

            mock_Screen.Verify(pr => pr.NameText);
        }

        [TestMethod]
        public void Test_InsertUserPresenterGetUserPatro()
        {
            presenter.CreateUserFromInsertScreen();

            mock_Screen.Verify(pr => pr.PatronymicText);
        }

        [TestMethod]
        public void Test_InsertUserPresenterGetUserPos()
        {
            presenter.CreateUserFromInsertScreen();

            mock_Screen.Verify(pr => pr.PositionText);
        }

        [TestMethod]
        public void Test_InsertUserPresenterGetUserSurname()
        {
            presenter.CreateUserFromInsertScreen();

            mock_Screen.Verify(pr => pr.SurnameText);
        }
    }

    [TestClass]
    public class DeleteUserPresenterTests
    {
        Mock<DBAdmin_v10.IDB_Model> mock_DB;
        DBAdmin_v10.DeleteUserPresenter presenter;

        [TestInitialize]
        public void SetUp()
        {
            mock_DB = new Mock<DBAdmin_v10.IDB_Model>();
            presenter = new DBAdmin_v10.DeleteUserPresenter(mock_DB.Object);
        }

        [TestMethod]
        public void Test_DeleteUserPresenterDelete()
        {
            List<int> list = new List<int>();
            list.Add(20);

            presenter.DeleteUserFromDB(list);

            mock_DB.Verify(pr => pr.Delete(list));
        }
    }

    [TestClass]
    public class ChangeUserPresenterTests
    {
        Mock<DBAdmin_v10.IDB_Model> mock_DB;
        Mock<DBAdmin_v10.IChangeInfoScreen> mock_Screen;
        DBAdmin_v10.ChangeUserInfoPresenter presenter;

        [TestInitialize]
        public void SetUp()
        {
            mock_DB = new Mock<DBAdmin_v10.IDB_Model>();
            mock_Screen = new Mock<DBAdmin_v10.IChangeInfoScreen>();
            presenter = new DBAdmin_v10.ChangeUserInfoPresenter(mock_Screen.Object, mock_DB.Object);
        }

        [TestMethod]
        public void Test_ChangeUserPresenterUpdate()
        {
            presenter.ChangeUserInfoInDB();

            mock_DB.Verify(pr => pr.Update(It.IsAny<DBAdmin_v10.Users>()));
        }

        [TestMethod]
        public void Test_ChangeUserPresenterGetUserLogin()
        {
            presenter.CreateUserFromChangeInfoScreen();

            mock_Screen.Verify(pr => pr.LoginText);
        }

        [TestMethod]
        public void Test_ChangeUserPresenterGetUserName()
        {
            presenter.CreateUserFromChangeInfoScreen();

            mock_Screen.Verify(pr => pr.NameText);
        }

        [TestMethod]
        public void Test_ChangeUserPresenterGetUserPatro()
        {
            presenter.CreateUserFromChangeInfoScreen();

            mock_Screen.Verify(pr => pr.PatronymicText);
        }

        [TestMethod]
        public void Test_ChangeUserPresenterGetUserPos()
        {
            presenter.CreateUserFromChangeInfoScreen();

            mock_Screen.Verify(pr => pr.PositionText);
        }

        [TestMethod]
        public void Test_ChangeUserPresenterGetUserSurname()
        {
            presenter.CreateUserFromChangeInfoScreen();

            mock_Screen.Verify(pr => pr.SurnameText);
        }
    }
}
