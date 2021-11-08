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

namespace Wpf1
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            DGridHotels.ItemsSource = ToursBase1Entities.GetContext().Hotel.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page2());
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page3());
        }
        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page4());
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page2());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page4());
        }
    }
}
