
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Address_Book_Data
{  
    [Table("ContactType")]
    public class ContactType
    {
        [Column("ContactTypeId")]
        [Key]
        public int ContactTypeId { get; set; }

        [Column("Description")]
        public string Description { get; set; }
    }
}
