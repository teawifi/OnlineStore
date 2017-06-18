using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models.ViewModels
{
    public class GoodsDescriptionViewModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int CategoryID { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }
    }
}