using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Models;

namespace MVCCoreDemo.ViewComponents
{
    public class HeroListViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string type)
        {
            var heroes = await GetHeroesAsync(type);
            return View(heroes);
        }

        private Task<IEnumerable<DOTAHero>> GetHeroesAsync(string type)
        {
            return Task.FromResult(GetHeroes(type));
        }

        private IEnumerable<DOTAHero> GetHeroes(string type)
        {
            HeroManager HM = new HeroManager();
            return HM.GetHeroesByType(type);
        }
    }
}
