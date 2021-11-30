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

namespace WPFPractica
{
    /// <summary>
    /// Логика взаимодействия для AddAgent.xaml
    /// </summary>
    public partial class AddAgent : Page
    {
        private Agent _selectAgent = new Agent();
        public AddAgent(Agent selectAgent)
        {
            InitializeComponent();

            if (selectAgent != null)
                _selectAgent = selectAgent;
            DataContext = _selectAgent;
            ComboBox.ItemsSource = PraktikaEntities.GetContext().AgentTypes.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_selectAgent.Title))
                errors.AppendLine("Укажите название кампании");
            if (_selectAgent.Priority > 1 || _selectAgent.Priority < 1000)
                errors.AppendLine("Укажите приоритет агента от 1 до 1000");
            if (_selectAgent.Title == null) ;
            errors.AppendLine("Выберите тип агента");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_selectAgent.ID == 0)
                PraktikaEntities.GetContext().Agents.Add(_selectAgent);
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

    }

}
