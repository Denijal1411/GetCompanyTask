using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class DALUsers
    {
        private static GetDatabaseEntities db = new GetDatabaseEntities();
        public static User  GetUsers(string username, string password) { 
            return db.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
        } 
        public static void AddUser(string name, string surname, string email, string password, string username, int idrole)
        { 
            db.Users.Add(new User
            {
                Name = name,
                IDRole=idrole,
                Email=email,
                Password=password,
                Surname=surname,
                UserName=username 

            });

            db.SaveChanges();
        }
    }
}
