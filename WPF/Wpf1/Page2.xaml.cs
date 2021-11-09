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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private Hotel _currentHotel = new Hotel();
        public Page2(Hotel selectedHotel)
        {
            InitializeComponent();

            if (selectedHotel != null)
                _currentHotel = selectedHotel;


            DataContext = _currentHotel;
            ComboCountries.ItemsSource = ToursBase1Entities.GetContext().Country.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentHotel.Name))
                errors.AppendLine("укажите название от отеля");
            if (_currentHotel.CountOfStars < 1 || _currentHotel.CountOfStars > 5)
                errors.AppendLine("Количество звезд от 1 до 5");
            if (_currentHotel.Country == null)
                errors.AppendLine("Выберите страну ");

            if(errors.Length>0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentHotel.id == 0)
                ToursBase1Entities.GetContext().Hotel.Add(_currentHotel);

            try
            {
                ToursBase1Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранина");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

           

        }
    }
}
