using Business.Managers;
using Business.Services;
using DataAccess.Abstract.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Contexts;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DependencyResolver
{
    public static class DependencyExtension
    {
        public static void AddDependency(this IServiceCollection services)
        {
            services.AddDbContext<BookStoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration.ConnectionString);
            });

            services.AddScoped<IAuthorDal, AuthorDal>();
            services.AddScoped<IBookDal, BookDal>();
            services.AddScoped<IGenreDal, GenreDal>();
            services.AddScoped<IUserDal, UserDal>();
            services.AddScoped<IOrderDal, OrderDal>();

            services.AddScoped<IAuthorService, AuthorManager>();
            services.AddScoped<IBookService, BookManager>();
            services.AddScoped<IGenreService, GenreManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IUserService, UserManager>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
        }
    }
}