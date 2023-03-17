using BookBLL.Attributes;
using BookBLL.BaseCrud;
using BookBLL.Interfaces;
using BookBLL.Models.BookBL.Crud;
using BookBLL.Models.BookBL.Dto;
using BookBLL.Models.BookBL.Fetchers;
using BookBLL.Models.BookBL.Validation;
using BookDAL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BookBLL
{
    public static class ServiceRegistrationBL
    {
        public static void RegistrationBL(this IServiceCollection services)
        {
            services.AddScoped<IUniqueISBN, UniqueISBN>();

            services.AddScoped<IBookCrud, BookCrud>();
            services.AddScoped<IBookFetchers, BookFetchers>();
            services.AddScoped<ICreater<AcceptCreateBookDtoBL>, Creater<Book, AcceptCreateBookDtoBL>>();
            services.AddScoped<IValidator<AcceptCreateBookDtoBL>, CreateBookValidatorBL>();
            services.AddScoped<IUpdater<AcceptUpdateBookDtoBL>, Updater<Book, AcceptUpdateBookDtoBL>>();
            services.AddScoped<IValidator<AcceptUpdateBookDtoBL>, UpdateBookValidatorBL>();
            services.AddScoped<IRemover<AcceptRemoveBookDtoBL>, Remover<Book, AcceptRemoveBookDtoBL>>();
        }
    }
}
