using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GuestTracker.DAL.Models
{
    public class Guest
    {
        [Key]
        public Guid Guest_Id { get; set; }
        public string GuestName { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string GuestAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PurposeOfVisit { get; set; }
        public string WhomToSee { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Signature { get; set; }
        public string Sex { get; set; }
        public Guid VisitDetailId { get; set; }

        public virtual VisitDetail VisitDetail { get; set; }
    }
    public class VisitDetail
    {
        [Key]
        public Guid Visit_Detail_Id { get; set; }
        public string GuestName { get; set; }
        public int NumberOfVisit { get; set; }
        public DateTime VisitDate { get; set; }
        public string PhoneNumber { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public GuestVisitStatus Status { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
    }

    public enum GuestVisitStatus
    {
        IN,
        OUT,
        CANCELLED
    }
}
