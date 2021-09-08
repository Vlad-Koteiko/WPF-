using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для WindowTex.xaml
    /// </summary>
    public partial class WindowTex : Window
    {
        public Person person;
 
        public WindowTex(Person person)
        {

            InitializeComponent();
            // person = new Person();
            this.person = person;
            grid.DataContext = person;
            combobox2.Items.Add("Регламентное");
            combobox2.Items.Add("Внезапное");
            combobox3.Items.Add("Двигатель 5 кВт");
            combobox3.Items.Add("Двигатель 10 кВт");
            combobox3.Items.Add("Двигатель 15 кВт");
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {











            person.Insert(); // делаем втавку в БД
            person.UPdateSkald(); // Обновляем БД

           //  MessageBox.Show(person.ToString());
            this.DialogResult = true;
        }

        

    }
}
