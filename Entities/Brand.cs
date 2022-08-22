using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Entities
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string NameOfBrand { get; set; }
        public int IdListShop { get; set; }
        [ForeignKey("IdListShop")]
        public ListShop ListShops { get; set; }
        public int IdSupermarket { get; set; }
        [ForeignKey("IdSupermarket")]
        public Supermarket Supermarkets { get; set; }
       
        public ICollection<Products> Products { get; set; }
        
    }
}
