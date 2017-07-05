using OnlineStore.Models;
using OnlineStore.Repositories;
using OnlineStore.Repositories.Interfaces;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class CartController : Controller
    {
        public ICart cartRepo = new CartRepository();

        /*
         * The AddItemToCart() method adds good to shopping cart and returns cart items to partial view.
         * The binding mechanism creates the object cart
        */
        public ActionResult AddItemToCart(ShoppingCart cart, int productID)
        {
            var goods = cartRepo.CreateCartItemVMAsync(productID).Result;

            if (goods == null)
            {
                return HttpNotFound();
            }

            cart.AddItem(goods);

            var cartItems = cart.ItemsSet;

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