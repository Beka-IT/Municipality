using Municipality.Contracts;
using Municipality.Data;
using Municipality.Entities;

namespace Municipality.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext context) 
        { 
            _db = context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _db.Users.SingleOrDefault(x => x.Pin == username && x.Password == password));

            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => _db.Users.ToArray());
        }
    }
}
