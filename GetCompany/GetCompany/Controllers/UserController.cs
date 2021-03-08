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
                        Email = model.Email!=null?model.Email.Trim():null,
                        IDRole = model.IDRole,
                        Name = model.Name.Trim(),
                        Password = model.Password.Trim(),
                        Surname = model.Surname.Trim(),
                        UserName = model.UserName.Trim()
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
                    UserName = model.UserName.Trim(),
                    Surname = model.Surname.Trim(),
                    Email = model.Email!=null?model.Email.Trim():null,
                    IDRole = model.IDRole,
                    Name = model.Name.Trim(),
                    Password = model.Password.Trim()
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