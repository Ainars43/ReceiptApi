using System;
using System.Collections.Generic;
using Moq;
using Receipt_service.Core.Models;
using Xunit;
using FluentAssertions;
using Receipt_service.Core.Validations.Receipt;
using Assert = Xunit.Assert;


namespace Receipt_service.Tests
{
    public class ReceiptCreateTests
    {
        private readonly ReceiptItemsValidator _validator = new ReceiptItemsValidator();

        [Fact]
        public void ValidReceipt_SetCreatedOnDateTime_ReturnsTrue()
        {
            var mock = new Mock<DateTimeProvider>();
            mock.Setup(t => t.Now).Returns(new DateTime(2022, 11, 3));

            var receipt = new Receipt(mock.Object);

            Assert.Equal(new DateTime(2022, 11, 3), receipt.CreatedOn);
        }

        [Fact]
        public void ValidReceipt_ItemsListIsEmpty_ReturnTrue()
        {
            var mock = new Mock<DateTimeProvider>();
            mock.Setup(t => t.Now).Returns(new DateTime(2022, 11, 3));

            var receipt = new Receipt(mock.Object);
            receipt.ReceiptItems = new List<Item>();

            _validator.IsValid(receipt).Should().BeTrue();
        }
    }
}