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
using System.Windows.Shapes;

namespace Frontend.FAQ
{
    /// <summary>
    /// Interaction logic for AdminMode.xaml
    /// </summary>
    public partial class AdminMode : Window
    {
        private TODOServices services;
        public AdminMode()
        {
            services = new TODOServices();
            InitializeComponent();
            PopulateTodoList();
        }
        private void PopulateTodoList()
        {
            List<TODOClass> todos = services.getTODOS();
            todoListBox.ItemsSource = todos;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = (int)button.Tag;
            services.removeTODO(id);
            PopulateTodoList(); 
        }

    }
}
