using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DALTasks : DAL<Task>
    {
        private static GetDatabaseEntities db = new GetDatabaseEntities();

        
        public List<Project> GetProjects()
        {
            return db.Projects.ToList();
        }
        public List<string> GetStatuses()
        {
            return new List<string>() { "New", "In Progress", "Finished" };
        }

        public override void Add(Task t)
        {
            db.Tasks.Add(t);
            db.SaveChanges();
        }

        public override void Delete(Task t)
        {
            var searchTask = db.Tasks.FirstOrDefault(x => x.ID == t.ID);
            db.Tasks.Remove(searchTask);
            db.SaveChanges();
        }

        public override Task Get(Task t)
        {
            return db.Tasks.FirstOrDefault(x => x.ID == t.ID);
        }

        public override List<Task> GetAll()
        {
            return db.Tasks.ToList();
        }

        public override void Update(Task t)
        {
            var search = db.Tasks.FirstOrDefault(x => x.ID == t.ID);
            search.Progress = t.Progress; 
            search.Status = t.Status; 
            search.IDProject = t.IDProject;
            search.Description = t.Description;
            search.Deadline = t.Deadline;
            search.Assignee = t.Assignee; 
            db.SaveChanges();
        }
    }
}
