using ScottPlot;
using System;
using System.Windows;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for StatsWindow.xaml
    /// </summary>
    public partial class StatsWindow : Window
    {
        public Window mainWindow;

        public StatsWindow()
        {
            InitializeComponent();

            double[] engagement_data_x = new double[24];
            double[] engagement_data_y = new double[24];

            double[] clicks_data_x = new double[24];
            double[] clicks_data_y = new double[24];

            double[] impressions_data_x = new double[24];
            double[] impressions_data_y = new double[24];

            double[] purchases_data_x = new double[24];
            double[] purchases_data_y = new double[24];

            double[] zeros = new double[24];

            void showEngagementPlot()
            {
                CurrentPlot.Plot.Clear();
                CurrentPlot.Plot.Title("Ad Engagement throughout the day");
                CurrentPlot.Plot.XLabel("Hour of the day");
                CurrentPlot.Plot.YLabel("Engagement on a scale from 1 to 10");

                CurrentPlot.Plot.Axes.SetLimitsX(left: -0.5, right: 23.5);
                CurrentPlot.Plot.Axes.SetLimitsY(bottom: 0, top: 10);
                CurrentPlot.Plot.Add.Bars(engagement_data_x, engagement_data_y);
                CurrentPlot.Plot.ShowGrid();
                CurrentPlot.Plot.HideLegend();
                CurrentPlot.Refresh();
            }

            void showClicksPlot()
            {
                CurrentPlot.Plot.Clear();
                CurrentPlot.Plot.Title("Ad Clicks in the last 24 days");
                CurrentPlot.Plot.XLabel("Days ago");
                CurrentPlot.Plot.YLabel("Number of clicks");

                CurrentPlot.Plot.Axes.SetLimitsX(left: -0.5, right: 23.5);
                CurrentPlot.Plot.Axes.SetLimitsY(bottom: 0, top: 1000);
                CurrentPlot.Plot.Add.FillY(clicks_data_x, clicks_data_y, zeros);
                CurrentPlot.Plot.Add.Scatter(clicks_data_x, clicks_data_y);
                CurrentPlot.Plot.ShowGrid();
                CurrentPlot.Plot.HideLegend();
                CurrentPlot.Refresh();
            }

            void showImpressionsPlot()
            {
                CurrentPlot.Plot.Clear();
                CurrentPlot.Plot.Title("Ad Impressions in the last 24 days");
                CurrentPlot.Plot.XLabel("Days ago");
                CurrentPlot.Plot.YLabel("Number of impressions");

                CurrentPlot.Plot.Axes.SetLimitsX(left: -0.5, right: 23.5);
                CurrentPlot.Plot.Axes.SetLimitsY(bottom: 0, top: 10000);
                CurrentPlot.Plot.Add.FillY(impressions_data_x, impressions_data_y, zeros);
                CurrentPlot.Plot.Add.Scatter(impressions_data_x, impressions_data_y);
                CurrentPlot.Plot.ShowGrid();
                CurrentPlot.Plot.HideLegend();
                CurrentPlot.Refresh();
            }

            void showCTRPlot()
            {
                CurrentPlot.Plot.Clear();
                CurrentPlot.Plot.Title("Click-through rate in the last 24 days");
                CurrentPlot.Plot.XLabel("Days ago");
                CurrentPlot.Plot.YLabel("CTR");

                double[] ctr_data_x = new double[24];
                double[] ctr_data_y = new double[24];

                for(int index = 0; index < 24; index++)
                    ctr_data_x[index] = index;

                for(int index = 0; index < 24; index++)
                    ctr_data_y[index] = clicks_data_y[index] / impressions_data_y[index];

                CurrentPlot.Plot.Axes.SetLimitsX(left: -0.5, right: 23.5);
                CurrentPlot.Plot.Axes.SetLimitsY(bottom: 0, top: 1);
                CurrentPlot.Plot.Add.FillY(ctr_data_x, ctr_data_y, zeros);
                CurrentPlot.Plot.Add.Scatter(ctr_data_x, ctr_data_y);
                CurrentPlot.Plot.ShowGrid();
                CurrentPlot.Plot.HideLegend();
                CurrentPlot.Refresh();
            }

            void showPurchasesPlot()
            {
                CurrentPlot.Plot.Clear();
                CurrentPlot.Plot.Title("Purchases in the last 24 days");
                CurrentPlot.Plot.XLabel("Days ago");
                CurrentPlot.Plot.YLabel("Number of purchases");

                CurrentPlot.Plot.Axes.SetLimitsX(left: -0.5, right: 23.5);
                CurrentPlot.Plot.Axes.SetLimitsY(bottom: 0, top: 500);

                CurrentPlot.Plot.Add.FillY(purchases_data_x, purchases_data_y, zeros);
                CurrentPlot.Plot.Add.Scatter(purchases_data_x, purchases_data_y);
                CurrentPlot.Plot.ShowGrid();
                CurrentPlot.Plot.HideLegend();

                CurrentPlot.Refresh();
            }

            void showEngagementTypes()
            {
                CurrentPlot.Plot.Clear();
                CurrentPlot.Plot.Title("Engagement types in the last 24 days");

                double[] sums = new double[2];
                for(int index = 0; index < 24; index++)
                {
                    sums[0] += clicks_data_y[index];
                    sums[1] += purchases_data_y[index];
                }

                CurrentPlot.Plot.Axes.SetLimitsX(left: -1, right: 1);
                CurrentPlot.Plot.Axes.SetLimitsY(bottom: -1, top: 1);
                CurrentPlot.Plot.HideGrid();
                CurrentPlot.Plot.ShowLegend([
                    new()
                    {
                        Label = "Users that clicked the add and bought",
                        LineColor = Colors.Orange,
                        MarkerColor = Colors.Orange
                    },
                    new()
                    {
                        Label = "Users that only clicked the add",
                        LineColor = Colors.Blue,
                        MarkerColor = Colors.Blue
                    }
                ]);

                CurrentPlot.Plot.Add.Pie(sums);
                CurrentPlot.Plot.XLabel("");
                CurrentPlot.Plot.YLabel("");
                CurrentPlot.Refresh();
            }

            Loaded += (sender, eventData) =>
            {
                Random random = new Random();
                for(int index = 0; index < 24; index++)
                    engagement_data_x[index] = index;
                for(int index = 0; index < 24; index++)
                    engagement_data_y[index] = random.Next(10);

                for(int index = 0; index < 24; index++)
                    clicks_data_x[index] = index;
                for(int index = 0; index < 24; index++)
                    clicks_data_y[index] = random.Next(1000);

                for(int index = 0; index < 24; index++)
                    impressions_data_x[index] = index;
                for(int index = 0; index < 24; index++)
                    impressions_data_y[index] = random.Next((int)clicks_data_y[index], 10000);

                for(int index = 0; index < 24; index++)
                    purchases_data_x[index] = index;
                for (int index = 0; index < 24; index++)
                    purchases_data_y[index] = random.Next((int)clicks_data_y[index] / 10, (int)clicks_data_y[index] / 2);

                for(int index = 0; index < 24; index++)
                    zeros[index] = 0;

                CurrentPlot.Width = 800;
                CurrentPlot.Height = 460;

                showEngagementPlot();
            };

            Closed += (sender, EventData) =>
            {
                mainWindow.Show();
            };

            EngagementButton.Click += (sender, eventData) =>
            {
                showEngagementPlot();
            };

            ClicksButton.Click += (sender, eventData) =>
            {
                showClicksPlot();
            };

            ImpresionsButton.Click += (sender, eventData) =>
            {
                showImpressionsPlot();
            };

            CTRButton.Click += (sender, eventData) =>
            {
                showCTRPlot();
            };

            PurchasesButton.Click += (sender, eventData) =>
            {
                showPurchasesPlot();
            };

            EngagementTypesButton.Click += (sender, eventData) =>
            {
                showEngagementTypes();
            };

            BackButton.Click += (sender, eventData) =>
            {
                mainWindow.Show();
                Close();
            };
        }
    }
}