using BookStoreAPI.Models;
using BookStoreAPI.Repository;

namespace BookStoreAPI.Services;



public class OrderServices : IOrderServices
{
    private readonly IRepositoryManager _orderRepository;

    public OrderServices(IRepositoryManager orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public Order AddOrder(Order order)
    {
        _orderRepository.OrderRepository.AddOrder(order);
        _orderRepository.Save();

        return order;
    }

    public void DeleteOrder(int Id, bool trackChanges)
    {
        var order = _orderRepository.OrderRepository.GetOrderById(Id, trackChanges);
        if (order is null)
                throw new Exception("Order details cannot be found");

        _orderRepository.OrderRepository.DeleteOrder(order);
        _orderRepository.Save();
    }

    public IEnumerable<Order> GetAllOrders()
    {
        throw new NotImplementedException();
    }

    public Order GetOrder(int Id, bool trackChanges)
    {
        var order = _orderRepository.OrderRepository.GetOrderById(Id, trackChanges);

        return order;
    }
}