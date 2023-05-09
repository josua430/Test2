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
    public class ReserveController : Controller
    {

        #region List of products for reserve
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
        #endregion

        #region List of reserves for a user
        /// <summary>
        /// // GET: List of reserves
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult List()
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
        /// Method to load grid of reserves
        /// </summary>
        /// <returns>JsonResult</returns>
        [HttpPost]
        public JsonResult LoadGridReserves()
        {
            try
            {
                var userAct = (Session[Test.Helpers.Constant.USUARIO] as Test.Models.user);

                clsDataBaseMethods objDB = new clsDataBaseMethods();
                return Json(objDB.ListReserves(userAct.IdUser));
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Detail of reserves for products
        /// <summary>
        /// // GET: List of reserves
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Detail()
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
            
            try
            {
                clsDataBaseMethods objDB = new clsDataBaseMethods();
                ViewBag.DataProducts = objDB.ListProducts();
            }
            catch (Exception)
            {
                ViewBag.DataProducts = null;
            }
            return View();
        }


        #endregion

        #region Create reserve
        /// <summary>
        /// Get for update
        /// </summary>
        /// <param name="id">id of product for reserve</param>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Create(string id)
        {

            if (Session[Test.Helpers.Constant.USUARIO] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var userAct = (Session[Test.Helpers.Constant.USUARIO] as Test.Models.user);

            //Create model
            var model = new Models.Reserves();
            try
            {
                int IdElemento = int.Parse(id);
                //Open connection to entity framework
                using (var context = new Entity.testRealEntities())
                {
                    var objElement = context.products.FirstOrDefault(t => t.productId == IdElemento);
                    if (objElement == null)
                    {
                        return RedirectToAction("Index", "Reserve");
                    }
                    model.productDescription = objElement.description;
                    model.MaxAmountReserved = objElement.amount == null ? 0 : (int)objElement.amount;
                    model.iduser = userAct.IdUser;
                    model.idproduct = (int)objElement.productId;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(model);
        }

        /// <summary>
        /// Save data for Create reserve
        /// </summary>
        /// <param name="objElement">object with data for update</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult Create(Models.Reserves objElement)
        {
            try
            {
                clsDataBaseMethods objDB = new clsDataBaseMethods();

                objDB.Insert(objElement);
                TempData["Success"] = "Update successfull!";
                return RedirectToAction("Index", "Reserve");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.InnerException;
            }
            return View(objElement);
        }

        #endregion
    }
}