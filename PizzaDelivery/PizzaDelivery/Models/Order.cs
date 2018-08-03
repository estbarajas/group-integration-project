using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaDelivery.Models
{
    public class Order
    {
        [Key]
        [Display(Name ="OrderId")]
        public int Id { get; set; }
        public int Total { get; set; }
        public bool OrderConfirmed { get; set; }
        public bool OrderPrepped { get; set; }
        public bool OrderOutForDelivery { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}