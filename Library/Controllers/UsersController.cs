using Library.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {


            var users = db.Users.ToList();

            return View(users);
            return View();


        }
        public ActionResult Delete(string email)
        {


            var user = db.Users.Where(e => e.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var usermanager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
            try
            {
                var oldUser = usermanager.FindById(user.Id);
                var oldRoleId = oldUser.Roles.SingleOrDefault().RoleId;
                var oldRoleName = db.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;
                usermanager.RemoveFromRole(user.Id, oldRoleName);
                usermanager.Delete(oldUser);
                
                db.Entry(user).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                
                throw e;
            }
            return RedirectToAction("Index");



        }
    }
}