namespace ShoppingList.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
    }
}
