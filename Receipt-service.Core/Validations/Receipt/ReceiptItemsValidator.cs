using System.Linq;

namespace Receipt_service.Core.Validations.Receipt
{
    public class ReceiptItemsValidator : IReceiptValidator
    {
        public bool IsValid(Models.Receipt receipt)
        {
            return !receipt.ReceiptItems.Any();
        }
    }
}