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
using System.Windows.Shapes;

namespace WPFPractica
{
    /// <summary>
    /// Логика взаимодействия для List.xaml
    /// </summary>
    public partial class List : Window
    {

        private Agent _based = new Agent();
        public List()
        {
            InitializeComponent();
            MainFrame.Navigate(new DataAgents());
            FrameWindow.MainFrame = MainFrame;
            //ImportTours();
        }

      //  private void ImportTours()
        //{
           // var images = Directory.GetFiles(@"C:\Users\zhyri\source\repos\WPFPractica\agents");
           // var based = PracticaZEntities1.GetContext().Agents.ToList();
           // try
           // {
            //   _based.Logo = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(_based.Title)));
           // }
           // catch (Exception ex)
            //{
           //     Console.WriteLine(ex.Message);
         //   }
       //    PracticaZEntities1.GetContext().Agents.Add(_based);
            
     //   }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameWindow.MainFrame.Navigate(new DataAgents());
        }

       
    }
}
