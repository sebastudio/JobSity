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
    public class ExternalSourcePanel : Grid
    {
        public ExternalSourcePanel()
        {
            Background = new SolidColorBrush(Colors.Beige);
            Height = 500;
            Width = 300;
            Initialize();
        }
        Image userIcon = new Image
        {
            Source = new BitmapImage(
                     new Uri("/Images/UserIcon.png", UriKind.Relative)),
            Height = 100,
            Margin = new Thickness(0, 10, 0, 0),
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Center
        };
        Image Synapse = new Image
        {
            Source = new BitmapImage(
             new Uri("/Images/SynapseAnalytics.png", UriKind.Relative)),
            VerticalAlignment = VerticalAlignment.Bottom,
            HorizontalAlignment = HorizontalAlignment.Center
        };
        Button extract = new Button
        {
            Content = "Send CSV FILE",
            Height = 40,
            Margin = new Thickness(10, 120, 10, 0),
            VerticalAlignment = VerticalAlignment.Top
        };
        ListBox ingestions = new ListBox
        {
            Margin = new Thickness(10, 170, 10, 0),
            VerticalAlignment = VerticalAlignment.Top,
            MaxHeight = 100
        };
        void Initialize()
        {
            extract.Click += Extract_Click;
            Children.Add(userIcon);
            Children.Add(extract);
            Children.Add(ingestions);
            Children.Add(Synapse);
        }

        private void Extract_Click(object sender, RoutedEventArgs e)
        {
            Ingest?.Invoke();
            extract.IsEnabled = false;
        }

        public Action Ingest { get; set; }
        public void IngestionEvent(DateTime dt)
        {
            extract.IsEnabled = true;
            ingestions.Items.Add($"Successful Ingestion: {dt}");
        }
    }
}
