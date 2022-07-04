using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFD.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }


       
        public int CategoryID { get; set; }

        [NotMapped]
        public string Category { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(300)]
        public string ProductDetails { get; set; }

    
        public decimal ProductPrice { get; set; }


        public string ProductImage { get; set; }

    }
}
