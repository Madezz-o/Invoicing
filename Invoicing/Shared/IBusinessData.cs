using System;
using System.Collections.Generic;

namespace Invoicing.Shared
{
    public interface IBusinessData
    {
        IEnumerable<Invoice> AllInvoices { get; }

        void EnvoyerCA();
        double SalesRevenue { get; }
        double Outstanding { get; }
    }
}
