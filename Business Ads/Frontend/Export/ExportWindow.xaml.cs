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
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection.Metadata;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using CsvHelper;
using Syncfusion.Pdf.Parsing;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ExportWindow : Window
    {
        public Window mainWindow;
        public class Stats
        {
            public int views { get; set; }
            public int clicks { get; set; }
            public int buys { get; set; }
            public int time { get; set; }
        }
        public class User
        {
            public String Name { get; set; }

        }
        

        public ExportWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ExportButton1_Click(object sender, RoutedEventArgs e)
        {
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            if (FontBox.SelectedIndex == 1)
                font = font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
            if (FontBox.SelectedIndex == 2)
                font = font = new PdfStandardFont(PdfFontFamily.Courier, 12);
            
            try
            {
                float fontSize = float.Parse(SizeInput.Text);
                //PdfFontFamily fontFamily = GetFontFamilyFromTextBox(FontInput.Text);
            }
            catch
            {
                throw (new Exception("Wrong Size Input"));
            }
            if (Radio7.IsChecked == true)
            {

                //Save the document
                if (DownloadButton1.IsChecked == true)
                {
                    PdfDocument document = new PdfDocument();

                    // Add a page to the document
                    PdfPage page = document.Pages.Add();

                    // Create a PdfGraphics object for drawing
                    PdfGraphics graphics = page.Graphics;

                    if(ColorBox.SelectedIndex == 0)
                    graphics.DrawString("Hello, Syncfusion PDF!", font, PdfBrushes.Black, new PointF(10, 10));
                    if (ColorBox.SelectedIndex == 1)
                        graphics.DrawString("Hello, Syncfusion PDF!", font, PdfBrushes.Gray, new PointF(10, 10));
                    if (ColorBox.SelectedIndex == 2)
                        graphics.DrawString("Hello, Syncfusion PDF!", font, PdfBrushes.Red, new PointF(10, 10));

                    // Save the PDF document to a file
                    string outputPath = "C:\\Users\\User\\Downloads\\output.pdf";
                    document.Save(outputPath);

                    // Close the document
                    document.Close(true);

                }
                    if (EmailButton.IsChecked == true)
                    {

                    }
                
                
                }
            if (Radio6.IsChecked == true)
            {
                if (DownloadButton1.IsChecked == true)
                {
                    string someText = "test";
                    File.WriteAllText(@".\csc.txt", someText);
                }
            }
                    if (Radio5.IsChecked == true)
            {
                if (DownloadButton1.IsChecked == true)
                {
                    using (var writer = new StreamWriter("C:\\Users\\User\\Downloads\\output.csv"))

                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        List<Stats> records = [new Stats { views = 1, clicks = 3, buys = 2, time = 1 }];
                        csv.WriteRecords(records);
                    }
                }
            }
        }

        private void DownloadButton1_Copy2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ReturnButton1_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            Close();
        }
    }
}
