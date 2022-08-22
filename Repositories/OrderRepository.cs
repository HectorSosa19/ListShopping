using ShoppingList.Context;
using ShoppingList.Entities;

namespace ShoppingList.Repositories
{
    public interface IOrderRepository
    {
        Order CreateOrder(Order order);
        Order DeleteOrder(Order order);
        List<Order> GetAllOrder();
    }
    public class OrderRepository : IOrderRepository
    {
        public static List<Order> order = new List<Order>()
        {
            

        };
        private readonly ContextShop _context;

        public OrderRepository(ContextShop context)
        {
            _context = context;
        }

        public Order CreateOrder(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
            return order;
        } 
        public Order DeleteOrder(Order order)
        {
            _context.Order.Remove(order);
            _context.SaveChanges();
            return null;
        }
        public List<Order> GetAllOrder()
        {
            return _context.Order.ToList();
        }
    }
}
