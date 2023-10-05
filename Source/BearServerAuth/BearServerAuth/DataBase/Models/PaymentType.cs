using System;
using System.Collections.Generic;

namespace BearServerAuth
{
    public partial class PaymentType
    {
        public long PaymentTypeId { get; set; }

        public string PaymentTypeName { get; set; } = null!;

        public virtual ICollection<PaymentDocument> PaymentDocuments { get; set; } = new List<PaymentDocument>();
    }
}