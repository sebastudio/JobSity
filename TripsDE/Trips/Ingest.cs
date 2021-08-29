using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Trips
{
    public class IngestPanel : Grid
    {
        public IngestPanel()
        {
            Background = new SolidColorBrush(Colors.Gainsboro);
            Height = 500;
            Width = 300;
            Children.Add(factory);
            Children.Add(flow);
        }
        Image factory = new Image
        {
            Source = new BitmapImage(
             new Uri("/Images/DataFactory.png", UriKind.Relative)),
            Height = 150,
            Margin = new Thickness(0, 10, 0, 0),
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Center
        };
        Image flow = new Image
        {
            Source = new BitmapImage(
            new Uri("/Images/FromExcelToPowerBI.jpg", UriKind.Relative)),
            Height = 250,
            VerticalAlignment = VerticalAlignment.Bottom,
            HorizontalAlignment = HorizontalAlignment.Center
        };
        ProgressBar pb = new ProgressBar
        {
            Minimum = 0,
            Maximum = 100,
            Margin = new Thickness(10, 180, 10, 0),
            VerticalAlignment = VerticalAlignment.Top,
            Height = 50
        };
        TextBlock msg = new TextBlock
        {
            Text = "Ingesting of CSV file",
            Margin = new Thickness(10, 200, 10, 0),
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Center
        };
        public void Ingest()
        {
            Children.Add(pb);
            Children.Add(msg);
            pb.Value = 0;
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
            ReadCSV();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Children.Remove(pb);
            Children.Remove(msg);
            IngestionNotification?.Invoke(DateTime.Now);
            ShowQueries?.Invoke();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(20);
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pb.Value = e.ProgressPercentage;
        }
        public Action<DateTime> IngestionNotification { get; set; }
        public Action ShowQueries { get; set; }

        void ReadCSV()
        {
            if (TripItems.db.items.Count > 0)
                return;
            var fs = Application.GetResourceStream(new Uri("/Files/trips.csv", UriKind.Relative));
            using (var reader = new StreamReader(fs.Stream))
            {
                string line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    TripItems.db.Add(line);
                }
            }
            var x = TripItems.db;
        }
    }
}
