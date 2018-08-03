using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaDelivery.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }



        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public Order Order { get; set; }



        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }


    }
}