using Receipt_service.Core.Interfaces;
using Receipt_service.Core.Models;
using Receipt_service.Data;
using System.Linq;

namespace Receipt_service.Services
{
    public class ItemService : EntityService<Item>, IItemService
    {
        public ItemService(IReceiptServiceDbContext context) : base(context)
        {
        }

        public bool IsProductNameExists(string name)
        {
            return Query().Any(n => n.ProductName == name);
        }
    }
}