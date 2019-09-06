using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Pickup Status")]
        public bool PickupStatus { get; set; }
        [Display(Name = "Pickup Day")]
        public string PickupDay { get; set; }
        [Display(Name = "Suspend Pickup Start Date")]
        [DataType(DataType.Date)]
        public string SuspendPickupStart { get; set; }
        [Display(Name = "Suspend Pickup End Date")]
        [DataType(DataType.Date)]
        public string SuspendPickupEndDate { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "One Time Pickup Day")]
        [DataType(DataType.Date)]
        public string OneTimePickupDay { get; set; }
        [Display(Name = "Area Code")]
        public int AreaCode { get; set; }
        [Display(Name = "Monthly Bill")]
        public double MonthlyBill { get; set; }
        [Display(Name = "Pickup Confirmation")]
        public bool PickupConfirmation { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public enum DayOfWeek { };
    }
}