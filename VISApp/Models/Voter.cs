using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VISApp.Models
{
    public partial class Voter
    {
        [Required]
        public int VoterId { get; set; }
        [Required]
        [StringLength(75,ErrorMessage ="Name lenght should be less than 76")]
        [Display(Name ="Voter Name")]
        public string VoterName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="DOB(MM/DD/YY)")]
        public Nullable<System.DateTime> DOB { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        public string State { get; set; }
        public string EmailId { get; set; }
        public Nullable<long> MobileNumber { get; set; }
    }
}