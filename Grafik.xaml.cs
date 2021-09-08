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
using System.Windows.Forms.DataVisualization.Charting;


namespace LAB_7
{
    /// <summary>
    /// Логика взаимодействия для Grafik.xaml
    /// </summary>
    public partial class Grafik : Window
    {
        Predp pred1;
        
        public Grafik(Predp pred)
        {
            InitializeComponent();
            pred1 = new Predp();
            pred1 = pred;
            Window_Loaded();


        }
        private void Window_Loaded()
        {
            int[] sum = new int[12];
            foreach (var p in Predp.getallPerd())
            {
                for (int i = 1; i < 12; i++)
                {
                    if (p.Service_time.Month == i)
                    {
                        sum[i] = ((int)p.Service_cost_work + (int)p.Service_cost_zapcast);
                    }
                }
            }
            // Все графики находятся в пределах области построения ChartArea, создадим ее
            chart.ChartAreas.Add(new ChartArea("Default"));

                // Добавим линию, и назначим ее в ранее созданную область "Default"
                chart.Series.Add(new Series("Series1"));
                chart.Series["Series1"].ChartArea = "Default";
                chart.Series["Series1"].ChartType = SeriesChartType.Line;

                // добавим данные линии
                string[] axisXData = new string[] { "январь", "февраль", "март","апрель","май","июнь","июль","август","сентябрь","октябрь","ноябрь","декабрь"};
                //int[] axisYData = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,13 };
                chart.Series["Series1"].Points.DataBindXY(axisXData, sum);

            }

        }
    }
