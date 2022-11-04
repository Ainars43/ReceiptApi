namespace Receipt_service.Core.Validations.Receipt
{
    public interface IReceiptValidator
    {
        bool IsValid(Models.Receipt receipt);
    }
}