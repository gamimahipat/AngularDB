using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFD.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        public int UserID { get; set; }

        [NotMapped]
        public string User { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool PaymentStatus { get; set; }
        public bool CoockStatus { get; set; }
        public bool DeliveryStatus { get; set; }

    }
}
