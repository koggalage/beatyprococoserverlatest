using BeautyPro.CRM.Contract.DTO.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO
{
    public class InvoiceDetailsDTO
    {
        public decimal TreatmentSubTotal { get; set; }
        public decimal ProductSubTotal { get; set; }
        public decimal TreatmentDiscountAmount { get; set; }
        public string GvinvoiceNo { get; set; }
        public List<InvoiceViewTreatmentResponse> Treatments { get; set; }
        public List<InvoiceViewProductsResponse> Products { get; set; }

        //public string CustomerId { get; set; }
        //public int DepartmentId { get; set; }
        
        //public decimal TreatmentNetAmount { get; set; }
        //public decimal TreatmentDueAmount { get; set; }
        //public decimal TreatmentDiscountAmount { get; set; }
        //public decimal TreatmentsTax { get; set; }
        //public decimal TreatmentTaxAmount { get; set; }
        //public decimal ProductDueAmount { get; set; }
        //public decimal ProductTaxAmount { get; set; }
        //public int Ptid { get; set; }
        //public string TransType { get; set; }
        //public decimal GVRedeemedAmount { get; set; }
        ////public string CustomerFullName { get; set; }


    }
}
