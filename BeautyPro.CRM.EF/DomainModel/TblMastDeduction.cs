﻿using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblMastDeduction
    {
        public TblMastDeduction()
        {
            TblEmployeeDeduction = new HashSet<TblEmployeeDeduction>();
        }

        public int DeductionId { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public decimal? Ratio { get; set; }
        public string Description { get; set; }
        public int BranchId { get; set; }
        public bool IsDeleted { get; set; }
        public int? EnteredBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual ICollection<TblEmployeeDeduction> TblEmployeeDeduction { get; set; }
    }
}
