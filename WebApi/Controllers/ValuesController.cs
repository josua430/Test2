using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {

        /// <summary>
        /// string with developer's name
        /// </summary>
        private const string DeveloperName = "Jose Alberto Suarez Blanco";

        /// <summary>
        /// POST for Change the Key
        /// </summary>
        /// <param name="strFullNameDeveloper">name of developer</param>
        /// <param name="strNewKey">new key</param>
        /// <returns>string with result</returns>
        public IHttpActionResult Post(changekey objValues)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            if (objValues.DevName != DeveloperName)
            {
                return BadRequest("Error updating Key.");
            }
            else
            {
                //update key
                using (var context = new Entity.TestEntities())
                {
                    var keyUpd = context.key.FirstOrDefault();
                    if (keyUpd == null)
                    {
                        //create new
                        var objNewKey = new Entity.key();
                        objNewKey.keycode = objValues.newKey;
                        context.key.Add(objNewKey);
                        context.SaveChanges();
                    }
                    else
                    {
                        //update
                        keyUpd.keycode = objValues.newKey;
                        context.SaveChanges();
                    }
                }
            }

            return Ok();
        }

    }
}
