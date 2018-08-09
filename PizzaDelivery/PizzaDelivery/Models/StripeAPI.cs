using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaDelivery.Models
{
    public class StripeAPI
    {
        [Key]
        public string stripePublishKey { get; set; }
    }
}