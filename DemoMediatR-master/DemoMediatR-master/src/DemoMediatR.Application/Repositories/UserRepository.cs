using System.Threading.Tasks;
using DemoMediatR.Application.Domain.Interfaces;
using DemoMediatR.Application.Domain.Models;

namespace DemoMediatR.Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task Save(User user)
        {
            // logic to write to database

            return Task.CompletedTask;
        }
    }
}