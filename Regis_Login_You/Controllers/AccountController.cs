using Regis_Login_You.DBModel;
using Regis_Login_You.Models;
using System;
using System.Linq;
using System.Web.Mvc;


namespace Regis_Login_You.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        Project_mvc_dbEntities objUserDBEntities = new Project_mvc_dbEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            UserModel objUserModel = new UserModel();
            return View(objUserModel);
        }


        [HttpPost]
        public ActionResult Register(UserModel objUserModel)
        {
            if (ModelState.IsValid)
            {
                if (!objUserDBEntities.Users.Any(m => m.Email == objUserModel.Email))
                {

                    User objUser = new DBModel.User();
                    objUser.CreatedOn = DateTime.Now;
                    objUser.Email = objUserModel.Email;
                    objUser.FirstName = objUserModel.FirstName;
                    objUser.LastName = objUserModel.LastName;
                    objUser.Password = objUserModel.Password;
                    objUserDBEntities.Users.Add(objUser);
                    objUserDBEntities.SaveChanges();
                    objUserModel = new UserModel();
                    objUserModel.SuccessMessage = "User is Successfully added";
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("Error", "Email is already rehgistered!");
                    return View();
                }

            }

            return View();
        }
        public ActionResult Login()
        {
            LoginModel objLoginModel = new LoginModel();
            return View(objLoginModel);
        }

        [HttpPost]
        public ActionResult Login(LoginModel objLoginModel)
        {
            if (ModelState.IsValid)
            {
                if (objUserDBEntities.Users.Where(m => m.Email == objLoginModel.Email && m.Password == objLoginModel.Password).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Invalid UserName or Password");
                    return View();
                }
                else
                {
                    Session["Email"] = objLoginModel.Email;
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}