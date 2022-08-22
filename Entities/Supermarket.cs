using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Entities
{
    public class Supermarket
    {
        [Key]
        public int Id { get; set; }
        public string NameOfSupermarket { get; set; }
        public List<Products> Products { get; set; }
        public List<Brand> Brands { get; set; }
        public int IdListShop { get; set; }
        [ForeignKey("IdListShop")]
        public ListShop ListShop { get; set; }
    }
}
