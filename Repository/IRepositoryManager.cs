namespace BookStoreAPI.Repository;


public interface IRepositoryManager
{
    IBookstoreRepository BookstoreRepository { get; }
    IOrderRepository OrderRepository { get; }

    void Save();
}