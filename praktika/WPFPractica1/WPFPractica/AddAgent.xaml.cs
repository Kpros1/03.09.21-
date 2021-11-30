using Microsoft.Win32;
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
    /// Логика взаимодействия для AddAgent.xaml
    /// </summary>
    public partial class AddAgent : Page
    {
        public OpenFileDialog ofd = new OpenFileDialog();
        string path = "";
        private bool flag = false;
        private string _imgSource = string.Empty;
        private Agent _selectAgent = new Agent();
        public AddAgent(Agent selectAgent)
        {
            InitializeComponent();

            if (selectAgent != null)
                _selectAgent = selectAgent;
            DataContext = _selectAgent;
            ComboBox.ItemsSource = PraktikaEntities.GetContext().AgentType.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int test = Convert.ToInt32(_selectAgent.Priority);
         

            if (flag)
            {
                File.Copy(ofd.FileName, _imgSource, true);
                _selectAgent.Logo = $"\\agents\\{ofd.SafeFileName}";
            }
            StringBuilder errors = new StringBuilder();
            
            if (string.IsNullOrWhiteSpace(_selectAgent.Title))
                errors.AppendLine("Укажите название кампании");
            //if (_selectAgent.AgentType.Title == null)
              // errors.AppendLine("Выберите тип агента");
            if (string.IsNullOrWhiteSpace(test.ToString()))
              errors.AppendLine("Укажите приоритет");
            if (string.IsNullOrWhiteSpace(_selectAgent.Address))
                errors.AppendLine("Укажите адрес");
            if (string.IsNullOrEmpty(_selectAgent.INN)) 
            errors.AppendLine("Укажите ИНН");
                if (string.IsNullOrWhiteSpace(_selectAgent.KPP))
            errors.AppendLine("Укажите КПП");
            if (string.IsNullOrWhiteSpace(_selectAgent.DirectorName))
                errors.AppendLine("Укажите имя директора");
            if (!_selectAgent.Email.Contains("@") || !_selectAgent.Email.Contains("."))
                errors.AppendLine("Укажите почту");
            if (string.IsNullOrWhiteSpace(_selectAgent.Phone))
            {
                errors.AppendLine("Укажите телефон");
                
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_selectAgent.ID == 0)
                PraktikaEntities.GetContext().Agent.Add(_selectAgent);
            try
            {
                PraktikaEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                FrameWindow.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SelectedPhoto_Click(object sender, RoutedEventArgs e)
        {
            string Source = Environment.CurrentDirectory;
            if (ofd.ShowDialog() == true)
            {
                flag = true;
                string ing = ofd.SafeFileName;
                _imgSource = Source.Replace("\\bin\\Debug", "\\agents\\") + ing;
                PreviewImage.Source = new BitmapImage(new Uri(ofd.FileName));
                path = ofd.FileName;
            }
        }
    }

}
