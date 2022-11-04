using System;
using System.Collections.Generic;
using System.Linq;
using Receipt_service.Core.Interfaces;
using Receipt_service.Core.Models;
using Receipt_service.Data;

namespace Receipt_service.Services
{
    public class ReceiptService : EntityService<Receipt>, IReceiptService
    {
        public ReceiptService(IReceiptServiceDbContext context) : base(context)
        {
        }

        public Receipt GetReceiptById(int id)
        {
            return Query().SingleOrDefault(r => r.Id == id);
        }

        public void DeleteReceiptById(int id)
        {
            var receipt = GetReceiptById(id);

            if (receipt != null)
            {
                Delete(receipt);
            }
        }

        public List<Receipt> GetAllReceipts()
        {
            return _context.Receipts.ToList();
        }

        public List<Receipt> GetReceiptsByDateRange(DateTime startTime, DateTime endTime)
        {
            return Query().Where(t => t.CreatedOn >= startTime && t.CreatedOn <= endTime).ToList();
        }

        public List<Receipt> GetReceiptsByItemProductName(string name)
        {
            return Query().Where(n => n.ReceiptItems.Any(p => p.ProductName == name)).ToList();
        }

        public bool IsReceiptExists(Receipt receipt)
        {
            return Query().Any(r => r.CreatedOn == receipt.CreatedOn && r.ReceiptItems == receipt.ReceiptItems);
        }

        public bool IsReceiptExists(int id)
        {
            return _context.Receipts.Any(r => r.Id == id);
        }

        public bool IsTimeValid(DateTime time)
        {
            return !string.IsNullOrEmpty(time.ToString());
        }
    }
}