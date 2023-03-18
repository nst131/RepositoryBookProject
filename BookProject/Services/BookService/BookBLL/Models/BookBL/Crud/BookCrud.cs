using BookBLL.Interfaces;
using BookBLL.Models.BookBL.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace BookBLL.Models.BookBL.Crud
{
    public class BookCrud : IBookCrud
    {
        public readonly ICreater<AcceptCreateBookDtoBL> creater;
        public readonly IUpdater<AcceptUpdateBookDtoBL> updater;
        public readonly IRemover<AcceptRemoveBookDtoBL> remover;

        public BookCrud(
            ICreater<AcceptCreateBookDtoBL> creater,
            IUpdater<AcceptUpdateBookDtoBL> updater,
            IRemover<AcceptRemoveBookDtoBL> remover)
        {
            this.creater = creater;
            this.updater = updater;
            this.remover = remover;
        }

        public async Task Create(AcceptCreateBookDtoBL dto, CancellationToken token = default)
            => await this.creater.Create(dto, token);

        public async Task Update(AcceptUpdateBookDtoBL dto, CancellationToken token = default)
            => await this.updater.Update(dto, token);

        public async Task Delete(AcceptRemoveBookDtoBL dto, CancellationToken token = default)
          => await this.remover.Remove(dto, token);
    }
}
