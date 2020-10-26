using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Address_Book_Data
{
    [Table ("ContactDetails")]
    public class ContactDetails
    {

        [Column ("ContactDetailsId")] 
        [Key]
        public int ContactDetailsId { get; set; }

        [Column ("Description")]
        public string Description { get; set; }

        [Column("ContactId")]
        public int ContactId { get; set; }

        [Column("ContactTypeId")]
        public int ContactTypeId { get; set; }

        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }

        [ForeignKey("ContactTypeId")]
        public ContactType ContactType { get; set; }

    }
}
