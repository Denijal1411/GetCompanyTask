using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    
    public class  DALProject:DAL<Project>
    {
        private static GetDatabaseEntities db = new GetDatabaseEntities();

        public  List<User> GetManagers() { 
            return db.Users.Where(x => x.IDRole == 2 && x.Active==true).ToList();
        }
        public void Add(Project project)
        {
            db.Projects.Add(project); 
            db.SaveChanges();
        }

        public void Delete(Project project)
        {
            var searchProject = db.Projects.FirstOrDefault(x => x.ProjectCode == project.ProjectCode && x.Active==true);
            searchProject.Active = false;
            db.SaveChanges();
        }

        public Project Get(Project t)
        {
            return db.Projects.FirstOrDefault(x => x.ProjectCode == t.ProjectCode && x.Active==true);
        }

        public List<Project> GetAll()
        {
            return db.Projects.Where(x=>x.Active==true).ToList();
        }

        public void Update(Project t)
        {
            var search = db.Projects.FirstOrDefault(x => x.ProjectCode == t.ProjectCode && x.Active==true);
            search.ProjectName = t.ProjectName;
            search.Assignee = t.Assignee;  
            db.SaveChanges();
        }
    }
}
