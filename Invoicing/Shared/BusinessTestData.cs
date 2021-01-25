using System;
using System.Collections.Generic;
using System.Linq;

namespace Invoicing.Shared
{
    public class BusinessTestData
    {
        private Invoice[] testInvoices =
        {
            /*
            new Invoice("B2345", "FOO", 56312.2, DateTime.Now),
            new Invoice("B1345", "BAR", 45879.8, DateTime.Now),
            new Invoice("R2145", "BAR", 4579.5, DateTime.Now),
            new Invoice("T2145", "BOO", 485679.3, DateTime.Now)
            */
        };

        public BusinessTestData()
        {
            testInvoices[1].RegisterPayment(DateTime.Now, 15487.54);
            testInvoices[3].RegisterPayment(DateTime.Now, 45987.3);
            testInvoices[3].Expected = DateTime.Now;
        }
        
        public IEnumerable<Invoice> AllInvoices => testInvoices;

        public double SalesRevenue => testInvoices.Sum(invoice => invoice.Amount);

        public double Outstanding => testInvoices.Sum(invoice => invoice.Amount - invoice.Paid);
    }
}
