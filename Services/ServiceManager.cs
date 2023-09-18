using AutoMapper;
using BookStoreAPI.Repository;
using BookStoreAPI.Sevices;

namespace BookStoreAPI.Services;


public sealed class ServiceManager : IServices
{
    private readonly Lazy<IBookServices> _bookServices;
    private readonly Lazy<IOrderServices> _orderServices;
    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _bookServices = new Lazy<IBookServices>(() => new BookServices(repositoryManager, mapper));
        _orderServices = new Lazy<IOrderServices>(() => new OrderServices(repositoryManager));
    }

    public IBookServices BookServices => _bookServices.Value;

    public IOrderServices OrderServices => _orderServices.Value;
}