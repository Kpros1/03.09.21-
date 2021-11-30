using System;
using System.Collections.Generic;
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

namespace WPFPractica
{
    /// <summary>
    /// Логика взаимодействия для DataAgents.xaml
    /// </summary>
    public partial class DataAgents : Page
    {
        public DataAgents()
        {
            InitializeComponent();
            ListView.ItemsSource = PraktikaEntities.GetContext().ProductSale.ToList();
            ListView.ItemsSource = PraktikaEntities.GetContext().Agent.ToList();
            var AgentType = new List<string>() { "Все типы" };
            AgentType.AddRange(PraktikaEntities.GetContext().AgentType.Select(c => c.Title).ToList());
            TypeBox.ItemsSource = AgentType;
            TypeBox.SelectedIndex = 0;
            SortBox.SelectedIndex = 0;

        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameWindow.MainFrame.Navigate(new AddAgent(null));

        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            //  Update(TypeBox.Text, SortBox.Text, Search.Text);
            // if (ListView.Items.Count == 0)
            // {
            //     MessageBox.Show("Ничего не найдено");
            //    Search.Text = "";
            //   Update(TypeBox.Text, SortBox.Text, Search.Text);
            // }

        }


        private void TypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update(SortBox.Text, (TypeBox.SelectedItem as string).ToString());
        }

        private void SortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update((SortBox.SelectedItem as ComboBoxItem).Content.ToString(), TypeBox.Text);
        }
        private void Searchf(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Update(SortBox.Text, TypeBox.Text, SearchBox.Text);
                if (ListView.Items.Count == 0)
                {
                    MessageBox.Show("Ничего не найдено");
                }
            }
        }

        public void Update(string sort = "", string filt = "", string searh = "")
        {
            var data = PraktikaEntities.GetContext().Agent.ToList();
            if (!string.IsNullOrEmpty(searh) && !string.IsNullOrWhiteSpace(searh))
            {
                data = data.Where(p => p.Title.ToLower().Contains(searh.ToLower()) || p.Phone.ToLower().Contains(searh.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(filt) && !string.IsNullOrWhiteSpace(filt))
            {
                if (filt != "Все типы")
                {
                    data = data.Where(p => p.AgentType.Title == filt).ToList();
                }
            }
            if (!string.IsNullOrWhiteSpace(sort) && !string.IsNullOrEmpty(sort))
            {
                if (sort == "Наименование (по возрастанию)")
                {
                    data = data.OrderBy(p => p.Title).ToList();
                }
                if (sort == "Наименование (по убыванию)")
                {
                    data = data.OrderByDescending(p => p.Title).ToList();
                }
                if (sort == "Размер скидки (по возрастанию)")
                {
                    data = data.OrderBy(p => p.Discount).ToList();
                }
                if (sort == "Размер скидки (по убыванию))")
                {
                    data = data.OrderByDescending(p => p.Discount).ToList();
                }
                if (sort == "Приоритет агента (по возрастанию)")
                {
                    data = data.OrderBy(p => p.Priority).ToList();
                }
                if (sort == "Приоритет агента (по убыванию)")
                {
                    data = data.OrderByDescending(p => p.Priority).ToList();
                }
            }
            ListView.ItemsSource = data;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var AgentsRemoving = ListView.SelectedItems.Cast<Agent>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {AgentsRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PraktikaEntities.GetContext().Agent.RemoveRange(AgentsRemoving);
                    PraktikaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    ListView.ItemsSource = PraktikaEntities.GetContext().Agent.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            FrameWindow.MainFrame.Navigate(new AddAgent((sender as Button).DataContext as Agent));
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
