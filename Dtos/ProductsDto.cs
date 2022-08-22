namespace ShoppingList.Dtos
{
    public class ProductsDto
    {
        public int Id { get; set; }
        public string NameOfProducts { get; set; }
        public int Price { get; set; }
        public IFormFile Image { get; set; }
        public int IdSupermarket { get; set; }
        public int IdListShop { get; set; }
    }
}
