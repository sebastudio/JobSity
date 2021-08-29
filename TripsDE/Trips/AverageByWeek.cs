using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Trips
{
    public class AverageByWeek : StackPanel
    {
        public AverageByWeek()
        {
            TextBlock header = new TextBlock
            {
                Text = "_Region               Trips / Week_"
            };
            Children.Add(header);
            ScrollViewer w = new ScrollViewer
            {
                Height = 250,
                Width = 200
            };
            var items =
                from trip in TripItems.Items
                group trip by trip.Region into tripGroup
                orderby tripGroup.Key
                select new
                {
                    Region = tripGroup.Key,
                    Count = tripGroup.Count()/7
                };
            var templateFactory = new FrameworkElementFactory(typeof(AverageStamp));
            var template = new DataTemplate
            {
                VisualTree = templateFactory
            };
            ListBox p = new ListBox
            {
                ItemsSource = items,
                ItemTemplate = template,
                Width = 270
            };
            w.Content = p;
            Children.Add(w);
        }
    }
}
