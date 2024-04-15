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

namespace Frontend.PaymentsAndBillings
{
    /// <summary>
    /// Interaction logic for BankAccountsRepositoryWindow.xaml
    /// </summary>
    public partial class BankAccountsRepositoryWindow : Window
    {
        ICollection<string> counties;

        public BankAccountsRepositoryWindow()
        {
            InitializeComponent();
            counties = new List<string> 
            {
                "-- Select a County --",
                "Alba", 
                "Arad",
                "Arges",
                "Bacau",
                "Bihor",
                "Bistrita-Nasaud",
                "Botosani",
                "Braila",
                "Brasov",
                "Bucuresti",
                "Buzau",
                "Calarasi",
                "Caras-Severin",
                "Cluj",
                "Constanta",
                "Covasna",
                "Dambovita",
                "Dolj",
                "Galati",
                "Giurgiu",
                "Gorj",
                "Harghita",
                "Hunedoara",
                "Ialomita",
                "Iasi",
                "Ilfov",
                "Maramures",
                "Mehedinti",
                "Mures",
                "Neamt",
                "Olt",
                "Prahova",
                "Salaj",
                "Satu Mare",
                "Sibiu",
                "Suceava",
                "Teleorman",
                "Timis",
                "Tulcea",
                "Vaslui",
                "Vrancea"
            };
            countyComboBox.ItemsSource = counties;
        }

        private void HomePage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Profile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Profile clicked!");
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Changes saved successfully!");
        }

        private void HomePage_MouseEnter(object sender, MouseEventArgs e)
        {
            homePageBlock.Background = Brushes.LightGray;
        }

        private void HomePage_MouseLeave(object sender, MouseEventArgs e)
        {
            homePageBlock.Background = Brushes.DimGray;
        }

        private void Profile_MouseEnter(object sender, MouseEventArgs e)
        {
            profileBlock.Background = Brushes.LightGray;
        }

        private void Profile_MouseLeave(object sender, MouseEventArgs e)
        {
            profileBlock.Background = Brushes.DimGray;
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Profile clicked!");
        }
    }
}
