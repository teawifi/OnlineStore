using OnlineStore.Models;
using OnlineStore.Models.ViewModels;
using OnlineStore.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Repositories
{
    public class CartRepository : ICart
    {
        ShoppingCart cart = new ShoppingCart();

        private ApplicationDbContext GetApplicationDbContext()
        {
            return ApplicationDbContext.Create();
        }

        // CreateCartItemVM() creates and returns a cart item

        public CartItemViewModel CreateCartItemVM(int productID)
        {
            using (var dbContext = GetApplicationDbContext())
            {
                var item = (from product in dbContext.Products
                           where product.ProductID == productID
                           select
                           new CartItemViewModel
                           {
                               ProductID = product.ProductID,
                               ProductName = product.ProductName,
                               Quantity = 1
                           }).FirstOrDefault();
                return item;
            }
        }        
    }
}