using ShoppingList.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public UserRoles UserRoles { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public char Gender { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<ListShop> ListShops { get; set; }
        public List<Order> Orders { get; set; }
    }
}
