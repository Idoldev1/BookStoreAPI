using AutoMapper;
using BookStoreAPI.DTOs;
using BookStoreAPI.Models;

namespace BookStoreAPI.Autoapper;


public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Book, BookDto>();
        CreateMap<BookDto, Book>();
        CreateMap<BookInputDto, Book>();
    }
}