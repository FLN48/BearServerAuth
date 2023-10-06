using System;
using System.Collections.Generic;

namespace BearServerAuth
{
    public partial class Document
    {
        public long DocumentId { get; set; }

        public long DocumentTypeId { get; set; }

        public long AccountId { get; set; }

        public double DocumentSumm { get; set; }

        public double DocumentSimmDiscount { get; set; }

        public DateOnly DocumentDate { get; set; }

        public virtual Account Account { get; set; } = null!;

        public virtual DocumentType DocumentType { get; set; } = null!;

        public virtual ICollection<PaymentDocument> PaymentDocuments { get; set; } = new List<PaymentDocument>();
    }
}