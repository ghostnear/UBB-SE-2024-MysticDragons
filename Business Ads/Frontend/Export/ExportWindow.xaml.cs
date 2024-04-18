using System.Windows;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using System.Globalization;
using System.IO;
using CsvHelper;
using System.Net.Mail;
using System.Net;
using Frontend.Export;
using Backend.PaymentsAndBillings.Repositories;
using static System.Net.Mime.MediaTypeNames;

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
        public void ExportPDF()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfBrush color = new PdfSolidBrush(System.Drawing.Color.Black);
            int height = 20;
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

            if (ColorBox.SelectedIndex == 1)
                color = new PdfSolidBrush(System.Drawing.Color.Gray);
            if (ColorBox.SelectedIndex == 2)
                color = new PdfSolidBrush(System.Drawing.Color.Red);
            graphics.DrawString("Advertisement Statistics Report", font, color, new PointF((page.Size.Width / 2f) - 100, 10));

            if (ImpressionsCheck.IsChecked == true)
            {
                graphics.DrawString("\nAmount of Impressions: " + stats.views.ToString(), font, color, new PointF(10, height));
                height += 20;
            }
            if (ClicksCheck.IsChecked == true)
            {
                graphics.DrawString("\nAmount of Clicks: " + stats.clicks.ToString(), font, color, new PointF(10, height));
                height += 20;
            }
            if (BuysCheck.IsChecked == true)
            {
                graphics.DrawString("\nAmount of Purchases: " + stats.buys.ToString(), font, color, new PointF(10, height));
                height += 20;
            }
            if (TimeCheck.IsChecked == true)
            {
                graphics.DrawString("\nTotal Time Viewed: " + stats.time.ToString(), font, color, new PointF(10, height));
                height += 20;
            }
            if (CTRCheck.IsChecked == true)
            {
                graphics.DrawString("\nClick Through Ratio: " + ((float)(stats.clicks / stats.views)).ToString(), font, color, new PointF(10, height));
                height += 20;
            }
            if (DateCheck.IsChecked == true)
            {
                graphics.DrawString("Created on:", font, color, new PointF(20, page.Size.Height - 120));
                graphics.DrawString(DateTime.Now.ToString(), font, color, new PointF(20, page.Size.Height - 100));
            }
            if (SignatureCheck.IsChecked == true)
            {
                graphics.DrawString("Signature:", font, color, new PointF(page.Size.Width - 200, page.Size.Height - 120));
                graphics.DrawString(user.Name, font, color, new PointF(page.Size.Width - 200, page.Size.Height - 100));
            }
            if (RecipientCheck.IsChecked == true)
            {
                graphics.DrawString("Intended Recipient:", font, color, new PointF((page.Size.Width / 2f) - 50, page.Size.Height - 120));
                graphics.DrawString(RecipientInput.Text, font, color, new PointF((page.Size.Width / 2f) - 50, page.Size.Height - 100));
            }
            if (EmailButton1.IsChecked == true)
            {
                string outputPath = "C:\\Users\\User\\Downloads\\output.pdf";
                document.Save(outputPath);
                SendDocEmailAsync(EmailInput1.Text, "C:\\Users\\User\\Downloads\\output.pdf");
            }

            if (DownloadButton1.IsChecked == true)
            {
                string outputPath = "C:\\Users\\User\\Downloads\\output.pdf";
                document.Save(outputPath);
            }
            document.Close(true);
        }
        public void ExportCSV()
        {
            if (EmailButton1.IsChecked == true)
            {
                using (var writer = new StreamWriter("C:\\Users\\User\\Downloads\\output.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    List<Stats> records = new List<Stats> { stats };

                    foreach (var record in records)
                    {
                        if (ImpressionsCheck.IsChecked == true)
                            csv.WriteField(record.views);
                        if (ClicksCheck.IsChecked == true)
                            csv.WriteField(record.clicks);
                        if (BuysCheck.IsChecked == true)
                            csv.WriteField(record.buys);
                        if (CTRCheck.IsChecked == true)
                            csv.WriteField(((float)record.views / record.clicks));
                        if (TimeCheck.IsChecked == true)
                            csv.WriteField(record.time);
                        csv.NextRecord();
                    }
                }
                SendDocEmailAsync(EmailInput1.Text, "C:\\Users\\User\\Downloads\\output.csv");
            }
            if (DownloadButton1.IsChecked == true)
            {
                using (var writer = new StreamWriter("C:\\Users\\User\\Downloads\\output.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    List<Stats> records = new List<Stats> { stats };

                    foreach (var record in records)
                    {
                        if (ImpressionsCheck.IsChecked == true)
                            csv.WriteField(record.views);
                        if (ClicksCheck.IsChecked == true)
                            csv.WriteField(record.clicks);
                        if (BuysCheck.IsChecked == true)
                            csv.WriteField(record.buys);
                        if (CTRCheck.IsChecked == true)
                            csv.WriteField(((float)record.views / record.clicks));
                        if (TimeCheck.IsChecked == true)
                            csv.WriteField(record.time);
                        csv.NextRecord();
                    }
                }
            }
        
    }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (Radio7.IsChecked == true)
            {
                ExportPDF();
            }
            if (Radio5.IsChecked == true)
            {
                ExportCSV();
            }
            ConfirmExport();
        }
        public void ConfirmExport()
        {
            ExportSucces exportSucces = new()
            {
                mainWindow = this.mainWindow
            };
            exportSucces.Show();
            Hide();
        }

        public Task SendDocEmailAsync(String recipient,String filename)
        {
            var sender = "osvathrobert03@gmail.com";
            var password = "daes ndml ukpj qvuj";

            var subject = "Statistics Report";
            var message = "Attached are the requested documents";

            var client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(sender, password),
                EnableSsl = true
            };

            var mail = new MailMessage(
                from: sender,
                to: recipient,
                subject: subject,
                body: message

            );
            mail.Attachments.Add(new Attachment(filename));
            return client.SendMailAsync(mail);
        }

        private void ReturnButton1_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            Close();
        }
    }
}
