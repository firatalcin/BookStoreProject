using AutoMapper;
using Core.DTOs;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Book, BookAddDto>().ReverseMap();
            CreateMap<Book, BookListDto>().ReverseMap();
            CreateMap<Book, BookUpdateDto>().ReverseMap();

            CreateMap<Author, AuthorAddDto>().ReverseMap();
            CreateMap<Author, AuthorListDto>().ReverseMap();
            CreateMap<Author, AuthorUpdateDto>().ReverseMap();

            CreateMap<Genre, GenreAddDto>().ReverseMap();
            CreateMap<Genre, GenreListDto>().ReverseMap();
            CreateMap<Genre, GenreUpdateDto>().ReverseMap();

            CreateMap<User, UserAddDto>().ReverseMap();
            CreateMap<User, UserListDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();

            CreateMap<Order, OrderAddDto>().ReverseMap();
            CreateMap<Order, OrderListDto>().ReverseMap();
            CreateMap<Order, OrderUpdateDto>().ReverseMap();
        }
    }
}