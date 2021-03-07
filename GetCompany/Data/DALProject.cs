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
            return db.Users.Where(x => x.IDRole == 2).ToList();
        }
        public override void Add(Project project)
        {
            db.Projects.Add(project); 
            db.SaveChanges();
        }

        public override void Delete(Project project)
        {
            var searchProject = db.Projects.FirstOrDefault(x => x.ProjectCode == project.ProjectCode);
            db.Projects.Remove(searchProject);
            db.SaveChanges();
        }

        public override Project Get(Project t)
        {
            return db.Projects.FirstOrDefault(x => x.ProjectCode == t.ProjectCode);
        }

        public override List<Project> GetAll()
        {
            return db.Projects.ToList();
        }

        public override void Update(Project t)
        {
            var search = db.Projects.FirstOrDefault(x => x.ProjectCode == t.ProjectCode);
            search.ProjectName = t.ProjectName;
            search.Assignee = t.Assignee;  
            db.SaveChanges();
        }
    }
}
