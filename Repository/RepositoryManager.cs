using BookStoreAPI.DAL;
using BookStoreAPI.Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly BookStoreDbContext _bookStoreDb;
    private readonly Lazy<IBookstoreRepository> _bookstoreRepository;
    private readonly Lazy<IOrderRepository> _orderRepository;

    public RepositoryManager(BookStoreDbContext bookStoreDb)
    {
        _bookStoreDb = bookStoreDb;
        _bookstoreRepository = new Lazy<IBookstoreRepository>(() => new BookstoreRepository(bookStoreDb));
        _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(bookStoreDb));
    }



    public IBookstoreRepository BookstoreRepository => _bookstoreRepository.Value;

    public IOrderRepository OrderRepository => _orderRepository.Value;

    public void Save() => _bookStoreDb.SaveChanges();
}
