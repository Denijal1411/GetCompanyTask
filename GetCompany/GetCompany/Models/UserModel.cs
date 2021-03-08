﻿using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GetCompany.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "UserName is required.")] 
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
    }
    public class CreateUserModel {
        [Key] 
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; } 
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Rola is required.")]
        public int IDRole { get; set; }
        public bool Active { get; set; }
        public string Role { 
            get { return Roles.FirstOrDefault(x => x.ID == IDRole).Name; }
            set { Role = value; } }
        public List<Data.Role> Roles { get; set; }
    }
}