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
using System.Net.Mail;
using System.Net;
using System.Windows.Media.Media3D;

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
            public Stats(int views,int clicks,int buys,int time)
            {
                this.views = views;
                this.time = time;
                this.clicks = clicks;
                this.buys = buys;
            }
            public int views { get; set; }
            public int clicks { get; set; }
            public int buys { get; set; }
            public int time { get; set; }
        }
        Stats stats = new Stats(1000,100,5,30);
        

        public class User
        {
            public User(String name)
            {
                this.Name = name;
            }
            public String Name { get; set; }

        }
        User user = new User("Andrew Stone");

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
            }
            catch
            {
                throw (new Exception("Wrong Size Input"));
            }
            if (Radio7.IsChecked == true)
            {
                PdfDocument document = new PdfDocument();
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                PdfBrush color = new PdfSolidBrush(System.Drawing.Color.Black);
                int height = 20;

                if (ColorBox.SelectedIndex == 1)
                    color = new PdfSolidBrush(System.Drawing.Color.Gray);
                if (ColorBox.SelectedIndex == 2)
                    color = new PdfSolidBrush(System.Drawing.Color.Red);
                graphics.DrawString("Advertisement Statistics Report", font, color, new PointF((page.Size.Width/2f) - 100, 10));

                if (ImpressionsCheck.IsChecked == true)
                {
                    graphics.DrawString("\nAmount of Impressions: " + stats.views.ToString(), font, color, new PointF(10, height));
                    height += 20;
                }
                if (ClicksCheck.IsChecked == true) { 
                    graphics.DrawString("\nAmount of Clicks: " + stats.clicks.ToString(), font, color, new PointF(10, height));
                height += 20;
            }
            if (BuysCheck.IsChecked == true) { 
                    graphics.DrawString("\nAmount of Purchases: " + stats.buys.ToString(), font, color, new PointF(10, height));
            height += 20;
        }
                if (TimeCheck.IsChecked == true) { 
                    graphics.DrawString("\nTotal Time Viewed: " + stats.time.ToString(), font, color, new PointF(10, height));
        height += 20;
                }
                if (CTRCheck.IsChecked == true) { 
                    graphics.DrawString("\nClick Through Ratio: " + ((float)(stats.clicks/stats.views)).ToString(), font, color, new PointF(10, height));
    height += 20;
                }
                if (DateCheck.IsChecked == true)
                { 
                    graphics.DrawString("Created on:", font, color, new PointF(20, page.Size.Height-120));
                    graphics.DrawString(DateTime.Now.ToString(), font, color, new PointF(20, page.Size.Height - 100));
                }
                if (SignatureCheck.IsChecked == true)
                {
                    graphics.DrawString("Signature:", font, color, new PointF(page.Size.Width-200, page.Size.Height - 120));
                    graphics.DrawString(user.Name, font, color, new PointF(page.Size.Width - 200, page.Size.Height - 100));
                }
                if (RecipientCheck.IsChecked == true)
                {
                    graphics.DrawString("Intended Recipient:", font, color, new PointF((page.Size.Width/2f)-50, page.Size.Height - 120));
                    graphics.DrawString(RecipientInput.Text, font, color, new PointF((page.Size.Width / 2f)-50, page.Size.Height - 100));
                }

                if (DownloadButton1.IsChecked == true)
                {
                    string outputPath = "C:\\Users\\User\\Downloads\\output.pdf";
                    document.Save(outputPath);
                    

                }
                if (EmailButton1.IsChecked == true)
                {
                    var mail = "mysticdragonsubb@gmail.com";
                    var pass = "Password!123";

                    var client = new SmtpClient("smtp.gmail.com", 587);
                    {
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential(mail, pass);
                    }
                    client.SendMailAsync(new MailMessage(from:mail,to:EmailInput1.Text,"Statistics Report","Attached you will find your report"));
                }
                document.Close(true);
            }
                    if (Radio5.IsChecked == true)
            {
                if (DownloadButton1.IsChecked == true)
                {
                    using (var writer = new StreamWriter("C:\\Users\\User\\Downloads\\output.csv"))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        List<Stats> records = new List<Stats> { stats };

                        foreach (var record in records)
                        {
                            if(ImpressionsCheck.IsChecked == true)
                            csv.WriteField(record.views);
                            if (ClicksCheck.IsChecked == true)
                                csv.WriteField(record.clicks);
                            if (BuysCheck.IsChecked == true)
                                csv.WriteField(record.buys);
                            if (CTRCheck.IsChecked == true)
                                csv.WriteField(((float)record.views/record.clicks));
                            if (TimeCheck.IsChecked == true)
                                csv.WriteField(record.time);
                            csv.NextRecord();
                        }
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
