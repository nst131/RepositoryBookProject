using BookDAL.Context;
using BookDAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookBLL.Attributes
{
    public class UniqueISBN : IUniqueISBN
    {
        public readonly IBookContext context;

        public UniqueISBN(IBookContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsUniqueAtCreate(string ISBN)
        {
            return !await this.context.Set<Book>().AnyAsync(x => x.ISBN.Equals(ISBN));
        }

        public async Task<bool> IsUniqueAtUpdate(string ISBN, int exceptId)
        {
            return !await this.context.Set<Book>().AnyAsync(x => x.ISBN.Equals(ISBN) && x.Id != exceptId); 
        }
    }
}
