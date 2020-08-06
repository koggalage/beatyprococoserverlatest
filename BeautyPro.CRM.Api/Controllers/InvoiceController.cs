﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyProCRM.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyPro.CRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : BeautyProBaseController
    {
        private readonly ICustomerScheduleTreatmentService _customerScheduleTreatmentService;
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(
            IHttpContextAccessor httpContextAccessor,
            ICustomerScheduleTreatmentService customerScheduleTreatmentService,
            IInvoiceService invoiceService) : base(httpContextAccessor)
        {
            _customerScheduleTreatmentService = customerScheduleTreatmentService;
            _invoiceService = invoiceService;
        }

        [HttpGet("treatments")]
        public IActionResult GetCustomerInvoiceableTreatments([FromQuery]InvoiceTreatmentRequest request)
        {
            return Ok(_customerScheduleTreatmentService.GetInvoiceableScheduledTreatments(request));
        }

        [HttpPost("save")]
        public IActionResult SaveInvoice([FromBody]InvoiceSaveRequest request)
        {
            try
            {          
                return Ok(_invoiceService.SaveInvoice(request, BranchId, UserId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("invoice-discount")]
        [Authorize]
        public IActionResult ApplyDiscount([FromBody]InvoiceDiscountRequest request)
        {
            try
            {
                var canApply = _invoiceService.ApplyDiscount(request);
                if (canApply)
                {
                    return Ok(HttpStatusCode.OK);
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdmin,GeneralManager,Receiption,Director,Accountant")]
        public IActionResult GetInvoices([FromQuery]int departmentId)
        {
            return Ok(_invoiceService.GetAllInvoices(departmentId));
        }

        [HttpGet("filter")]
        [Authorize]
        public IActionResult GetFilteredInvoices([FromQuery]InvoiceFilterRequest request)
        {
            return Ok(_invoiceService.GetAllFilteredInvoices(request));
        }

        [HttpGet("details")]
        [Authorize(Roles = "SystemAdmin,GeneralManager,Receiption,Director,Accountant")]
        public IActionResult GetInvoiceDetails([FromQuery]string invoiceNo)
        {
            return Ok(_invoiceService.GetInvoiceDetails(invoiceNo));
        }

        [HttpPost("cancel")]
        [Authorize(Roles = "SystemAdmin,GeneralManager")]
        public IActionResult CancelInvoice([FromQuery]string invoiceNo, string cancelReason)
        {
            try
            {
                _invoiceService.CancelInvoice(invoiceNo, cancelReason, UserId);
                return Ok(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}