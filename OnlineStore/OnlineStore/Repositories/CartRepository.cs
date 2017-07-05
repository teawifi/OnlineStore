using OnlineStore.Models;
using OnlineStore.Models.ViewModels;
using OnlineStore.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repositories
{
    public class CartRepository : ICart
    {
        private ApplicationDbContext GetApplicationDbContext()
        {
            return ApplicationDbContext.Create();
        }

        // The CreateCartItemVM() creates and returns a cart item

        public async Task<CartItemViewModel> CreateCartItemVMAsync(int productID)
        {
            using (var dbContext = GetApplicationDbContext())
            {
                return await Task<CartItemViewModel>.Factory.StartNew(() =>
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
                });                
            }
        }        
    }
}