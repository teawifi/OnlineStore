using OnlineStore.ModelBinders;
using OnlineStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Models
{
    [ModelBinder(typeof(CartModelBinder))]
    public sealed class ShoppingCart
    {
        private static readonly ShoppingCart instance = new ShoppingCart();
        
        public List<CartItemViewModel> ItemsSet { get; set; }

        private ShoppingCart()
        {
            ItemsSet = new List<CartItemViewModel>();            
        }

        public static ShoppingCart Instance
        {
            get
            {
                return instance;
            }
        }        

        public void AddItem(CartItemViewModel item)
        {
            CartItemViewModel unit = ItemsSet.FirstOrDefault(i => i.ProductID == item.ProductID);

            if (unit == null)
            {
                ItemsSet.Add(item);
            }
            else
            {
                foreach(var element in ItemsSet.Where(i => i.ProductID == item.ProductID))
                {
                    element.Quantity = item.Quantity;
                }                
            }

        }

        public void ClearCart()
        {
            ItemsSet.Clear();
        }        
    }    
}