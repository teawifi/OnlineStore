﻿using OnlineStore.Models;
using OnlineStore.Repositories;
using OnlineStore.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class CartController : Controller
    {
        public ICart cartRepo = new CartRepository();

        /*
         * AddItemToCart() method adds goods to shopping cart and returns cart items to partial view.
         * The binding mechanism creates the object cart using session state
        */

        public async Task<ActionResult> AddItemToCartAsync(ShoppingCart cart, int productID)
        {
            if(productID < 1)
            {
                return HttpNotFound();
            }
            var goods = await cartRepo.CreateCartItemVMAsync(productID);

            if (goods == null)
            {
                return HttpNotFound();
            }
            
            cart.AddItem(goods);

            var cartItems = cart.ItemsSet;

            if(cartItems == null)
            {
                return HttpNotFound();
            }
            
            return PartialView("ShoppingCart", cartItems);
        }

        [Authorize]
        public ActionResult ClearShoppingCart(ShoppingCart cart)
        {
            cart.ClearCart();

            TempData["Message"] = "Thank you for choosing us!";

            return Redirect("/Store/IndexAsync");
        }
        
        
        public ActionResult CountItemsInCart(ShoppingCart cart)
        {
            return PartialView(cart);
        }        
    }
}