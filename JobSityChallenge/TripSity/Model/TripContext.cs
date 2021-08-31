using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace TripSity
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options)
    : base(options)
        {
        }

        public DbSet<TripItem> Items { get; set; }

        static public List<TripItem> Trips = Seed();

        static List<TripItem> Seed()
        {
            List<TripItem> trips = new();
            foreach(string s in TripSity.Files.TripSeed.Trips)
            {
                TripItem item = new()
                {
                    Region = s.Substring(0,7),
                    DateTimeTrip = Convert.ToDateTime(s.Substring(8,16).Replace('_',' ').Trim()),
                    DataSource = s[24..].Trim()
                };
                trips.Add(item);
            }
            return trips;
        }

    }
}
