using DataAccess.Contexts;
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
        }
    }
}