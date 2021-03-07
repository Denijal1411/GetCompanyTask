using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GetCompany.Models
{
    public class ProjectModel
    {
        public int ProjectCode { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Project manager is required.")]
        public string Assignee { get; set; } 
        public List<User> Users { get; set; }
    }
}