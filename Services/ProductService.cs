using ShoppingList.Entities;
using ShoppingList.Repositories;

namespace ShoppingList.Services
{
    public interface IProductService
    {
        Products CreateProduct(Products product);
        Products DeleteProduct(Products product);
        List<Products> GetAllProducts();
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Products CreateProduct(Products product)
        {
            _productRepository.CreateProduct(product);
            return product;
        }
        public Products DeleteProduct(Products product)
        {
            _productRepository.DeleteProduct(product);
            return product;
        }
        public List<Products> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            return products;
        }
    }
}
