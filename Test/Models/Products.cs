using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    /// <summary>
    /// Class for products
    /// </summary>
    public class Products
    {
        /// <summary>
        /// Id
        /// </summary>
        public int productId { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// verification Key
        /// </summary>
        public string verificationKey { get; set; }

        /// <summary>
        /// amount
        /// </summary>
        public int amount { get; set; }

        /// <summary>
        /// list of reserves
        /// </summary>
        public List<Reserves> reserves { get; set; }
    }
}