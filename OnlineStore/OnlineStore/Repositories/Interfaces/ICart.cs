using OnlineStore.Models.ViewModels;
using System.Threading.Tasks;

namespace OnlineStore.Repositories.Interfaces
{
    public interface ICart
    {
        Task<CartItemViewModel> CreateCartItemVMAsync(int productID);
    }
}
