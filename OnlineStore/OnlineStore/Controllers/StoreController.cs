using OnlineStore.Repositories;
using OnlineStore.Repositories.Interfaces;
using PagedList;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class StoreController : Controller
    {
        IStore store = new StoreRepository();
        
        // Index() method returns the goods list to start page         

        public async Task<ActionResult> IndexAsync(int? page, int categoryID = 1)
        {
            int pageSize = 15;
            int pageNumber = (page ?? 1);

            var list = await store.GetGoodsAsync(categoryID);

            if (list == null)
            {
                return HttpNotFound();
            }
            
            return View("Index", list.ToPagedList(pageNumber, pageSize));
        }
        
        // GetProduct() method returns the product data to view         

        public async Task<ActionResult> GetProductAsync(int goodsID)
        {
            if(goodsID < 1)
            {
                return HttpNotFound();
            }

            var goods = await store.GetGoodsDescriptionAsync(goodsID);

            if(goods == null)
            {
                return HttpNotFound();
            }
            return View("GetProduct", goods);
        }

        // GetImage() method returns a category image to "GetProduct" view

        public async Task<ActionResult> GetImageAsync(int categoryID)
        {
            var picture = await store.GetCategoryPictureAsync(categoryID);
            if (picture != null)
            {
                return new FileContentResult(picture, "image/jpeg");                
            }
            else
            {
                return null;
            }
        } 

    }
}