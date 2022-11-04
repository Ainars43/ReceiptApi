using Receipt_service.Core.Models;
using System;
using System.Collections.Generic;

namespace Receipt_service.Core.Interfaces
{
    public interface IReceiptService : IEntityService<Receipt>
    {
        Receipt GetReceiptById(int id);
        void DeleteReceiptById(int id);
        List<Receipt> GetAllReceipts();
        List<Receipt> GetReceiptsByDateRange(DateTime startTime, DateTime endTime);
        List<Receipt> GetReceiptsByItemProductName(string name);
        bool IsReceiptExists(Receipt receipt);
        bool IsReceiptExists(int id);
        bool IsTimeValid(DateTime time);
    }
}