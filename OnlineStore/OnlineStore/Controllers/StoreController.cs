using OnlineStore.Repositories;
using OnlineStore.Repositories.Interfaces;
using PagedList;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class StoreController : Controller
    {
        IStore store = new StoreRepository();
        
        // Index() method returns the goods list to start page         

        public ActionResult Index(int? page, int categoryID = 1)
        {
            int pageSize = 15;
            int pageNumber = (page ?? 1);

            var list = store.GetGoods(categoryID);

            if (list == null)
            {
                return HttpNotFound();
            }
            
            return View(list.ToPagedList(pageNumber, pageSize));
        }
        
        // GetProduct() method returns the product data to view         

        public ActionResult GetProduct(int goodsID)
        {
            if(goodsID < 1)
            {
                return HttpNotFound();
            }

            var goods = store.GetGoodsDescription(goodsID);

            if(goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // GetImage() method returns a category image to "GetProduct" view

        public ActionResult GetImage(int categoryID)
        {
            var picture = store.GetCategoryPicture(categoryID);
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