using System;
using IPEdge.Core.Domain;

namespace IPEdge.Core.Interface
{
	public interface IRepository<T> where T : BaseEntity
	{
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
        Task<List<T>> GetAll(int page, int pageSize);
        T GetById(int id);
    }
}

