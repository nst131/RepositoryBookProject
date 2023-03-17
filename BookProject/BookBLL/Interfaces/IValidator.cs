using System.Threading.Tasks;

namespace BookBLL.Interfaces
{
    public interface IValidator<Entity>
        where Entity : class
    {
        Task Validate(Entity dto);
    }
}
