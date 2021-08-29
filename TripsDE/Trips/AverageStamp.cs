using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Trips
{
    public class AverageStamp : Grid
    {
        public AverageStamp()
        {
            Width = 250;
            TextBlock region = new()
            {
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            region.SetBinding(TextBlock.TextProperty, new Binding("Region"));
            Children.Add(region);
            TextBlock week = new()
            {
                Margin = new Thickness(100,0,0,0)
            };
            week.SetBinding(TextBlock.TextProperty, new Binding("Week"));
            Children.Add(week);
            TextBlock count = new()
            {
                Margin = new Thickness(140, 0, 0, 0)
            };
            count.SetBinding(TextBlock.TextProperty, new Binding("Count"));
            Children.Add(count);
        }
    }
}
