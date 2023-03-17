using BookBLL.Interfaces;
using BookBLL.Models.BookBL.Dto;
using BookDAL.Context;
using BookDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BookBLL.Models.BookBL.Validation
{
    public class UpdateBookValidatorBL : IValidator<AcceptUpdateBookDtoBL>
    {
        public readonly IBookContext context;

        public UpdateBookValidatorBL(IBookContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptUpdateBookDtoBL dto)
        {
            if (dto is null)
                throw new NullReferenceException($"{nameof(AcceptCreateBookDtoBL)} is null");

            if (!await this.context.Set<Book>().AnyAsync(x => x.Id.Equals(dto.Id)))
                throw new NullReferenceException($"{nameof(Book)} is not exist");

            if (string.IsNullOrEmpty(dto.Name))
                throw new NullReferenceException($"{nameof(dto.Name)} cann't be empty");

            if (string.IsNullOrEmpty(dto.Description))
                throw new NullReferenceException($"{nameof(dto.Description)} cann't be empty");

            if (string.IsNullOrEmpty(dto.ISBN))
                throw new NullReferenceException($"{nameof(dto.ISBN)} cann't be empty");

            if (string.IsNullOrEmpty(dto.IBAN))
                throw new NullReferenceException($"{nameof(dto.IBAN)} cann't be empty");

            if (!await this.context.Set<Genre>().AnyAsync(x => x.Id.Equals(dto.GenreId)))
                throw new NullReferenceException($"{nameof(Genre)} is not exist");

            if (!await this.context.Set<Author>().AnyAsync(x => x.Id.Equals(dto.AuthorId)))
                throw new NullReferenceException($"{nameof(Author)} is not exist");
        }
    }
}
