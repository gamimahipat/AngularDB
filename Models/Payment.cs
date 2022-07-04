using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFD.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }

        public int OrderID { get; set; }

        [NotMapped]
        public string Order { get; set; }

        public DateTime PaymentDate { get; set; }

        [StringLength(30)]
        public string PaymentType { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
