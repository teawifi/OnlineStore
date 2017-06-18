using OnlineStore.Models;
using OnlineStore.Models.ViewModels;
using OnlineStore.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Repositories
{
    public class NavigationRepository : INavigation
    {
        private ApplicationDbContext GetApplicationDbContext()
        {
            return ApplicationDbContext.Create();
        }

        public List<CategoryViewModel> SelectCategories()
        {
            using (var dbContext = GetApplicationDbContext()) {


                List<CategoryViewModel> listCategories = (from category in dbContext.Categories
                                     where (category.CategoryID == 3) || (category.CategoryID == 1)
                                     select new CategoryViewModel
                                     {
                                         CategoryID = category.CategoryID,
                                         CategoryName = category.CategoryName
                                     }).ToList();

                return listCategories;
            }            
        }
    }
}