using System;
using System.Collections.Generic;

namespace Receipt_service.Core.Models
{
    public class Receipt : Entity
    {
        public Receipt(DateTimeProvider dateTimeProvider)
        {
            CreatedOn = dateTimeProvider.Now;
        }

        public DateTime CreatedOn { get; }
        public List<Item> ReceiptItems { get; set; }
    }
}