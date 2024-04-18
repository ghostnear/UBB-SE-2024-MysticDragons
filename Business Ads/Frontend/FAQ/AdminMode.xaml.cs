using ScottPlot.Colormaps;
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
        private ReviewService reviewService;
        public AdminMode()
        {
            services = TODOServices.Instance;
            reviewService = ReviewService.Instance;
            InitializeComponent();
            PopulateTodoList();
            PopulateReviewList();
        }
        private void PopulateReviewList() 
        {
            List<ReviewClass> reviews = reviewService.getAllReviews();
            if (reviews != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (ReviewClass review in reviews)
                {
                    sb.AppendLine(review.ToString());
                }
                reviewBlock.Text = sb.ToString();
            }
            else
            {
                reviewBlock.Text = "";
            }
        }
        private void PopulateTodoList()
        {
            List<TODOClass> todos = services.getTODOS();
            if (todos != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (TODOClass todo in todos)
                {
                    sb.AppendLine(todo.ToString());
                }
                todoTextBlock.Text = sb.ToString();
            }
            else
            {
                todoTextBlock.Text = ""; 
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Input number of finished task")
            {
                textBox.Text = ""; 
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Input number of finished task";
            }
        }

        private void addTask_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Input new task here")
            {
                textBox.Text = ""; 
            }
        }

        private void addTask_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Input new task here";
            }
        }

        private void removeTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(removeText.Text, out int idToRemove))
            {
                services.removeTODO(idToRemove);
                PopulateTodoList();
                removeText.Text = "Input number of finished task"; 
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.");
            }

        }

        private void addTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string newTask = addTask.Text;
            if (!string.IsNullOrWhiteSpace(newTask))
            {
                TODOClass task = new TODOClass(newTask);
                services.addTODO(task);
            
            }
            PopulateTodoList();
        }



   
}
}
