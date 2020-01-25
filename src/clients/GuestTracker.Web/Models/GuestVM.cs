using System;
using System.ComponentModel.DataAnnotations;

namespace GuestTracker.Web.Models
{
    public class GuestVM
    {
        public Guid Id { get; set; }
        [Display(Name ="Guest Name")]
        [Required]
        public string GuestName { get; set; }
        [Display(Name = "Arrival Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Display(Name = "Arrival Time")]
        [Required]
        [DataType(DataType.Time)]
        public DateTime ArrivalTime { get; set; }
        [Display(Name = "Guest Address")]
        [Required]
        public string GuestAddress { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Name = "Purpose of Visit")]
        [Required]
        public string PurposeOfVisit { get; set; }
        [Display(Name = "Whom To See")]
        [Required]
        public string WhomToSee { get; set; }
        [Display(Name = "Departure Time")]
        [DataType(DataType.Time)]
        public DateTime DepartureTime { get; set; }
        public string Signature { get; set; }
        [Display(Name = "Gender")]
        [Required]
        //[DataType(DataType.Time)]
        public string Sex { get; set; }
        public Guid VisitDetailId { get; set; }
        public DateTime VisitDate { get; set; }
    }

    public enum GuestVisitStatus
    {
        IN,
        OUT,
        CANCELLED
    }
}
