using ShoppingList.Entities;
using ShoppingList.Repositories;

namespace ShoppingList.Services
{
    public interface ISupermarketService
    {
        Supermarket CreateSupermarket(Supermarket supermarket);
        Supermarket DeleteSupermarket(Supermarket supermarket);
        List<Supermarket> GetAllSupermarkets();
    }
    public class SupermarketService : ISupermarketService
    {
        private readonly ISupermarketRepository _supermarketRepository;

        public SupermarketService(ISupermarketRepository supermarketRepository)
        {
            _supermarketRepository = supermarketRepository;
        }
        public Supermarket CreateSupermarket(Supermarket supermarket)
        {
            _supermarketRepository.CreateSupermarket(supermarket);
            return supermarket;
        }
        public Supermarket DeleteSupermarket(Supermarket supermarket)
        {
            _supermarketRepository.DeleteSupermarket(supermarket);
            return supermarket;
        }
        public List<Supermarket> GetAllSupermarkets()
        {
            var super = _supermarketRepository.GetAllSupermarket();
            return super;
        }
    }
}
