using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class InvoiceViewTreatmentResponse
    {
        public string TreatmentName { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
