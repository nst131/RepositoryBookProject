using System.Threading.Tasks;
using System.Threading;

namespace BookBLL.Interfaces
{
    public interface ICreater<CreateDto>
        where CreateDto : class
    {
        Task<int> Create(CreateDto createDto, CancellationToken token = default);
    }
}