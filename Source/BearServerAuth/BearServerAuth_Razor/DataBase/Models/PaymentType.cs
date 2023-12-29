using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearServerAuth
{
    public partial class PaymentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PaymentTypeId { get; set; }

        public string PaymentTypeName { get; set; } = null!;

        public virtual ICollection<PaymentDocument> PaymentDocuments { get; set; } = new List<PaymentDocument>();
    }
}