using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Model.Models
{
    [Table("PostTags")]
    public class PostTag
    {
        [Key]
        [Column(Order=0)]
        public int PostID { set; get; }
        [Key]
        [Column(Order =1, TypeName ="varchar")]
        [MaxLength(50)]
        public string TagID { set; get; }
        [ForeignKey("PostID")]
        public virtual Post Post { set; get; }
        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }

    }
}