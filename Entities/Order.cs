using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int Total { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }

    }
}
