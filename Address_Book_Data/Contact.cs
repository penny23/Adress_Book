using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Address_Book_Data
{
    [Table("Contact")]
    public class Contact
    {
        [Column("ContactId")]
         [Key]
         public int ContactId { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("SurName")]
        public string SurName { get; set; }


        [Column("ContactNumber")]
        public string ContactNumber { get; set; }


        [Column("BirthDate")]
        public DateTime BirthDate { get; set; }

        [Column("UpdateDate")]
        public DateTime UpdatedDate { get; set; }


    }
}
