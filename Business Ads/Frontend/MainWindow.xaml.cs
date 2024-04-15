using ScottPlot;
using System.Collections;
using System.Collections.Generic;
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
                {
                    dataX[i] = i;
                }

                double[] dataY = new double[24];
                for(int i = 1; i < 24; i++)
                {
                    dataY[i] =  r.Next(10);
                }

                EngagementPlot.Plot.Axes.SetLimitsX(left: 0, right: 24);
                EngagementPlot.Plot.Axes.SetLimitsY(bottom: 0, top: 10);
                EngagementPlot.Plot.Add.Bars(dataX, dataY);
                EngagementPlot.Refresh();
            };
        }
    }
}