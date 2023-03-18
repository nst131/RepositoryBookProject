using BookBLL.Models.BookBL.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace BookBLL.Models.BookBL.Crud
{
    public interface IBookCrud
    {
        Task Create(AcceptCreateBookDtoBL dto, CancellationToken token = default);
        Task Delete(AcceptRemoveBookDtoBL dto, CancellationToken token = default);
        Task Update(AcceptUpdateBookDtoBL dto, CancellationToken token = default);
    }
}