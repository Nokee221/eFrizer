using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class CreditCardInsertRequest
    {
        public int ClientId { get; set; }
        public string cardNumber { get; set; }
        public string expiryDate { get; set; }
        public string cardHolderName { get; set; }
        public string cvvCode { get; set; }
    }
}
