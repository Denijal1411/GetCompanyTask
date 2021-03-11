using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public void Update(User user)
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
        public void Add(User user)
        { 
            db.Users.Add(user);

            db.SaveChanges(); 
        }
        public void Delete(User user)
        {
            var searchUser = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Active==true);
            searchUser.Active = false; 
            db.SaveChanges(); 
        }

        public User Get(User t)
        {
            return db.Users.FirstOrDefault(x => x.UserName == t.UserName && x.Active==true);
        }

        public List<User> GetAll()
        { 

            return db.Users.Where(x=>x.Active==true).ToList();
        }
        public static List<User> GetAllDevelopers()
        {

            return db.Users.Where(x => x.Active == true && x.Role.Name=="Developer").ToList();
        }
        public static List<User> GetNonAdminUsers()
        {

            return db.Users.Where(x => x.Active == true && x.Role.Name!="Administrator").ToList();
        }
    }
}
