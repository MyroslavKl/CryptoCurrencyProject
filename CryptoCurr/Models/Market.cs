using System;
using System.Collections.Generic;

namespace CryptoCurr.Models
{
    public partial class Market
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? CryptoCurrencyId { get; set; }
        public int? PriceId { get; set; }

        public virtual Currency? CryptoCurrency { get; set; }
        public virtual Price? Price { get; set; }
    }
}
