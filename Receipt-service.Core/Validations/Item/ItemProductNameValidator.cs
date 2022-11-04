namespace Receipt_service.Core.Validations.Item
{
    public class ItemProductNameValidator : IItemValidator
    {
        public bool IsValid(Models.Item item)
        {
            return !string.IsNullOrEmpty(item.ProductName);
        }
    }
}