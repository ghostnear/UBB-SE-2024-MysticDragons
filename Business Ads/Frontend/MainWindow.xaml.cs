using System.Windows;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                Random r = new Random();

                double[] dataX = new double[24];
                for(int i = 1; i < 24; i++)
                    dataX[i] = i;

                double[] dataY = new double[24];
                for(int i = 0; i < 24; i++)
                    dataY[i] =  r.Next(10);

                EngagementPlot.Plot.Title("Ad Engagement throughout the day");
                EngagementPlot.Plot.XLabel("Hour of the day");
                EngagementPlot.Plot.YLabel("Engagement on a scale from 1 to 10");

                EngagementPlot.Plot.Axes.SetLimitsX(left: -0.5, right: 23.5);
                EngagementPlot.Plot.Axes.SetLimitsY(bottom: 0, top: 10);
                EngagementPlot.Plot.Add.Bars(dataX, dataY);
                EngagementPlot.Refresh();
            };
        }
    }
}