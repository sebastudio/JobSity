using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Trips
{
    public class QueryPanel : Grid
    {
        public QueryPanel()
        {
            Background = new SolidColorBrush(Colors.Beige);
            Height = 500;
            Width = 300;
        }
        Image queryIcon = new Image
        {
            Source = new BitmapImage(
             new Uri("/Images/QueryLogo.png", UriKind.Relative)),
            Margin = new Thickness(10, 40, 10, 0),
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Center
        };
        StackPanel Queries()
        {
            RadioButton byOrigin = new RadioButton
            {
                Content = "Trips",
                Name = "ByOrigin"
            };
            byOrigin.Click += Clicked;
            RadioButton byWeek = new RadioButton
            {
                Content = "Trips by Week",
                Margin = new Thickness(20,0,0,0),
                Name = "ByWeek"
            };
            byWeek.Click += Clicked;
            return new StackPanel
            {
                Children = { byOrigin, byWeek },
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 180, 10, 0),
                Orientation = Orientation.Horizontal
            };
        }

        private void Clicked(object sender, RoutedEventArgs e)
        {
            RadioButton b = (RadioButton)sender;
            if (b.Name == "ByOrigin")
                ShowQueries();
            else
                ShowByWeek();
        }

        public void ShowQueries()
        {
            Children.Clear();
            Children.Add(queryIcon);
            Children.Add(Queries());
            Children.Add(
                new ByOrigin
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(10, 210, 10, 0),
                }
                );
        }
        public void ShowByWeek()
        {
            Children.Clear();
            Children.Add(queryIcon);
            Children.Add(Queries());
            Children.Add(
                new AverageByWeek
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(10, 210, 10, 0),
                }
                );
        }
    }
}
