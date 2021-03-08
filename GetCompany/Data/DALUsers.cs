﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DALUsers:DAL<User>
    {

        private static GetDatabaseEntities db = new GetDatabaseEntities();
        public static User CheckUser(string username, string password)
        {
            return db.Users.FirstOrDefault(x => x.UserName == username && x.Password == password && x.Active==true);
        }
        public bool UserExists(string username)
        {
            return db.Users.FirstOrDefault(x => x.UserName == username) !=null ?true:false;
        }
        public bool UserHasMoreTasks(string user) { 
            return db.Tasks.Where(x => x.Assignee == user && x.Status != "Finished").Count() == 3 ? true : false;
        }
        public override void Update(User user)
        {
            var searchUser = db.Users.FirstOrDefault(x => x.UserName == user.UserName);
            searchUser.Name = user.Name;
            searchUser.Surname = user.Surname;
            searchUser.Email = user.Email;
            searchUser.Password = user.Password;
            searchUser.IDRole = user.IDRole;
            searchUser.Active = user.Active;

            db.SaveChanges();
        }
        public override void Add(User user)
        { 
            db.Users.Add(user);

            db.SaveChanges(); 
        }
        public override void Delete(User user)
        {
            var searchUser = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Active==true);
            searchUser.Active = false; 
            db.SaveChanges(); 
        }

        public override User Get(User t)
        {
            return db.Users.FirstOrDefault(x => x.UserName == t.UserName && x.Active==true);
        }

        public override List<User> GetAll()
        {
            return db.Users.Where(x=>x.Active==true).ToList();
        } 
    }
}
