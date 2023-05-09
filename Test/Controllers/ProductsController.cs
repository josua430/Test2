using Test.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class ProductsController : Controller
    {
        /// <summary>
        /// // GET: products
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            CultureInfo en = new CultureInfo("es-CO");
            Thread.CurrentThread.CurrentCulture = en;
            if (TempData["Error"] != null && !String.IsNullOrEmpty(TempData["Error"].ToString()))
            {
                ViewBag.Error = TempData["Error"].ToString();
            }
            if (TempData["Success"] != null && !String.IsNullOrEmpty(TempData["Success"].ToString()))
            {
                ViewBag.Success = TempData["Success"].ToString();
            }
            return View();
        }

        /// <summary>
        /// Method to load grid
        /// </summary>
        /// <returns>JsonResult</returns>
        [HttpPost]
        public JsonResult LoadGrid()
        {
            try
            {
                clsDataBaseMethods objDB = new clsDataBaseMethods();
                return Json(objDB.ListProducts());
            }
            catch (Exception)
            {
                return null;
            }

        }

        #region Update
        /// <summary>
        /// Get for update
        /// </summary>
        /// <param name="id">id of product</param>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Update(string id)
        {

            if (Session[Test.Helpers.Constant.USUARIO] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //Create model
            var model = new Models.Products();
            try
            {
                int IdElemento = int.Parse(id);
                //Open connection to entity framework
                using (var context = new Entity.testRealEntities())
                {
                    var objElement = context.products.FirstOrDefault(t => t.productId == IdElemento);
                    if (objElement == null)
                    {
                        return RedirectToAction("Index", "Products");
                    }
                    model.description = objElement.description;
                    model.amount= objElement.amount == null ? 0 : (int)objElement.amount;
                    model.verificationKey = "";
                    model.productId = (int)objElement.productId;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(model);
        }

        /// <summary>
        /// Save data for update
        /// </summary>
        /// <param name="objElement">object with data for update</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult Update(Models.Products objElement)
        {
            try
            {
                clsDataBaseMethods objDB = new clsDataBaseMethods();

                if (objDB.Update(objElement))
                {
                    TempData["Success"] = "Update successfull!";
                    return RedirectToAction("Index", "Products");
                }else
                {
                    ViewBag.Error = "Wrong Key for update";
                }


            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.InnerException;
            }
            return View(objElement);
        }

        #endregion
    }
}