using OnlineStore.Models.ViewModels;
using System.Collections.Generic;

namespace OnlineStore.Repositories.Interfaces
{
    public interface INavigation
    {
        List<CategoryViewModel> SelectCategories();        
    }
}
