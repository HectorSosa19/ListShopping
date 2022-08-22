using ShoppingList.Entities;
using ShoppingList.Repositories;

namespace ShoppingList.Services
{
    public interface IBrandService
    {
        Brand CreateBrand(Brand brand);
        Brand DeleteBrand(Brand brand);
        List<Brand> GetAllBrands();
    }
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public Brand CreateBrand(Brand brand)
        {
            _brandRepository.CreateBrand(brand);
            return brand;
        }
        public Brand DeleteBrand(Brand brand)
        {
            _brandRepository.DeleteBrand(brand);
            return brand;
        }
        public List<Brand> GetAllBrands()
        {
            var brand = _brandRepository.GetAllBrand();
            return brand;
        }
    }
}
