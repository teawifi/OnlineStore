using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models.ViewModels
{
    public class CartItemViewModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }
    }
}