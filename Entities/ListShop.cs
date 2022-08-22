using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Entities
{
    public class ListShop
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public List<Products> Products { get; set; } 
        public List<Brand> Brands { get; set; }
        public List<Supermarket> Supermarkets { get; set; }
        
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}
