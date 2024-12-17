using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Models
{
    public class Destination
    {
        public string LocationName { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string TransportMode { get; set; }
        public string Accommodation { get; set; }
    }
}
