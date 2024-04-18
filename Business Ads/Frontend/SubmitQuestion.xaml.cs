using System.Windows;
using System.Windows.Controls;
using Backend.Services;

namespace Frontend.FAQ
{
    /// <summary>
    /// Interaction logic for SubmitQuestion.xaml
    /// </summary>
    public partial class SubmitQuestion : Window
    {
        private FAQService service;
        private List<string> topics;
        private List<Backend.Models.FAQ> faqs;
        public SubmitQuestion()
        {
            InitializeComponent();

            service = FAQService.Instance;

            topics = new List<string>();

            List<Backend.Models.FAQ> faqs = service.getAll();
            foreach (Backend.Models.FAQ faq in faqs)
            {
                if (!topics.Contains(faq.Topic))
                {
                    topics.Add(faq.Topic);
                }
            }

            dropTopic.ItemsSource = topics;
        }

        private void questionBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Input question here...")
            {
                textBox.Text = "";
            }
        }

        private void questionBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Input question here...";
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string question = questionBox.Text;
            string selectedTopic = dropTopic.SelectedItem as string;
            Backend.Models.FAQ newQ = new Backend.Models.FAQ(question, "to be added", selectedTopic);
            service.addSubmittedQuestion(newQ);
            MessageBox.Show("The question has been submitted. Check the FAQ page later to see if it has been approved.");
        }
    }
}
