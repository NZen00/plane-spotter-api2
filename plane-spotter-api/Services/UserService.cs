using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using PlaneSpotterApi.Repositories;
using PlaneSpotterApi.Models;

namespace PlaneSpotterApi.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            return await _repository.Authenticate(username, password);
        }

        public async Task<User> Register(User user, string password)
        {
            return await _repository.Register(user, password);
        }

        public async Task<User> GetById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
