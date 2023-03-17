using System.Threading.Tasks;
using System.Threading;

namespace BookBLL.Interfaces
{
    public interface IUpdater<UpdateDto>
       where UpdateDto : class
    {
        Task Update(UpdateDto updateDto, CancellationToken token = default);
    }
}