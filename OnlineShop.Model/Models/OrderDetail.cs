using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Model.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Column(Order =0)]
        public int OrderID { set; get; }
        [Key]
        [Column(Order =1)]
        public int ProductID { set; get; }
        [Required]
        public int Quanity { set; get; }
        [ForeignKey("ProductID")]
        public virtual Product Product { set; get; }
        [ForeignKey("OrderID")]
        public virtual Order Order { set; get; }

    }
}