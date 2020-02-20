using Test.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using WebApi.Models;
using Newtonsoft.Json;
using System.Text;

namespace Test.Controllers
{
    /// <summary>
    /// Post controller
    /// </summary>
    public class ApiKeyController : Controller
    {
        #region Update
        /// <summary>
        /// Get for update
        /// </summary>
        /// <param name="id">id of user</param>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Update()
        {

            if (Session[Test.Helpers.Constant.USUARIO] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var model = new changekey();
            return View(model);
        }

        /// <summary>
        /// Save data for update
        /// </summary>
        /// <param name="objKey">object with data for update</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult Update(changekey objKey)
        {
            try
            {
                //call to webAPI for update key
                var stringContent = new StringContent(JsonConvert.SerializeObject(objKey), Encoding.UTF8, "application/json");
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:61978");
                    var response = client.PostAsync("/api/Values", stringContent);

                    if (response.Result.IsSuccessStatusCode)
                    {
                        TempData["Success"] = "Update successfull!";
                        return RedirectToAction("Index", "Home");

                    }
                    ViewBag.Error = "Error updating Key";
                }

                return View(objKey);

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.InnerException;
            }
            return View(objKey);
        }

        #endregion
    }
}