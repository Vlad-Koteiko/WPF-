using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace LAB_7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person person;
        Predp pred;
        ObservableCollection<Predp> collection = new ObservableCollection<Predp> ();
        public MainWindow()
        {
            InitializeComponent();
            pred = new Predp();
            person = new Person();
            gridperson.DataContext = pred;
            listBox.DataContext = collection;
        }


        private void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            FillDate();
            
        }

        private void ButtonViewInsert_Click(object sender, RoutedEventArgs e)
        {
            pred?.Insert();
            FillDate();
        }

        private void ButtonViewFind_Click(object sender, RoutedEventArgs e)
        {
              Predp predFine =  Predp.Find(textBoxName.Text);
            if (predFine == null)
            {
                MessageBox.Show("нет такой записи");
            }
            else
                MessageBox.Show(predFine.ToString());

        }

        private void ButtonViewUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex < 0)
            {
                return;
            }
            Predp predUodate = (Predp)listBox.SelectedItem;
            predUodate.updatePred(pred);
            predUodate.Update();
            FillDate();
        }



        private void ButtonViewDelete_Click(object sender, RoutedEventArgs e)
        {
            if(listBox.SelectedIndex < 0)
            {
                return;
            }
            Predp.Delete(((Predp)listBox.SelectedItem).ID);
            FillDate();
        }



        private void FillDate()
        {
            collection.Clear();
            foreach(var p in Predp.getallPerd())
            {
                collection.Add(p);
            }

        }

        private void ButtonViewOblusivanie_Click(object sender, RoutedEventArgs e)
        {
            person.Id = listBox.SelectedIndex + 1;                               // заносим ID листбокса в переменную  
            WindowTex windowTex = new WindowTex(person);
            if (windowTex.ShowDialog() != true) return;
            person = windowTex.person;

        }

        private void ButtonViewSklad_Click(object sender, RoutedEventArgs e)
        {
            WindowSklad windowSklad = new WindowSklad();
            if (windowSklad.ShowDialog() != true) return;
        }

        private void ButtonViewOtchet(object sender, RoutedEventArgs e)
        {
            string writePath = @"D:\Book\Doc\BGUIR\Virtual_programm\Kurs\Otchet.txt";

            string text = "Отчет \n";

            foreach (var p in Predp.getallPerd())
            {
                text += p.ToString()+"\n";
            }

            

            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(text);
            }
            MessageBox.Show("Отчет сформирован");
        }

        private void ButtonViewSchedule(object sender, RoutedEventArgs e)
        {
            //Schedule schedule = new Schedule(pred);    // график canves
            //if (schedule.ShowDialog() != true) return;

            Grafik grafik = new Grafik(pred);                // график windowsform
            if (grafik.ShowDialog() != true) return;
           
        }
    }
}
