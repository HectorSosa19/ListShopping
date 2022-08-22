using ShoppingList.Entities;
using ShoppingList.Repositories;

namespace ShoppingList.Services
{
    public interface IOrderService
    {
        Order CreateOrder(Order order);
        Order DeleteOrder(Order order);
        List<Order> GetAllOrders();
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository OrderRepository )
        {
            _orderRepository = OrderRepository;
        }
        public Order CreateOrder(Order order)
        {
            _orderRepository.CreateOrder(order);
            return order;

        }
        public Order DeleteOrder(Order order)
        {
            _orderRepository.DeleteOrder(order);
            return order;
        }
        public List<Order> GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrder();
            return orders;
        }
    }
}
