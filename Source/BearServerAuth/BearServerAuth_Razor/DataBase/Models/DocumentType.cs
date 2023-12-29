using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearServerAuth
{
    public partial class DocumentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DocumentTypeId { get; set; }

        public string DocumentTypeName { get; set; } = null!;

        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}