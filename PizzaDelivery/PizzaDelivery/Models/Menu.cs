using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaDelivery.Models
{
    public class Menu
    {
        [Key]

        public int Id { get; set; }

        [ForeignKey("Item")]
        public int? ItemId { get; set; }
        public Item Item { get; set; }

    }
}