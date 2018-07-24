using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Models
{
    public class HeroStats
    {
        private HeroManager _manager = new HeroManager();

        public async Task<int> GetHeroCount()
        {
            return await Task.FromResult(_manager.GetAll.Count());
        }

        public async Task<int> GetHeroCountByType(string type)
        {
            return await Task.FromResult(_manager.GetHeroesByType(type).Count);
        }
    }
}
