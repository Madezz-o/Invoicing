using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Shared
{
    public class Invoice
    {
        public Invoice()
        {

        }

        public Invoice(string reference, string customer, double amount, DateTime created, float ChiffreA) 
        {
            Reference = reference;
            Customer = customer;
            Amount = amount;
            Created = created;
            Expected = created + TimeSpan.FromDays(30);
            CAffaire = ChiffreA;

        }
        [Required(ErrorMessage ="Invoice reference is required")]
        public string Reference { get; set; }
        public string Customer { get; set; }
        public double Amount { get; set; }
        public double Paid { get; set; } = 0;
        public DateTime Created { get; set; }
        public DateTime Expected { get; set; }
        public DateTime? LastPayment { get; set; } = null;
        public float CAffaire { get; set; }

        public bool IsPaid => Paid == Amount;
        public bool IsLate => Expected < DateTime.Now;

        public void RegisterPayment(DateTime when, double howMany)
        {
            if(when < Created)
            {
                throw new ArgumentOutOfRangeException("Cannot pay before the invoice creation");
            }
            LastPayment = when;
            if(Amount-Paid < howMany)
            {
                throw new ArgumentOutOfRangeException("Cannot pay over the due amount");
            }
            Paid += howMany;
        }
    }
}
