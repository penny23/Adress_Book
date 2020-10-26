using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Address_Book_Model
{
  
    public class ContactViewModel
    {
        
         [Key]
         public int ContactId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SurName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }

        [Column("BirthDate")]
        public DateTime BirthDate { get; set; }


    }
}
