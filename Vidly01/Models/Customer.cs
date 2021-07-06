using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly01.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membershipt Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name ="Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? DOB { get; set; }
    }
}