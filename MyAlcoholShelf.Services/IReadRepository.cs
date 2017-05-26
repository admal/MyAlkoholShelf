using System.Linq;

namespace MyAlcoholShelf.Services
{
    public interface IReadRepository
    {
        IQueryable<T> Query<T>();
        T Get<T>(long id);
    }
}
