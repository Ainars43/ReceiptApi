using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Receipt_service.Core.Models;

namespace Receipt_service.Data
{
    public interface IReceiptServiceDbContext
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        DbSet<Receipt> Receipts { get; set; }
        DbSet<Item> Items { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}