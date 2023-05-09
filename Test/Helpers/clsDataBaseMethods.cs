using Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Helpers
{

    /// <summary>
    /// class to execute data operations for User
    /// </summary>
    public class clsDataBaseMethods
    {

        /// <summary>
        /// validate if the user exists by Id
        /// </summary>
        /// <param name="strId">Id of user</param>
        /// <returns>bool</returns>
        public bool ExistsId(string strId)
        {
            using (var context = new Entity.testRealEntities())
            {
                int idElemento = int.Parse(strId);
                var objPost = context.user.FirstOrDefault(p => p.Id == idElemento);

                if (objPost == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }


            }
        }

        /// <summary>
        /// validate if the login exists 
        /// </summary>
        /// <param name="strLogin">user name or login</param>
        /// <returns>bool</returns>
        public bool ExistsLogin(string strLogin)
        {
            using (var context = new Entity.testRealEntities())
            {
                //Se valida si ya existe
                var objUser = context.user.FirstOrDefault(d => d.login.ToUpper().Trim() == strLogin.ToUpper().Trim());
                if (objUser == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        /// <summary>
        /// Return a list of users
        /// </summary>
        /// <param name="blnAuthenticated">Param to identify if the user is authenticated</param>
        /// <returns></returns>
        public List<Models.user> ListUsers()
        {
            //List to return
            var Lista = new List<Models.user>();

            using (var context = new Entity.testRealEntities())
            {
                //Consulta a la tabla
                List<Entity.user> lstUsers;
                lstUsers = context.user.OrderBy(d => d.login).ToList();

                foreach (Entity.user item in lstUsers)
                {
                    //Se agregan a la lista
                    Lista.Add(new Models.user
                    {
                        UserName = item.login,
                        Age = (item.age == null ? "": item.age.ToString()),
                        Gender = item.gender,
                        Role = item.role,
                        Nationality = item.nationality,
                        IdUser = (int)item.Id
                    });
                }
                return Lista;
            }
        }

        /// <summary>
        /// Return a list of products
        /// </summary>
        /// <returns></returns>
        public List<Models.Products> ListProducts()
        {
            //List to return
            var ListProd = new List<Models.Products>();

            using (var context = new Entity.testRealEntities())
            {
                //Consulta a la tabla
                List<Entity.products> lstObjects;
                lstObjects = context.products.OrderBy(d => d.productId).ToList();

                foreach (Entity.products item in lstObjects)
                {
                    //Add to list
                    ListProd.Add(new Models.Products
                    {
                        description = item.description,
                        amount = item.amount == null ? 0 : (int)item.amount,
                        productId = (int)item.productId,
                        reserves = item.reserves.Select(a => new Reserves
                        {
                            iduser = (int)a.iduser,
                            amountReserved = (int)a.amountreserved,
                            dateReserved = a.datereserved,
                            idproduct = (int)a.idproduct,
                            idreserve = (int)a.idreserve,
                            userlogin = a.user.login,
                            strDateReserved = a.datereserved.Value.ToString("yyyy-MM-dd HH:mm:ss")
                        }).ToList()
                    });
                }
                return ListProd;
            }
        }

        /// <summary>
        /// Return a list of reserves
        /// </summary>
        /// <param name="idUser">id od user</param>
        /// <returns></returns>
        public List<Models.Reserves> ListReserves(int? idUser)
        {
            //List to return
            var ListReserves = new List<Models.Reserves>();

            using (var context = new Entity.testRealEntities())
            {
                List<Entity.reserves> lstObjects;
                if (idUser == null)
                {
                    lstObjects = context.reserves.OrderByDescending(d => d.idreserve).ToList();
                }
                else
                {
                    lstObjects = context.reserves.Where(a => a.iduser == idUser).OrderByDescending(d => d.idreserve).ToList();
                }
                

                foreach (Entity.reserves item in lstObjects)
                {
                    //Add to list
                    ListReserves.Add(new Models.Reserves
                    {
                        productDescription = item.products.description,
                        idreserve = (int)item.idreserve,
                        amountReserved = item.amountreserved == null ? 0 : (int)item.amountreserved,
                        iduser = (int)item.user.Id,
                        userlogin = item.user.login,
                        idproduct = (int)item.idproduct,
                        dateReserved = item.datereserved,
                        strDateReserved = item.datereserved.Value.ToString("yyyy-MM-dd HH:mm:ss")
                    });
                }
                return ListReserves;
            }
        }

        /// <summary>
        /// delete method for user
        /// </summary>
        /// <param name="strId"></param>
        public void Delete(string strId)
        {
            using (var context = new Entity.testRealEntities())
            {
                int idElemento = int.Parse(strId);
                var objUser = context.user.FirstOrDefault(p => p.Id== idElemento);

                if (objUser == null)
                {
                    return;
                }

                context.user.Remove(objUser);
                context.SaveChanges();

            }
        }

        /// <summary>
        /// Method to insert new user
        /// </summary>
        /// <param name="objUser">Element with all data to save</param>
        public void Insert(Models.user objUser)
        {
            using (var context = new Entity.testRealEntities())
            {
                //create model and save to data base
                var model = new Entity.user();
                model.login = objUser.UserName;
                model.password = clsCrypt.Encrypt(objUser.Password);
                model.gender = objUser.Gender;
                model.role = objUser.Role;
                model.nationality = objUser.Nationality;
                model.age = Convert.ToInt32(objUser.Age);
                context.user.Add(model);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Method to register reserve
        /// </summary>
        /// <param name="objReserve">Element with all data to save</param>
        public void Insert(Models.Reserves objElement)
        {
            using (var context = new Entity.testRealEntities())
            {
                //create model and save to data base
                var model = new Entity.reserves();
                model.amountreserved = objElement.amountReserved;
                model.datereserved = DateTime.Now;
                model.idproduct = objElement.idproduct;
                model.iduser = objElement.iduser;
                context.reserves.Add(model);
                //update amount of product
                var modelProduct = context.products.FirstOrDefault(a => a.productId == objElement.idproduct);
                if (modelProduct != null)
                {
                    modelProduct.amount -= objElement.amountReserved;
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Method to update a user
        /// </summary>
        /// <param name="objUser">Element with all data to save</param>
        public void Update(Models.user objUser)
        {
            using (var context = new Entity.testRealEntities())
            {
                //elemento a actualizar
                var update = context.user.FirstOrDefault(t => t.Id == objUser.IdUser);

                //Se actualiza
                update.password = clsCrypt.Encrypt(objUser.Password.Trim());
                update.gender = objUser.Gender;
                update.role = objUser.Role;
                update.nationality = objUser.Nationality;
                update.age = Convert.ToInt32(objUser.Age);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Method to update a product
        /// </summary>
        /// <param name="objUser">Element with all data to save</param>
        public bool Update(Models.Products objProduct)
        {
            using (var context = new Entity.testRealEntities())
            {
                if (context.key.FirstOrDefault().keycode != objProduct.verificationKey)
                {
                    //incorrect key. No updates
                    return false;
                }
                //element to update with the correct key
                var update = context.products.FirstOrDefault(t => t.productId == objProduct.productId);

                //Se actualiza
                update.amount = objProduct.amount;
                context.SaveChanges();
                return true;
            }
        }
    }
}