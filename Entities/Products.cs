using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Entities
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string NameOfProducts { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public int IdSupermarket { get; set; }
        [ForeignKey("IdSupermarket")]
        public Supermarket Supermarket { get; set; }
        public int IdListShop { get; set; }
        [ForeignKey("IdListShop")]
        public ListShop ListShop { get; set; }
    }
}
