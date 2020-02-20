using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    /// <summary>
    /// Class for Reserves
    /// </summary>
    public class Reserves
    {
        /// <summary>
        /// Id
        /// </summary>
        public int idreserve { get; set; }

        /// <summary>
        /// Id user
        /// </summary>
        public int iduser { get; set; }

        /// <summary>
        /// Id product
        /// </summary>
        public int idproduct { get; set; }

        /// <summary>
        /// login user
        /// </summary>
        public string userlogin { get; set; }

        /// <summary>
        /// Description of product
        /// </summary>
        public string productDescription { get; set; }

        /// <summary>
        /// amount reserved
        /// </summary>
        public int amountReserved { get; set; }

        /// <summary>
        /// Maximum amount for reserve
        /// </summary>
        public int MaxAmountReserved { get; set; }

        /// <summary>
        /// date reserved
        /// </summary>
        public DateTime? dateReserved { get; set; }

        /// <summary>
        /// String of date reserved
        /// </summary>
        public string strDateReserved { get; set; }
    }
}