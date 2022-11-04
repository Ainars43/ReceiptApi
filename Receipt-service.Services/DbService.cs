using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Receipt_service.Core.Interfaces;
using Receipt_service.Core.Models;
using Receipt_service.Data;

namespace Receipt_service.Services
{
    public class DbService : IDbService
    {
        public readonly IReceiptServiceDbContext _context;
        public DbService(IReceiptServiceDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id == id);
        }

        public void Create<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}