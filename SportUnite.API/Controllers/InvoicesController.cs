using System;
using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;
using SportUnite.BLL;
using SportUnite.Domain.Models;

namespace SportUnite.API.Controllers
{
    [Produces("application/json")]
    [Route("api/invoices")]
    public class InvoicesController : Controller
    {
        private InvoiceManager _invoiceManager;

        public InvoicesController(InvoiceManager invoiceManager)
        {
            _invoiceManager = invoiceManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var invoicesFromRepo = _invoiceManager.Get();

            return Ok(invoicesFromRepo);
        }

        [HttpGet("{InvoiceId}", Name = "GetInvoice"), Route("{InvoiceId:int}")]
        public IActionResult Get(int invoiceId)
        {
            
            var invoiceFromRepo = _invoiceManager.Get(invoiceId);

            if (invoiceFromRepo == null)
            {
                return NotFound();
            }

            return Ok(invoiceFromRepo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Invoice invoice)
        {
            if (invoice == null)
            {
                return BadRequest();
            }
            if (!_invoiceManager.Save(invoice))
            {
                throw new Exception("Creating an invoice failed on save.");
            }
            return Ok(invoice);
        }

        [HttpDelete("{InvoiceId}")]
        public IActionResult Delete(int invoiceId)
        {
            var invoicesFromRepo = _invoiceManager.Get(invoiceId);
            if (invoicesFromRepo == null)
            {
                return NotFound();
            }
            if (!_invoiceManager.Delete(invoicesFromRepo))
            {
                throw new Exception($"Deleting invoice {invoiceId} failed on save.");
            }
            return NoContent();
        }

        [HttpPut("{InvoiceId}")]
        public IActionResult Put(int invoiceId, [FromBody] Invoice invoice)
        {
            var invoicesFromRepo = _invoiceManager.Get(invoiceId);
            if (invoicesFromRepo == null || invoice == null)
            {
                return NotFound();
            }
            if (invoice.Name != null)
            {
                invoicesFromRepo.Name = invoice.Name;
            }
            if (invoice.Availability != null)
            {
                invoicesFromRepo.Availability = invoice.Availability;
            }
            if (!_invoiceManager.Save(invoicesFromRepo))
            {
                throw new Exception($"Deleting invoice {invoiceId} failed on save.");
            }
            return Ok(invoicesFromRepo);
        }
    }
}