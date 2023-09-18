using BookStoreAPI.DAL;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repository;


public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(BookStoreDbContext context) : base(context)
    {
    }

    public void AddOrder(Order order) => Add(order);

    public void DeleteOrder(Order order) => Delete(order);

    public IEnumerable<Order> GetAllOrders(bool trackChanges)
    {
        return FindAll(trackChanges).OrderBy(x => x.OrderItems).ToList();
    }

    public Order GetOrderById(int orderId, bool trackChanges)
    {
        return GetById(x => x.Id.Equals(orderId), trackChanges).SingleOrDefault();
    }

    public bool SaveMethod() => Save();
}