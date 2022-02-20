using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Model.Models
{
    [Table("Pages")]
    public class Page
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(250)]
        public string Name { set; get; }
        public string Content { set; get; }
        [Required]
        [MaxLength(250)]
        [Column(TypeName ="varchar")]
        public string Alias { set; get; }
        [Required]
        public bool Status { set; get; }
    }
}