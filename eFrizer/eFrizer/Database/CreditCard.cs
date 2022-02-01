using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Database
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }

        public string cardNumber { get; set; }
        public string expiryDate { get; set; }
        public string cardHolderName { get; set; }
        public string cvvCode { get; set; }

        public int ClientId { get; set; }
        
        public virtual Client Client { get; set; }
    }
}
