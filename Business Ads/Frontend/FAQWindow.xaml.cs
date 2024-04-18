using System.Windows;
using System.Windows.Controls;
using Backend.Services;
using Backend.Models;
using Frontend.FAQ;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for FAQWindow.xaml
    /// </summary>
    public partial class FAQWindow : Window
    {
        public Window mainWindow;
        private FAQService service;
        private ReviewService reviewService;
        private List<Backend.Models.FAQ> fAQs;
        private List<ReviewClass> reviews;
        public FAQWindow()
        {
            service = FAQService.Instance;
            reviewService = ReviewService.Instance;

            fAQs = new List<Backend.Models.FAQ>();
            reviews = new List<ReviewClass>();

            fAQs = service.getAll();
            reviews = reviewService.getAllReviews();

            InitializeComponent();

            listFAQ.ItemsSource = fAQs;

            Closed += (sender, e) =>
            {
                mainWindow.Show();
            };
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

            List<Backend.Models.FAQ> filteredFAQ;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filteredFAQ = fAQs
                    .Where(faq =>
                        faq.Question.ToLower().Contains(searchText) ||
                        faq.Topic.ToLower() == searchText
                    )
                    .ToList();
            }
            else
            {
                filteredFAQ = fAQs;
            }

            if (filteredFAQ == null || filteredFAQ.Count == 0)
            {
                filteredFAQ = fAQs;
            }

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
                Backend.Models.FAQ selectedFAQ = (Backend.Models.FAQ)listFAQ.SelectedItem;
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

        private void submitQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            SubmitQuestion windowSubmit = new SubmitQuestion();
            windowSubmit.Show();
        }

        private void adminButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            AdminMode admindWindow = new AdminMode();
            admindWindow.Show();
        }
    }
}
