// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace GetCompany.Controllers
{
    public partial class UserController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public UserController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected UserController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult DeleteUser()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteUser);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult EditUser()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditUser);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public UserController Actions { get { return MVC.User; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "User";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "User";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string UserHome = "UserHome";
            public readonly string AddUser = "AddUser";
            public readonly string DeleteUser = "DeleteUser";
            public readonly string EditUser = "EditUser";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string UserHome = "UserHome";
            public const string AddUser = "AddUser";
            public const string DeleteUser = "DeleteUser";
            public const string EditUser = "EditUser";
        }


        static readonly ActionParamsClass_AddUser s_params_AddUser = new ActionParamsClass_AddUser();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddUser AddUserParams { get { return s_params_AddUser; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddUser
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_DeleteUser s_params_DeleteUser = new ActionParamsClass_DeleteUser();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DeleteUser DeleteUserParams { get { return s_params_DeleteUser; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DeleteUser
        {
            public readonly string username = "username";
        }
        static readonly ActionParamsClass_EditUser s_params_EditUser = new ActionParamsClass_EditUser();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditUser EditUserParams { get { return s_params_EditUser; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditUser
        {
            public readonly string username = "username";
            public readonly string model = "model";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string AddUser = "AddUser";
                public readonly string EditUser = "EditUser";
                public readonly string UserHome = "UserHome";
            }
            public readonly string AddUser = "~/Views/User/AddUser.cshtml";
            public readonly string EditUser = "~/Views/User/EditUser.cshtml";
            public readonly string UserHome = "~/Views/User/UserHome.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_UserController : GetCompany.Controllers.UserController
    {
        public T4MVC_UserController() : base(Dummy.Instance) { }

        [NonAction]
        partial void UserHomeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult UserHome()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UserHome);
            UserHomeOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AddUserOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddUser()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddUser);
            AddUserOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AddUserOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, GetCompany.Models.CreateUserModel model);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddUser(GetCompany.Models.CreateUserModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddUser);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            AddUserOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void DeleteUserOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string username);

        [NonAction]
        public override System.Web.Mvc.ActionResult DeleteUser(string username)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteUser);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "username", username);
            DeleteUserOverride(callInfo, username);
            return callInfo;
        }

        [NonAction]
        partial void EditUserOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string username);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditUser(string username)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditUser);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "username", username);
            EditUserOverride(callInfo, username);
            return callInfo;
        }

        [NonAction]
        partial void EditUserOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, GetCompany.Models.CreateUserModel model);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditUser(GetCompany.Models.CreateUserModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditUser);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            EditUserOverride(callInfo, model);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
