using System;
using System.Collections.Generic;

namespace BearServerAuth
{
    public partial class PaymentDocument
    {
        public long PaymentDocumentId { get; set; }

        public long DocumentId { get; set; }

        public long PaymentTypeId { get; set; }

        public double PaymentDocumentSumm { get; set; }

        public bool PaymentDocumentStatus { get; set; }

        public string? PaymentDocumentCheck { get; set; }

        public double PaymentDocumentSummResult { get; set; }

        public virtual Document Document { get; set; } = null!;

        public virtual PaymentType PaymentType { get; set; } = null!;
    }
}