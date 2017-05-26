using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyAlkoholShelf.Entity;

namespace MyAlcoholShelf.Services
{
    public class TmpRepo : IReadRepository
    {
        private EntityAlkoholShelfContext context;
        private readonly DbSet<User> _users;

        public TmpRepo(EntityAlkoholShelfContext context)
        {
            this.context = context;
            _users = context.Set<User>();
        }

        public IQueryable<T> Query<T>()
        {
            return (IQueryable<T>) _users.AsQueryable();
        }

        public T Get<T>(long id)
        {
            throw new NotImplementedException();
        }
    }
}
