using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Address_Book_Model
{
  public  class ContactDetailsViewModel
    {

        
        [Key]
        public int ContactDetailsId { get; set; }
        public string Description { get; set; }
        public int ContactId { get; set; }
        public int ContactTypeId { get; set; }

        


    }
}
