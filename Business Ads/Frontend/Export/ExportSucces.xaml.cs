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

namespace Frontend.Export
{
    /// <summary>
    /// Interaction logic for ExportSucces.xaml
    /// </summary>
    public partial class ExportSucces : Window
    {
        public Window mainWindow;
        public ExportSucces()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            Close();
        }
    }
}
