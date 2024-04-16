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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private FAQService service;
        private ReviewService reviewService;
        private List<FAQ> fAQs;
        private List<ReviewClass> reviews;
        public Window1()
        {
            this.service = new FAQService();
            this.reviewService = new ReviewService();
            this.reviews = new List<ReviewClass>();
            this.fAQs = new List<FAQ>();
            this.fAQs = service.getAll();
            this.reviews = reviewService.getAllReviews();
            InitializeComponent();
            listFAQ.ItemsSource = this.fAQs;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Search questions/topic...")
            {
                textBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Search questions/topic...";
            }
        }


        private void inputBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Write feedback...")
            {
                textBox.Text = "";
            }
        }

        private void inputBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Write feedback...";
            }
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox search = (TextBox)sender;
            string searchText = search.Text.ToLower();

            List<FAQ> filteredFAQ = fAQs
                    .Where(faq =>
                        faq.Question.ToLower().Contains(searchText) ||
                        faq.Topic.ToLower() == searchText
                    )
                    .ToList();
            listFAQ.ItemsSource = filteredFAQ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputFeedback = inputBox.Text;
            reviewService.addReview(inputFeedback);
            inputBox.Text = "";
        }

        private void listFAQ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listFAQ.SelectedItem != null)
            {
                FAQ selectedFAQ = (FAQ)listFAQ.SelectedItem;
                answerTextBlock.Text = selectedFAQ.Answer;
                answerPopup.IsOpen = true;
            }
            else
            {
                answerPopup.IsOpen = false;
            }
        }
        private void ClosePopup_Click(object sender, RoutedEventArgs e)
        {
            answerPopup.IsOpen = false;
        }
    }
}
