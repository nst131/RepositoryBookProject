using System.Threading;
using System.Threading.Tasks;

namespace BookBLL.Interfaces
{
    public interface IRemover<AcceptDto> where AcceptDto : class, IRemoverDto
    {
        Task<int> Remove(AcceptDto dto, CancellationToken token = default);
    }
}