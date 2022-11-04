using Receipt_service.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Receipt_service.Core.Interfaces
{
    public interface IEntityService<T> where T : Entity
    {
        IQueryable<T> Query();
        IEnumerable<T> Get();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}