using System;
using IPEdge.Core.Domain;
using IPEdge.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace IPEdge.Infrastructure.Service
{
	public class Repository<T> : IRepository<T> where T : BaseEntity
	{
        private readonly IPEdgeDBContext _context;
        private DbSet<T> _entities;

		public Repository(IPEdgeDBContext context)
		{
            _context = context;
            _entities = _context.Set<T>();
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _entities.FirstOrDefault(x => x.Id == id);
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<T>> GetAll(int page = 1, int pageSize = int.MaxValue)
        {
            return _entities.Skip(page).Take(pageSize).ToList();
        }

        public T GetById(int id)
        {
            return _entities.FirstOrDefault(x => x.Id == id);
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _entities.Update(entity);
            _context.SaveChanges();
        }
    }
}

