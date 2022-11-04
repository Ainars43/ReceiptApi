using FluentAssertions;
using Receipt_service.Core.Models;
using Receipt_service.Core.Validations.Item;
using Xunit;

namespace Receipt_service.Tests
{
    public class ItemCreateTests
    {
        private readonly ItemProductNameValidator _validator = new ItemProductNameValidator();

        [Fact]
        public void ValidItem_ProductNameIsNull_ReturnFalse()
        {
            var item = new Item()
            {
                ProductName = null
            };

            _validator.IsValid(item).Should().BeFalse();
        }

        [Fact]
        public void ValidItem_ProductNameIsEmpty_ReturnFalse()
        {
            var item = new Item()
            {
                ProductName = ""
            };

            _validator.IsValid(item).Should().BeFalse();
        }

        [Fact]
        public void ValidItem_ProductNameIsValid_ReturnTrue()
        {
            var item = new Item()
            {
                ProductName = "item"
            };

            _validator.IsValid(item).Should().BeTrue();
        }
    }
}