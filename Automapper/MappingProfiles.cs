using AutoMapper;
using BookStoreAPI.DTOs;
using BookStoreAPI.Models;

namespace BookStoreAPI.Autoapper;


public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Book, GetBookDto>();
        CreateMap<GetBookDto, Book>();
        CreateMap<AddBookDto, Book>();
    }
}