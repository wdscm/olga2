using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdilliaKP
{
    public class Settlement
    {
        public string ClientName { get; set; }
        public string RoomNumber { get; set; }
        public DateTime SettlementDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public double Price { get; set; }
    }
}
