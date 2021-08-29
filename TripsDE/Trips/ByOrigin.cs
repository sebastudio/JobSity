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
    public class ByOrigin : ScrollViewer
    {
        public ByOrigin()
        {
            Height = 280;
            Width = 280;
            var items = TripItems.Items.OrderBy(a => a.Region).ThenBy(a => a.DateTimeTrip);
            var templateFactory = new FrameworkElementFactory(typeof(TripStamp));
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
            Content = p;
        }
    }
}
