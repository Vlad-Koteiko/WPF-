using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для WindowSklad.xaml
    /// </summary>
    public partial class WindowSklad : Window
    {
        Sklad sklad;
        ObservableCollection<Sklad> collection = new ObservableCollection<Sklad>();
        public WindowSklad()
        {
            sklad = new Sklad();
            InitializeComponent();
            gridSklad.DataContext = sklad;
            listBox.DataContext = collection;
        }

        private void FillDate() 
        {
            collection.Clear();
            foreach (var p in Sklad.getallPerd())
            {
                collection.Add(p);
                if(p.Amount <= 0 )
                {
                    MessageBox.Show("Паполнить склад");
                }
            }

        }

        private void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            FillDate();
        }


        private void ButtonViewInsert_Click(object sender, RoutedEventArgs e)
        {
            sklad.Id = listBox.SelectedIndex + 1;
            sklad.Update();
            FillDate();
        }
    }
}
