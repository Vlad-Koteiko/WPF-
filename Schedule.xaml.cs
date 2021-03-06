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
using System.Windows.Shapes;

namespace LAB_7
{
    /// <summary>
    /// Логика взаимодействия для Schedule.xaml
    /// </summary>
    public partial class Schedule : Window
    {
        Predp pred1;
        int[] sum = new int[13];
        public Schedule(Predp pred)
        {
            InitializeComponent();
            pred1 = new Predp();
            pred1 = pred;
        }

        // Draw a simple graph.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var p in Predp.getallPerd())
            {
                for (int i = 0; i <= 12; i++)
                {
                    if (p.Service_time.Month == i)
                    {
                        sum[i] = ((int)p.Service_cost_work + (int)p.Service_cost_zapcast);
                    }
                }

               
            }


            const double margin = 10;
            double xmin = margin;
            double xmax = canGraph.Width - margin;
            double ymin = margin;
            double ymax = canGraph.Height - margin;
            const double step = 10;

            // Make the X axis.
            GeometryGroup xaxis_geom = new GeometryGroup();
            xaxis_geom.Children.Add(new LineGeometry(
                new Point(0, ymax), new Point(canGraph.Width, ymax)));
            for (double x = xmin + step;
                x <= canGraph.Width - step; x += step)
            {
                xaxis_geom.Children.Add(new LineGeometry(
                    new Point(x, ymax - margin / 2),
                    new Point(x, ymax + margin / 2)));
            }

            Path xaxis_path = new Path();
            xaxis_path.StrokeThickness = 1;
            xaxis_path.Stroke = Brushes.Black;
            xaxis_path.Data = xaxis_geom;

            canGraph.Children.Add(xaxis_path);

            // Make the Y ayis.
            GeometryGroup yaxis_geom = new GeometryGroup();
            yaxis_geom.Children.Add(new LineGeometry(
                new Point(xmin, 0), new Point(xmin, canGraph.Height)));
            for (double y = step; y <= canGraph.Height - step; y += step)
            {
                yaxis_geom.Children.Add(new LineGeometry(
                    new Point(xmin - margin / 2, y),
                    new Point(xmin + margin / 2, y)));
            }

            Path yaxis_path = new Path();
            yaxis_path.StrokeThickness = 1;
            yaxis_path.Stroke = Brushes.Black;
            yaxis_path.Data = yaxis_geom;

            canGraph.Children.Add(yaxis_path);

            // Make some data sets.
            Brush[] brushes = { Brushes.Red, Brushes.Green, Brushes.Blue };
            //Random rand = new Random();
            //for (int data_set = 0; data_set < 1; data_set++)
            //{
                //int last_y = rand.Next((int)ymin, (int)ymax);

                //int[] last_y = new int[2] {10, 100};
                

                PointCollection points = new PointCollection();
                //for (double x = xmin; x <= xmax; x += step)
                //{
                //    if (last_y < ymin) last_y = (int)ymin;
                //    if (last_y > ymax) last_y = (int)ymax;
                //    points.Add(new Point(x, last_y));
                //}
                for (int i = 0; i <= 12; i++)
                {
                    points.Add(new Point(i * (50), 550- sum[i]));
                }


                Polyline polyline = new Polyline();
                polyline.StrokeThickness = 3;
                polyline.Stroke = brushes[1];
                polyline.Points = points;

                canGraph.Children.Add(polyline);
            //}

        }



    }
}
