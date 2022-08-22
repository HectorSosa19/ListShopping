using ShoppingList.Context;
using ShoppingList.Entities;

namespace ShoppingList.Repositories
{
    public interface IBrandRepository
    {
        Brand CreateBrand(Brand brand);
        Brand DeleteBrand(Brand brand);
        List<Brand> GetAllBrand();
    };
    public class BrandRepository : IBrandRepository
    {
        public static List<Brand> brands = new List<Brand>()
        {

        };
        private readonly ContextShop _context;

        public BrandRepository(ContextShop context)
        {
            _context = context;
        }
        public Brand CreateBrand(Brand brand)
        {
            _context.Brand.Add(brand);
            _context.SaveChanges();
            return brand;
        }
        public Brand DeleteBrand(Brand brand)
        {
            _context.Brand.Remove(brand);
            _context.SaveChanges();
            return null;
        }
        public List<Brand> GetAllBrand()
        {
            return _context.Brand.ToList();
        }
    }
}
