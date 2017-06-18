using OnlineStore.Models;
using OnlineStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repositories.Interfaces
{
    public interface IStore
    {
        List<PageWithGoodsViewModel> GetGoods(int categoryID);

        GoodsDescriptionViewModel GetGoodsDescription(int goodsID);

        byte[] GetCategoryPicture(int categoryID);        
    }
}
