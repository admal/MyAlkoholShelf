using System.Linq;
using MyAlkoholShelf.Entity;

namespace MyAlcoholShelf.Services
{
    public interface IReadRepository
    {
        IQueryable<T> Query<T>() where T : Entity;
        T Get<T>(long id) where T : Entity;
    }

    public interface IRepository : IReadRepository
    {
        void SaveOrUpdate<T>(T entity) where T : Entity;
        void Delete(long id);
        void SoftDelete<T>(T entity) where T : Entity, ISoftDeletable;
    }
}
