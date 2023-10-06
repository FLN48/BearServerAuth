using System;
using System.Collections.Generic;

namespace BearServerAuth
{
    public partial class DocumentType
    {
        public long DocumentTypeId { get; set; }

        public string DocumentTypeName { get; set; } = null!;

        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}