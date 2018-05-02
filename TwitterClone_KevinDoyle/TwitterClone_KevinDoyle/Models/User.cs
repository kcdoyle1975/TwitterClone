//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwitterClone_KevinDoyle.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Tweets = new HashSet<Tweet>();
        }
    
        public int UserId { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "This field is required.")]

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string LogInErrorMessage = "Invalid User Name or Password";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}
