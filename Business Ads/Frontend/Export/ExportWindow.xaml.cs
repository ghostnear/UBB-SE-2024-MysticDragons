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

namespace Frontend
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ExportWindow : Window
    {
        public Window mainWindow;
        public class MyRecord
        {
            public int Value1 { get; set; }
            public int Value2 { get; set; }
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
            if (Radio7.IsChecked == true)
            {
                using (PdfDocument document = new PdfDocument())
                {
                    //Add a page to the document
                    PdfPage page = document.Pages.Add();

                    //Create PDF graphics for a page
                    PdfGraphics graphics = page.Graphics;

                    //Set the standard font
                    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                    //Draw the text
                    graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

                    //Save the document
                    if (DownloadButton1.IsChecked == true)
                        document.Save("Output.pdf");
                    if (EmailButton.IsChecked == true)
                    {

                    }
                }
                
                }
            if (Radio5.IsChecked == true)
            {
                if (DownloadButton1.IsChecked == true)
                {
                    using (var writer = new StreamWriter("output.csv"))

                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        List<MyRecord> records = [new MyRecord { Value1 = 1, Value2 = 3 }, new MyRecord { Value1 = 2, Value2 = 4 }];
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
