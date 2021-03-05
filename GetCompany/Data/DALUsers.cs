using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DALUsers
    {
        static GetDatabaseEntities db = new GetDatabaseEntities();
        public static User  GetUsers(string username, string password) { 
            return db.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
        }
        public static int getRolesForUser(string username) {
            return db.Users.FirstOrDefault(x => x.UserName == username).ID;
        }
    }
}
