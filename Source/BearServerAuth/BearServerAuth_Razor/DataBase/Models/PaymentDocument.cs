using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearServerAuth
{
    public partial class PaymentDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PaymentDocumentId { get; set; }

        public long DocumentId { get; set; }

        public long PaymentTypeId { get; set; }

        public double PaymentDocumentSumm { get; set; }

        public bool PaymentDocumentStatus { get; set; }

        public string? PaymentDocumentCheck { get; set; }

        public double PaymentDocumentSummResult { get; set; }
        [ForeignKey("DocumentId")]
        public virtual Document Document { get; set; } = null!;
        [ForeignKey("PaymentTypeId")]
        public virtual PaymentType PaymentType { get; set; } = null!;
    }
}