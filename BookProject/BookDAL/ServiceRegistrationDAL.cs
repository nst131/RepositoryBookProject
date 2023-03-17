using BookDAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookDAL
{
    public static class ServiceRegistrationDAL
    {
        public static void RegistrationDAL(this IServiceCollection services, string connectionString) 
        {
            services.AddDbContext<BookContext>(option => option.UseSqlServer(connectionString));
            services.AddScoped<IBookContext, BookContext>();
        }
    }
}
