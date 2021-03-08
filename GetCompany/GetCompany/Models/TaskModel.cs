using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GetCompany.Models
{
    public class TaskModel
    {
        public int ID { get; set; }
        [Required]
        public string Assignee { get; set; }
        [Required]
        public string Status { get; set; }
        public int Progress { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime Deadline { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int IDProject { get; set; }

        public virtual List<Project> Projects { get; set; }
        public virtual List<User> Users { get; set; }
        public List<string> Statuses { get; set; } 
    }
    public class TaskCreateModel//razlikuje se od ovog gore jer nema required status i progres jer se dodaju automacki 1411
    {
        public int ID { get; set; }
        [Required]
        public string Assignee { get; set; } 
        public string Status { get; set; }
        public int Progress { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime Deadline { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int IDProject { get; set; }

        public virtual List<Project> Projects { get; set; }
        public virtual List<User> Users { get; set; }
        public List<string> Statuses { get; set; }
    }
}