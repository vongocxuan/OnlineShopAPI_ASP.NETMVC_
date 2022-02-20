using OnlineShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Model.Models
{
    [Table("PostCategories")]
    public class PostCategory:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [MaxLength(250)]
        [Required]
        public string Name { set; get; }
        [MaxLength(250)]
        [Required]
        public string Alias { set; get; }
        [MaxLength(500)]
        public string Description { set; get; }
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }
        [MaxLength(250)]
        public string Image { set; get; }
        public bool? HomeFlag { set; get; }
        public virtual IEnumerable<Post> Posts { set; get; }
    }
}