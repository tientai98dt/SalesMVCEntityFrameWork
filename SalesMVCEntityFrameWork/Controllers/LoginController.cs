using SalesLibrary;
using SalesMVCEntityFrameWork.Models;
using SalesMVCEntityFrameWork.SessionCode;
using System.Web.Mvc;
using System.Web.Security;

namespace SalesMVCEntityFrameWork.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login login)
        {
            //var result = new LoginModels().Login(login.UserName,login.PassWord);
            if (Membership.ValidateUser(login.UserName,login.PassWord) && ModelState.IsValid)
            {
                //LoginSession.SetSession(new Login() { UserName = login.UserName});
                FormsAuthentication.SetAuthCookie(login.UserName,true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("","Ten Dang Nhap Hoac Mat Khau Khong Dung");
            }
            return View(login);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Login");
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
