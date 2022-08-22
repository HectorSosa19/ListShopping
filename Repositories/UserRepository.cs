using ShoppingList.Context;
using ShoppingList.Entities;

namespace ShoppingList.Repositories
{
    public interface IUserRepository 
    {
        User CreateUser(User user);
        User DeleteUser(User user);
        List<User> GetAllUser();
    }
    public class UserRepository :IUserRepository
    {
        public static List<User> users = new List<User>()
        {

        };
        private readonly ContextShop _context;

        public UserRepository(ContextShop context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User DeleteUser(User user)
        {
            _context.User.Remove(user);
            _context.SaveChanges();
            return null;
        }
        public List<User> GetAllUser()
        {
            return _context.User.ToList();
        }

    }
}
