using ShoppingList.Context;
using ShoppingList.Entities;

namespace ShoppingList.Repositories
{
    public interface ISupermarketRepository
    {
        Supermarket CreateSupermarket(Supermarket super);

        Supermarket DeleteSupermarket(Supermarket super);
        List<Supermarket> GetAllSupermarket();

    }
    public class SupermarketRepository : ISupermarketRepository
    {
        public static List<Supermarket> supermarket = new List<Supermarket>
        {

        };
        private readonly ContextShop _context;

        public SupermarketRepository(ContextShop context)
        {
            _context = context;
        }
        public Supermarket CreateSupermarket(Supermarket super)
        {
            _context.Supermarket.Add(super);
            _context.SaveChanges();
            return super;
        }
        public Supermarket DeleteSupermarket(Supermarket super)
        {
            _context.Supermarket.Remove(super);
            _context.SaveChanges();
            return null;
        }
        public List<Supermarket> GetAllSupermarket()
        {
           return _context.Supermarket.ToList();
        }
    }
}
