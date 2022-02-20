using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Model.Models
{
    [Table("SystemConfigs")]
    public class SystemConfig
    {
        [Key]
        public int ID { set; get; }

        [MaxLength(50)]
        [Required]
        [Column(TypeName = "varchar")]
        public string Code { set; get; }

        [MaxLength(250)]
        public string ValueString { set; get; }

        public int? ValueInt { set; get; }
    }
}