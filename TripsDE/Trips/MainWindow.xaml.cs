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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ExternalSourcePanel extract = new();
        IngestPanel ingest = new IngestPanel();
        QueryPanel query = new QueryPanel();
        public MainWindow()
        {
            InitializeComponent();
            Title = "Data Engineering Challenge";
            Height = 560;
            Width = 940;
            Panels();
            Interactions();
        }
        void Panels()
        {
            Content = new StackPanel
            {
                Margin = new Thickness(10, 0, 0, 0),
                Orientation = Orientation.Horizontal,
                Children = { extract, ingest, query }
            };
        }
        void Interactions()
        {
            extract.Ingest = ingest.Ingest;
            ingest.IngestionNotification = extract.IngestionEvent;
            ingest.ShowQueries = query.ShowQueries;
        }
    }
}
