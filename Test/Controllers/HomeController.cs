using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    /// <summary>
    /// Controller for Home page
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index for controller
        /// </summary>
        /// <returns>View</returns>
        [Authorize]
        public ActionResult Index()
        {
            if (TempData["Error"] != null && !String.IsNullOrEmpty(TempData["Error"].ToString()))
            {
                ViewBag.Error = TempData["Error"].ToString();
            }
            if (TempData["Success"] != null && !String.IsNullOrEmpty(TempData["Success"].ToString()))
            {
                ViewBag.Success = TempData["Success"].ToString();
            }


            Test.Models.user userAct = new Test.Models.user();
            userAct = (Session[Test.Helpers.Constant.USUARIO] as Test.Models.user);
            if (userAct != null && userAct.Role == "admin")
            {
                //get the list of logins if user is admin
                List<loginsList> listOfLogins = new List<loginsList>();
                using (var conte = new Entity.testRealEntities())
                {
                    var listLoginsDB = conte.logins.OrderByDescending(a => a.date);
                    foreach(var record in listLoginsDB)
                    {
                        listOfLogins.Add(new loginsList() { login = record.login,
                            date = (record.date.HasValue ? record.date.Value.ToString("yyyy-MM-dd HH:mm") : "")});
                    }

                }
                ViewBag.loginsData = listOfLogins;
            }
            ViewBag.userData = Session[Test.Helpers.Constant.USUARIO];
            
            return View();
        }

    }
}