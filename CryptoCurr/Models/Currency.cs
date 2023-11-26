using System;
using System.Collections.Generic;

namespace CryptoCurr.Models
{
    public partial class Currency
    {
        public Currency()
        {
            Histories = new HashSet<History>();
            Markets = new HashSet<Market>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? PriceId { get; set; }

        public virtual Price? Price { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Market> Markets { get; set; }
    }
}
