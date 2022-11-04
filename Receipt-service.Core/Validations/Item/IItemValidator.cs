namespace Receipt_service.Core.Validations.Item
{
    public interface IItemValidator
    {
        public bool IsValid(Models.Item item);
    }
}