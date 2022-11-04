using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Receipt_service.Core.Interfaces;
using Receipt_service.Core.Models;
using Receipt_service.Core.Validations.Item;
using Receipt_service.Core.Validations.Receipt;

namespace Receipt_service.Controllers
{
    [Route("receipt-service")]
    [ApiController, EnableCors]
    public class ReceiptController : ControllerBase
    {
        private readonly object _locker = new object();
        private readonly IReceiptService _receiptService;
        private readonly IEnumerable<IReceiptValidator> _receiptValidator;
        private readonly IItemValidator _itemValidator;
        private readonly IItemService _itemService;

        public ReceiptController(IReceiptService receiptService, IEnumerable<IReceiptValidator> receiptValidator, IItemValidator itemValidator, IItemService itemService)
        {
            _receiptService = receiptService;
            _receiptValidator = receiptValidator;
            _itemValidator = itemValidator;
            _itemService = itemService;
        }

        [HttpPost]
        [Route("create-receipt")]
        public IActionResult AddReceipt(Receipt receipt)
        {
            if (!_receiptValidator.Any(r => r.IsValid(receipt)))
            {
                return BadRequest();
            }

            if (_receiptService.IsReceiptExists(receipt))
            {
                return Conflict();
            }

            lock (_locker)
            {
                _receiptService.Create(receipt);

                return Created("", receipt);
            }
        }

        [HttpGet]
        [Route("get-receipt")]
        public IActionResult GetReceipt(int id)
        {
            var receipt = _receiptService.GetReceiptById(id);

            if (receipt == null)
            {
                return NotFound();
            }

            return Ok(receipt);
        }

        [HttpDelete]
        [Route("delete-receipt")]
        public IActionResult DeleteReceipt(int id)
        {
            if (_receiptService.IsReceiptExists(id))
            {
                return NotFound();
            }

            lock (_locker)
            {
                _receiptService.DeleteReceiptById(id);

                return Ok();
            }
        }

        [HttpGet]
        [Route("get-all-receipts")]
        public IActionResult GetReceipts()
        {
            lock (_locker)
            {
                var receipts = _receiptService.GetAllReceipts();

                return Ok(receipts);
            }
        }

        [HttpGet]
        [Route("get-receipts-by-date")]
        public IActionResult GetReceiptsByDate(DateTime startTime
        , DateTime endTime)
        {
            if (!_receiptService.IsTimeValid(startTime) || !_receiptService.IsTimeValid(endTime))
            {
                return BadRequest();
            }

            lock (_locker)
            {
                var receipts = _receiptService.GetReceiptsByDateRange(startTime, endTime);

                return Ok(receipts);
            }
        }

        [HttpGet]
        [Route("get-receipts-by-product-name")]
        public IActionResult GetReceiptsByProductName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                BadRequest();
            }

            if (!_itemService.IsProductNameExists(name))
            {
                return NotFound();
            }

            lock (_locker)
            {
                var receipts = _receiptService.GetReceiptsByItemProductName(name);

                return Ok(receipts);
            }
        }
    }
}
