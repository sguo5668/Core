using Microsoft.AspNetCore.Mvc.Rendering;
using eShopOnWeb.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopOnWeb.Interfaces
{
    public interface ICatalogService
    {

        Task<CatalogIndexViewModel> GetCatalogItems(int pageIndex, int itemsPage, int? brandId, int? typeId);

    }
}
