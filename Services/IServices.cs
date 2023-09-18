namespace BookStoreAPI.Services;


public interface IServices
{
    IBookServices BookServices { get;}
    IOrderServices OrderServices{ get;}
}