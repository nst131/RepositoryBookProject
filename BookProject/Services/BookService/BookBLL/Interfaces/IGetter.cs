using System.Threading.Tasks;
using System.Threading;

namespace BookBLL.Interfaces
{
    public interface IGetter<DtoGetResponse> where DtoGetResponse : class
    {
        Task<DtoGetResponse> Get(int id, CancellationToken token = default);
    }
}