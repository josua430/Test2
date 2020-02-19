using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiKey
{
    public class clsKey
    {
        /// <summary>
        /// string with developer's name
        /// </summary>
        private const string DeveloperName = "Jose Alberto Suarez Blanco";

        /// <summary>
        /// Change the Key
        /// </summary>
        /// <param name="strFullNameDeveloper">name of developer</param>
        /// <param name="strNewKey">new key</param>
        /// <returns>string with result</returns>
        public string changeKey(string strFullNameDeveloper, string strNewKey)
        {
            if (strFullNameDeveloper != DeveloperName)
            {
                return "Error updating Key.";
            }else
            {
                //update key
                using (var context = new testRealEntities1())
                {
                    var keyUpd = context.key.FirstOrDefault();
                    if (keyUpd == null)
                    {
                        //create new
                        var objNewKey = new ApiKey.key();
                        objNewKey.keycode = strNewKey;
                        context.key.Add(objNewKey);
                        context.SaveChanges();
                    }
                    else
                    {
                        //update
                        keyUpd.keycode = strNewKey;
                        context.SaveChanges();
                    }
                }
                return "Ok";
            }

        }
    }
}
