using BookStoreAPI.Models;

namespace BookStoreAPI.Repository;

public interface IOrderRepository
{
    Order GetOrderById(int orderId, bool trackChanges);
    IEnumerable<Order> GetAllOrders(bool trackChanges);
    void AddOrder(Order order);
    void DeleteOrder(Order order);
    bool SaveMethod();
}