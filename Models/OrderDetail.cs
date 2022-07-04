using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFD.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }

        [NotMapped]
        public string Order { get; set; }

        public int ProductID { get; set; }

        [NotMapped]
        public string Product { get; set; }

        public int Quantity { get; set; }

        public decimal TotalAmount { get; set; }

    }
}
