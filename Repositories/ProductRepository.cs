using ShoppingList.Context;
using ShoppingList.Entities;

namespace ShoppingList.Repositories
{
    public interface IProductRepository
    {
        Products CreateProduct(Products product);
        Products DeleteProduct(Products product);
        List<Products> GetAllProducts();
    }
    public class ProductRepository : IProductRepository
    {
        public static List<Products> products = new List<Products>()
        {

        };
        private readonly ContextShop _context;

        public ProductRepository(ContextShop context)
        {
            _context = context;
        }
        public Products CreateProduct(Products product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
            return product;
        }
        public Products DeleteProduct(Products product)
        {
            _context.Product.Remove(product);
            _context.SaveChanges();
            return null;
        }
        public List<Products> GetAllProducts()
        {
            return _context.Product.ToList();
        }
    }
}
