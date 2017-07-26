using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyAlkoholShelf.Entity;

namespace MyAlcoholShelf.Services
{
    public class MainRepository : IRepository, IReadRepository
    {
        private readonly EntityAlkoholShelfContext _context;

        public MainRepository(EntityAlkoholShelfContext context)
        {
            this._context = context;
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _context.Set<T>();
        }

        public T Get<T>(long id) where T : Entity
        {
            var entities = _context.Set<T>();
            return entities.FirstOrDefault(x => x.Id == id);
        }

        public void SaveOrUpdate<T>(T entity) where T : Entity
        {
            var entities = _context.Set<T>();
            if (entity.Id == 0)
            {
                entities.Add(entity);
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            var entities = _context.Set<T>();
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(IEnumerable<T> entities) where T : Entity
        {
            var allEntities = _context.Set<T>();
            allEntities.RemoveRange(entities);
            _context.SaveChanges();
        }

        public void SoftDelete<T>(T entity) where T : Entity, ISoftDeletable
        {
            entity.IsDeleted = true;
            SaveOrUpdate(entity);
        }
    }
}
