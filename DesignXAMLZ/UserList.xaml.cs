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

namespace DesignXAMLZ
{
    /// <summary>
    /// Логика взаимодействия для UserList.xaml
    /// </summary>
    /// 
    /*
    private static Entities _context;
    public static Entities GetContext()
    {
        if (_context == null)
        {
            _context = new Entities();
        }
        return _context;
    }
    */
    public partial class UserList : Page
    {
        public UserList()
        {
            InitializeComponent();
            userlistgrid.ItemsSource = Entities.GetContext().Users.ToList();
            var UserType = new List<string>() { "Все пользователи" };
            UserType.AddRange(Entities.GetContext().TypesUsers.Select(c => c.Name).ToList());
            UsersTypeComboBox.ItemsSource = UserType;
            UsersTypeComboBox.SelectedIndex = 0;
           
        }

        private void userlistgrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update((SortComboBox.SelectedItem as ComboBoxItem).Content.ToString(), UsersTypeComboBox.Text);
        }

        private void UsersTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update(SortComboBox.Text, (UsersTypeComboBox.SelectedItem as string).ToString());
        }
       
        private void Update(string sort= "", string filt="")
        {
            
            var data = Entities.GetContext().Users.ToList();
            if (!string.IsNullOrWhiteSpace(filt) && !string.IsNullOrEmpty(filt))
            {
                if(filt != "Все пользователи")
                {
                    data = data.Where(c => c.TypesUser.Name == filt).ToList();
                }
            }       
            if (!string.IsNullOrEmpty(sort) && !string.IsNullOrWhiteSpace(sort))
                {
                    if (sort == "Логины (по возрастанию)")
                    {
                        data = data.OrderBy(c => c.login).ToList();
                    }
                    if (sort == "Логины (по убыванию)")
                    {
                        data = data.OrderByDescending(c => c.login).ToList();
                    }
                    if (sort == "Почты (по возрастанию)")
                    {
                        data = data.OrderBy(c => c.email).ToList();
                    }
                    if (sort == "Почты (по убыванию)")
                    {
                        data = data.OrderByDescending(c => c.email).ToList();
                    }
            }
            userlistgrid.ItemsSource = data;
        }
    }
}

