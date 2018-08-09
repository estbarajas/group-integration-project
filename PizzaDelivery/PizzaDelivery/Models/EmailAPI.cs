using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Models
{
    public class EmailAPI
    {
        [Key]
        public int ID { get; set; }
        public string ToEmailAddress { get; set; }
        public string FromEmailAddress { get; set; }
    }
}