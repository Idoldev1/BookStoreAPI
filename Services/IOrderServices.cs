using BookStoreAPI.Models;

namespace BookStoreAPI.Services;



public interface IOrderServices
{
    IEnumerable<Order> GetAllOrders();
    Order GetOrder(int Id, bool trackChanges);
    Order AddOrder(Order order);
    void DeleteOrder(int Id, bool trackChanges);
    
}