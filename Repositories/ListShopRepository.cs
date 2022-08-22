using ShoppingList.Context;
using ShoppingList.Entities;

namespace ShoppingList.Repositories
{
    public interface IListRepository
    {
        ListShop CreateListShop(ListShop list);
        ListShop DeleteListShop(ListShop list);
        List<ListShop> GetAllList();

    }
    public class ListShopRepository : IListRepository 
    {
        public static List<ListShop> listshop = new List<ListShop>()
        {

        };
        private readonly ContextShop _context;

        public ListShopRepository(ContextShop context)
        {
            _context = context;
        }
        public ListShop CreateListShop(ListShop list)
        {
            _context.ListShop.Add(list);
            _context.SaveChanges();
            return list;
        }
        public ListShop DeleteListShop(ListShop list)
        {
            _context.ListShop.Remove(list);
            _context.SaveChanges();
            return null;
        }
        public List<ListShop> GetAllList()
        {
            return _context.ListShop.ToList();
        }
    }
}
