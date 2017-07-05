using OnlineStore.Repositories;
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

            return PartialView("Menu", listCategories);
        }
    }
}