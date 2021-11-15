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
using System.IO;

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

            ImportTours();
        }

        private void ImportTours()
        {
            var fileData = File.ReadAllLines(@"C:\Program Files (x86)\Лист Microsoft Excel.txt");
            var images = Directory.GetFiles(@"C:\Program Files (x86)\kartinki");

            foreach(var line in fileData)
            {
                var data = line.Split('\t');
                var tempTour = new Tour
                {
                    Name = data[0].Replace("\"", ""),
                    TicketCount = int.Parse(data[2]),
                    Price = decimal.Parse(data[3]),
                    IsActual = (data[4] == "0") ? false : true
                };
                foreach(var tourType in data[5].Split(new string[] { ","}, StringSplitOptions.RemoveEmptyEntries))
                {
                    var currentType = ToursBase1Entities.GetContext().Type.ToList().FirstOrDefault(p => p.Name == tourType);
                    tempTour.Type.Add(currentType);
                }
                try
                {
                    tempTour.ImagePreview = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(tempTour.Name)));

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                ToursBase1Entities.GetContext().Tour.Add(tempTour);
                ToursBase1Entities.GetContext().SaveChanges();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page2((sender as Button).DataContext as Hotel));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page2(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)

        {
            var hotelsForRemoving = DGridHotels.SelectedItems.Cast<Hotel>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие{hotelsForRemoving.Count()}элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ToursBase1Entities.GetContext().Hotel.RemoveRange(hotelsForRemoving);
                    ToursBase1Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridHotels.ItemsSource = ToursBase1Entities.GetContext().Hotel.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }








            }

            }
        

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ToursBase1Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridHotels.ItemsSource = ToursBase1Entities.GetContext().Hotel.ToList();
            }
        }
    }
}
