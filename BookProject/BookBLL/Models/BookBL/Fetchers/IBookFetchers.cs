using BookBLL.Models.BookBL.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookBLL.Models.BookBL.Fetchers
{
    public interface IBookFetchers
    {
        Task<ResponseGetBookDtoBL> Get(int id, CancellationToken token = default);
        Task<ICollection<ResponseGetBookDtoBL>> GetAll(CancellationToken token = default);
        Task<ResponseGetBookDtoBL> GetByISBN(string isbn, CancellationToken token = default);
    }
}