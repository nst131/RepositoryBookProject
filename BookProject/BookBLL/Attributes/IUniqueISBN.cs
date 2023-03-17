using System.Threading.Tasks;

namespace BookBLL.Attributes
{
    public interface IUniqueISBN
    {
        Task<bool> IsUniqueAtCreate(string ISBN);
        Task<bool> IsUniqueAtUpdate(string ISBN, int exceptId);
    }
}