using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaDelivery.Models
{
    public class Item
    {
        [Key]

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        

    }
}