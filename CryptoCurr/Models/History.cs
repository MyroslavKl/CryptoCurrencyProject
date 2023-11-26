using System;
using System.Collections.Generic;

namespace CryptoCurr.Models
{
    public partial class History
    {
        public int Id { get; set; }
        public double Volume { get; set; }
        public double ChangePersent { get; set; }
        public int? CryptoCurrencyId { get; set; }

        public virtual Currency? CryptoCurrency { get; set; }
    }
}
