using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaDelivery.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display (Name ="Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}