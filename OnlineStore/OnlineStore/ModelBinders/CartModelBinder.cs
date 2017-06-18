using OnlineStore.Models;
using System.Web.Mvc;

namespace OnlineStore.ModelBinders
{
    public class CartModelBinder : IModelBinder
    {
        private string sessionIndex = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ShoppingCart cart = (ShoppingCart)controllerContext.HttpContext.Session[sessionIndex];

            if(cart == null)
            {
                cart = new ShoppingCart();
                controllerContext.HttpContext.Session[sessionIndex] = cart;
            }

            return cart;            
        }        
    }
}