using PlaneSpotterApi.Models;

namespace PlaneSpotterApi.Repositories
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);
        Task<User> Register(User user, string password);
        Task<User> GetById(int id);
    }
}
