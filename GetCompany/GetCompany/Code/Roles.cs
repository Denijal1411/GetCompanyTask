using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetCompany.Code
{
    public enum IDRoles {
        Administrator=1,
        ProjectManager=2,
        Developer=3
    }
    public class Roles {
        public static List<string> GetIDRolesString()
        {
            List<string> rolesEnum = new List<string>();
            foreach (var foo in Enum.GetValues(typeof(IDRoles)))
            {
                rolesEnum.Add(foo.ToString() + "-" + (int)foo);
            }
            return rolesEnum;
        }
    }
   
}