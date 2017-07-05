using OnlineStore.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Repositories.Interfaces
{
    public interface IStore
    {
        Task<GoodsDescriptionViewModel> GetGoodsDescriptionAsync(int goodsID);

        Task<List<PageWithGoodsViewModel>> GetGoodsAsync(int categoryID);

        Task<byte[]> GetCategoryPictureAsync(int categoryID);
    }
}
