using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearServerAuth
{
    public partial class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DocumentId { get; set; }

        public long DocumentTypeId { get; set; }

        public long AccountId { get; set; }

        public double DocumentSumm { get; set; }

        public double DocumentSimmDiscount { get; set; }

        public DateOnly DocumentDate { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; } = null!;
        [ForeignKey("DocumentTypeId")]
        public virtual DocumentType DocumentType { get; set; } = null!;

        public virtual ICollection<PaymentDocument> PaymentDocuments { get; set; } = new List<PaymentDocument>();
    }
}