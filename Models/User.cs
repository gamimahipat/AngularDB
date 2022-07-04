using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using AngularFD.Models;

namespace AngularFD.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public int UserTypeID { get; set; }


        [NotMapped]
        public string UserType { get; set; }


        [StringLength(30)]
        public string FirstName { get; set; }


        [StringLength(30)]
        public string LastName { get; set; }


        [StringLength(15)]
        public string MobileNumber { get; set; }


        [StringLength(50)]
        public string Email { get; set; }


        [StringLength(30)]
        public string CustomerPassword { get; set; }


        [StringLength(50)]
        public string City { get; set; }


        [StringLength(50)]
        public string HouseNumber { get; set; }


        [StringLength(50)]
        public string Street { get; set; }


        public Nullable<int> PostalCode { get; set; }

        public Nullable<bool> ISActive { get; set; }
    }
}
