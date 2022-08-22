using AutoMapper;
using ShoppingList.Context;
using ShoppingList.Dtos;
using ShoppingList.Entities;
using ShoppingList.Repositories;

namespace ShoppingList.Services
{
    public interface IUserService 
    {
        User CreateUser(User user);
        User DeleteUser(User user);
        List<User> GetAllUser();
    } 
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) : base()
        {
            _userRepository = userRepository;
        }
        public User CreateUser(User user)
        {
            _userRepository.CreateUser(user);
            return user;
        }
        public User DeleteUser(User user)
        {
            _userRepository.DeleteUser(user);
            return user;
        }
        public List<User> GetAllUser()
        {
            var users = _userRepository.GetAllUser();
            return users;
        }
    }
}
