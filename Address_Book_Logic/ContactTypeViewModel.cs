using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Address_Book_Model

{
   public class ContactTypeViewModel
    {
        
        [Key]
        public int ContactTypeId { get; set; }

        
        public string Description { get; set; }
    }
}
