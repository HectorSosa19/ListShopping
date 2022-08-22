using ShoppingList.Entities;
using ShoppingList.Repositories;

namespace ShoppingList.Services
{
    public interface IListShopService
    {
        ListShop CreateListShop(ListShop list);
        ListShop DeleteListShop(ListShop list);
        List<ListShop> GetAllList();
    }
    public class ListShopService : IListShopService
    {
        private readonly IListRepository _listRepository;

        public ListShopService(IListRepository listRepository )
        {
            _listRepository = listRepository;
        }
        public ListShop CreateListShop(ListShop list)
        {
            _listRepository.CreateListShop(list);
            return list;
        } 
        public ListShop DeleteListShop(ListShop list)
        {
            _listRepository.DeleteListShop(list);
            return list;
        }
        public List<ListShop> GetAllList()
        {
            var lists = _listRepository.GetAllList();
            return lists;
        }
    }
}
