using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFD.Models
{
    public class AddToCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddToCartID { get; set; }

        public int UserID { get; set; }

        [NotMapped]
        public string User { get; set; }

        public int ProductID { get; set; }

        [NotMapped]
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}
