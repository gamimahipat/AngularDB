using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFD.Models
{
    public class UserType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTypeID { get; set; }

        [StringLength(50)]
        public string UserTypeName { get; set; }
    }
}
