using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Receipt_service.Core.Models;

namespace Receipt_service.Data
{
    public class ReceiptServiceDbContext : DbContext, IReceiptServiceDbContext
    {
        public ReceiptServiceDbContext() { }

        public ReceiptServiceDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}