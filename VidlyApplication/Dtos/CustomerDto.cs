using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VidlyApplication.Models;

namespace VidlyApplication.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MemberShipTypeId { get; set; }

        public MembershipTypeDto MemberShipType { get; set; }

       //    [Min18YearsIsAMember]
        public DateTime? Birthday { get; set; }

    }
}