using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaDelivery.Models
{
    public class TextAPI
    {
        [Key]
        public int ID { get; set; }
        public string SendToPhoneNumber { get; set; }
        public string SendFromPhoneNumber { get; set; }
        
    }
}