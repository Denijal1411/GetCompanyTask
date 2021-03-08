using Data;
using GetCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetCompany.Controllers
{

    [Authorize(Roles = "Administrator,Project Manager")]
    public partial class UserController : Controller
    {
        DALUsers dal = new DALUsers();
        public virtual ActionResult UserHome()
        {
            return View(dal.GetAll());
        }
        public virtual ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public virtual ActionResult AddUser(CreateUserModel model)
        {
            if (dal.UserExists(model.UserName) == true) ModelState.AddModelError("UserName", "Username already exists!.");
            if (ModelState.IsValid)
            {
                try
                {
                    dal.Add(new User()
                    {
                        Email = model.Email,
                        IDRole = model.IDRole,
                        Name = model.Name,
                        Password = model.Password,
                        Surname = model.Surname,
                        UserName = model.UserName
                    });
                    return RedirectToAction("UserHome", "User");
                }
                catch (Exception)
                {

                    return View();
                }



            }
            return View();

        }
        public virtual ActionResult DeleteUser(string username)
        {
            dal.Delete(new User()
            {
                UserName = username
            });
            return RedirectToAction("UserHome", "User");
        }
        public virtual ActionResult EditUser(string username)
        {
            try
            {
                var user = dal.Get(new User() { UserName = username });



                return View(new CreateUserModel()
                {
                    Email = user.Email,
                    Surname = user.Surname,
                    IDRole = user.IDRole,
                    Name = user.Name,
                    Password = user.Password,
                    UserName = user.UserName,
                    Roles = DALUserRoles.GetAllRoles()

                });
            }
            catch (Exception e)
            {
                return RedirectToAction("UserHome", "User");
            }

        }
        [HttpPost]
        public virtual ActionResult EditUser(CreateUserModel model)
        {
            var user = dal.Get(new User() { UserName = model.UserName });

            if (ModelState.IsValid)
            {
                dal.Update(new User()
                {
                    UserName = model.UserName,
                    Surname = model.Surname,
                    Email = model.Email,
                    IDRole = model.IDRole,
                    Name = model.Name,
                    Password = model.Password
                });
                return RedirectToAction("UserHome", "User");
            }
            return View(new CreateUserModel()
            {
                Email = user.Email,
                Surname = user.Surname,
                IDRole = user.IDRole,
                Name = user.Name,
                Password = user.Password,
                UserName = user.UserName,
                Roles = DALUserRoles.GetAllRoles()

            });
            return View();


        }
    }
}