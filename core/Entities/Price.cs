using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace core.Entities
{
    [Table("Price")]
    public class Price:BaseEntity
    {
        public string SizeName { get; set; }
        public string SizePrice { get; set; }

    }
}