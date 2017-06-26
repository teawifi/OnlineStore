using OnlineStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class NavController : Controller
    {
        private NavigationRepository navRepo = new NavigationRepository();

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var listCategories = navRepo.SelectCategories();
            if (listCategories == null)
            {
                return HttpNotFound();
            }
            string result = "";
            foreach (var item in listCategories)
            {
                result += "<li><a href='/Store/IndexAsync/?categoryID=" + item.CategoryID + "' title='" + item.CategoryName + "'>" + item.CategoryName + "</a></li>";
            }
            return Content(result);
        }
    }
}