using OnlineStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repositories.Interfaces
{
    public interface INavigation
    {
        List<CategoryViewModel> SelectCategories();
    }
}
