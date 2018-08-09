using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaDelivery.Models
{
    public class GoogleMapInformation
    {
        [Key]
        public int ID { get; set; }
        public string RouteTime { get; set; }
        public string RouteDistance { get; set; }
        public string CustomerAddress { get; set; }
    }
}