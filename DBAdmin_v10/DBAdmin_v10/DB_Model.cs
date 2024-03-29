﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DBAdmin_v10
{
    public class DB_Model : IDB_Model
    {
        public DataClasses1DataContext db;

        public string GetMd5Code(string oldpasswd)
        {
            var md5 = MD5.Create();

            for (int i = 0; i < 1000; ++i)
            {
                oldpasswd = Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(oldpasswd)));
            }       

            return oldpasswd;
        }

        public void DataChange(Users olduser, Users newuser)
        {
            newuser.login = olduser.login;
            newuser.password = GetMd5Code(olduser.password);
            newuser.surname = olduser.surname;
            newuser.name = olduser.name;

            if (!String.IsNullOrEmpty(olduser.patronymic))
            {
                newuser.patronymic = olduser.patronymic;
                newuser.initials = olduser.name.Substring(0, 1) + '.' + olduser.patronymic.Substring(0, 1);
            }

            newuser.position = olduser.position;
        }

        public bool Insert(Users olduser)
        {
            db = new DataClasses1DataContext();
            Users newuser = new Users();

            DataChange(olduser, newuser);

            db.Users.InsertOnSubmit(newuser);

            try
            {
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Users olduser)
        {
            db = new DataClasses1DataContext();

            var newuser = db.Users.Where(w => w.id == olduser.id).FirstOrDefault();

            DataChange(olduser, newuser);

            try
            {
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(List<int> userlist)
        {
            db = new DataClasses1DataContext();
            List<Users> deleteusers = new List<Users>();

            for (int i = 0; i < userlist.Count(); ++i)
            {
                var newuser = db.Users.Where(w => w.id == userlist[i]).FirstOrDefault();
                deleteusers.Add(newuser);
                db.Users.DeleteOnSubmit(deleteusers[i]);
            }

            try
            {
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
