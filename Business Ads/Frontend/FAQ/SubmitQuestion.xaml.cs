using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for SubmitQuestion.xaml
    /// </summary>
    public partial class SubmitQuestion : Window
    {
        private FAQService service;
        private List<String> topics;
        private List<FAQ> faqs;
        public SubmitQuestion()
        {
            service = new FAQService();
            topics = new List<String>();
            faqs = service.getAll();

            foreach (FAQ faq in faqs) 
            {
                if (!topics.Contains(faq.Topic))
                {
                    topics.Add(faq.Topic);
                }
            }

            InitializeComponent();
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
            FAQ newQ = new FAQ(100, question, "to be added", selectedTopic);
            service.addSubmittedQuestion(newQ);
            MessageBox.Show("The question has been submitted. Check the FAQ page later to see if it has been approved.");
        }
    }
}
