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
    public class TripStamp : Grid
    {
        public TripStamp()
        {
            Width = 250;
            RowDefinitions.Add(new RowDefinition { Height = new GridLength(18, GridUnitType.Pixel) });
            RowDefinitions.Add(new RowDefinition { Height = new GridLength(16, GridUnitType.Pixel) });
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            TextBlock region = new()
            {
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            region.SetBinding(TextBlock.TextProperty, new Binding("Region"));
            Children.Add(region);
            TextBlock dt = new()
            {
                FontSize = 10
            };
            dt.SetBinding(TextBlock.TextProperty, new Binding("DateTimeTrip"));
            Children.Add(dt);
            Grid.SetRow(dt, 1);
            TextBlock dataSource = new()
            {

            };
            dataSource.SetBinding(TextBlock.TextProperty, new Binding("DataSource"));
            Children.Add(dataSource);
            Grid.SetColumn(dataSource, 2);
            Grid.SetRow(dataSource, 1);
            TextBlock fromTo = new()
            {
                VerticalAlignment = VerticalAlignment.Bottom
            };
            fromTo.SetBinding(TextBlock.TextProperty, new Binding("FromTo"));
            Children.Add(fromTo);
            Grid.SetColumn(fromTo, 2);
            Grid.SetColumnSpan(fromTo, 2);
        }
    }
}
