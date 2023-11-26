using System;
using System.Collections.Generic;

namespace CryptoCurr.Models
{
    public partial class Price
    {
        public Price()
        {
            Currencies = new HashSet<Currency>();
            Markets = new HashSet<Market>();
        }

        public int Id { get; set; }
        public double Cost { get; set; }

        public virtual ICollection<Currency> Currencies { get; set; }
        public virtual ICollection<Market> Markets { get; set; }
    }
}
