using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Trips
{
    public class TripItems
    {
        readonly internal List<TripItem> items = new();
        public void Add(string line)
        {
            string[] fields = line.Split(',');
            if (fields[1].Contains("origin"))
                return;
            int[] Orig = CoordXY(fields[1]);
            int[] Dest = CoordXY(fields[2]);
            TripItem item = new TripItem
            {
                Region = fields[0],
                Origin = fields[1],
                Destination = fields[2],
                DateTimeTrip = Convert.ToDateTime(fields[3]),
                DataSource = fields[4],
                OrigX = Orig[0],
                OrigY = Orig[1],
                DestX = Orig[0],
                DestY = Orig[0]
            };
            items.Add(item);
            var q = items.Count;
        }
        public static TripItems db { get; private set; } = new TripItems();
        public static List<TripItem> Items => db.items;
        static int[] CoordXY(string s)
        {
            int[] coord = new int[2];
            string[] ss = { String.Empty, String.Empty };
            int i = 0;
            foreach(char c in s)
                if (Char.IsDigit(c))
                    ss[i] += c;
                else
                    if (c == '.')
                        ss[i] += c;
                    else
                        if (Char.IsWhiteSpace(c))
                            if  (ss[0].Length > 0)
                                    i++;
            double d1 = Math.Round(Convert.ToDouble(ss[0]), 0);
            double d2 = Math.Round(Convert.ToDouble(ss[1]), 0);
            coord[0] = (int)d1;
            coord[1] = (int)d2;
            return coord;
        }
    }
}
