using AutoMapper;
using BookBLL.Interfaces;
using BookBLL.Models.BookBL.Dto;
using BookDAL.Context;
using BookDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookBLL.Models.BookBL.Fetchers
{
    public class BookFetchers : IBookFetchers
    {
        private readonly IBookContext context;
        private readonly IMapper mapper;

        public BookFetchers(
            IBookContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ResponseGetBookDtoBL> Get(int id, CancellationToken token = default)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException($"Id {nameof(Book)} is less 0");

            var book = await this.context.Set<Book>()
                .Include(x => x.Genre)
                .Include(x => x.Author)
                .FirstOrDefaultAsync(x => x.Id.Equals(id), token);

            return this.mapper.Map<ResponseGetBookDtoBL>(book);
        }

        public async Task<ICollection<ResponseGetBookDtoBL>> GetAll(CancellationToken token = default)
        {
            if (!await this.context.Set<Book>().AnyAsync(token))
                return new List<ResponseGetBookDtoBL>();

            var allBooks = await this.context.Set<Book>()
                .Include(x => x.Genre)
                .Include(x => x.Author)
                .ToListAsync(token);

            return allBooks.Select(x => this.mapper.Map<ResponseGetBookDtoBL>(x)).ToList();
        }

        public async Task<ResponseGetBookDtoBL> GetByISBN(string isbn, CancellationToken token = default)
        {
            var book = await this.context.Set<Book>()
                .Include(x => x.Genre)
                .Include(x => x.Author)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ISBN.Equals(isbn), token);

            if (book is null)
                throw new NullReferenceException($"{nameof(Book)} by ISBN not Found");

            return this.mapper.Map<ResponseGetBookDtoBL>(book);
        }
    }
}
