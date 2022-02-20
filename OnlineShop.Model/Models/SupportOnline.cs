﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Model.Models
{
    [Table("SupportOnlines")]
    public class SupportOnline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(250)]
        public string Name { set; get; }
        [MaxLength(250)]
        public string Department { set; get; }
        [MaxLength(250)]
        public string Skype { set; get; }
        [MaxLength(250)]
        public string Mobile { set; get; }
        [MaxLength(250)]
        public string Email { set; get; }
        [MaxLength(250)]
        public string Yahoo { set; get; }
        [MaxLength(250)]
        public string Facebook { set; get; }
        [Required]
        public bool Status { set; get; }
    }
}