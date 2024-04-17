using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Frontend.PaymentsAndBillings.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (sender, eventData) =>
            {
                StatsButton.Click += (sender, eventData) =>
                {
                    StatsWindow statsWindow = new StatsWindow();
                    statsWindow.mainWindow = this;
                    statsWindow.Show();
                    Hide();
                };
                ExportButton.Click += (sender, eventData) =>
                {
                    ExportWindow exportWindow = new ExportWindow();
                    exportWindow.mainWindow = this;
                    exportWindow.Show();
                    Hide();
                };
            };
        }
    }
}
