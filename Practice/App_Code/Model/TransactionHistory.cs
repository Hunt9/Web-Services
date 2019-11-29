using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice.App_Code.Model
{
    public class TransactionHistory
    {
        public int Transactionid { get; set; }

        public string CurrencyType { get; set; }

        public string TransactionType { get; set; }

        public string CurrencyAmount { get; set; }

        public string ProcessedAt { get; set; }

        public string State { get; set; }


   
    }
}