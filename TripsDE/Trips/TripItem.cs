using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trips
{
    public class TripItem
    {
        public string Region { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DateTimeTrip { get; set; }
        public string DataSource { get; set; }
        public int OrigX { get; set; }
        public int OrigY { get; set; }
        public int DestX { get; set; }
        public int DestY { get; set; }
        public string FromTo => $"From {OrigX},{OrigY} to {DestX},{DestY}";
        public int WeekOfYear => DateTimeTrip.DayOfYear / 7;
    }
}
