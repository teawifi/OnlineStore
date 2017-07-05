using OnlineStore.Models;
using System.Web.Mvc;

namespace OnlineStore.ModelBinders
{
    public class CartModelBinder : IModelBinder
    {
        private ShoppingCart cart;

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            cart = ShoppingCart.Instance;

            return cart;            
        }        
    }
}