using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Imaging;
using System.Xml;
using ScreenShotDemo;

namespace WindowsFormsApplication6
{
    public partial class FormCharts : Form
    {
        private int xAxisRate = 1;
        private Stopwatch stopWatch2 = new Stopwatch();
        private long stopWatchOld = 0;
        private int MIN_X_INCREMENT = 1;
        private int MAX_X_INCREMENT = 10;
        private bool pauseIsActive = false;
        private String machineName = "";
        private String projectName = "";
        private int MAX_CYCLES = 50;
        private int MIN_CYCLES = 1;
        private int cyclesToAcquire = 10;
        private int currentCycle = 1;
        private bool firtStart;
        private string graphName = "Movement_angle_right_leg";
        private NotifyIcon notifyIcon;
        private FormDatabase formBaseContext;
        private int sampleTimeFactor;
        private int sampleStep;
        private int DEFAULT_SAMPLE_TIME_FACTOR = Properties.Settings.Default.DEFAULT_SAMPLE_TIME_FACTOR;
        private float DEFAULT_SAMPLE_TIME = Properties.Settings.Default.SAMPLE_TIME;
        private string FILE_SAVE_PATH = Properties.Settings.Default.FILE_SAVE_PATH;
        private int sensorIdToShow = -1;

        public delegate void ChartsExitEventHandler();
        public event ChartsExitEventHandler chartsExitEventHandler;
        private Timer chartTimer;
        private Decimal[] chartData = new Decimal[] { -9999, -9999, -9999, -9999 };
        private Series[] chartSeries = new Series[6];
        private Series[] chartSeriesTest = new Series[3];
        private Chart[] charts = new Chart[4];
        private string[] chartXaxisLabel = new string[] { "X", "Y", "Z", "XYZ" };
        private Color[] graphLineColors = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Blue, Color.Orange, Color.Green };
        private int dataCounter;
        private Decimal[][] chartDataCont = new Decimal[100][];

        public FormCharts(Object context, int sampleTimeFactor)
        {
            InitializeComponent();
            formBaseContext = (FormDatabase)context;
            initCharts();
            label_measurementContext.Text = label_measurementContext.Text + "Movement angle right leg";
            if (sampleTimeFactor >= (DEFAULT_SAMPLE_TIME_FACTOR)) this.sampleTimeFactor = sampleTimeFactor;
            else this.sampleTimeFactor = DEFAULT_SAMPLE_TIME_FACTOR;
            sampleStep = this.sampleTimeFactor;
            this.sensorIdToShow = Convert.ToInt32(numericUpDownSensorSelector.Value);
            firtStart = false;
            notifyIcon = new NotifyIcon();
            chartTimer = new Timer();
            chartTimer.Tick += new EventHandler(OnChartEvent);
            //chartTimer.Interval = (int)(DEFAULT_SAMPLE_TIME * 500); // sample time needs to be less than the default (fast collector and slow sender)
            //chartTimer.Interval = 1; // sample time needs to be less than the default (fast collector and slow sender)
            chartTimer.Start();

            dataCounter = 0;
        }

        private void initCharts()
        {
            charts[0] = chartX;
            charts[1] = chartY;
            charts[2] = chartZ;
            charts[3] = chartXYZ;

            for (int i = 0; i < charts.Length; i++)
            {
                chartSeries[i] = charts[i].Series[0];
                chartSeries[i].ChartType = SeriesChartType.Line;
                chartSeries[i].IsXValueIndexed = false;
                charts[i].Series[0].BorderWidth = 3;
                charts[i].Series[0].Color = graphLineColors[i];
                charts[i].ChartAreas[0].AxisY.Interval = 10;
                charts[i].ChartAreas[0].AxisY.Minimum = -100;
                charts[i].ChartAreas[0].AxisY.Maximum = 100;
                charts[i].ChartAreas[0].AxisX.Title = "Timestamp [ms]";
                charts[i].ChartAreas[0].AxisY.Title = "Angle " + chartXaxisLabel[i] + " [deg]";
                charts[i].ChartAreas[0].AxisY.MajorGrid.Interval = 5;
            }

            // Set property for the other series of chart 4
            for (int i = 4; i < 6; i++)
            {
                chartSeries[i] = charts[3].Series[i-3];
                chartSeries[i].ChartType = SeriesChartType.Line;
                charts[3].Series[i-3].BorderWidth = 3;
                charts[3].Series[i-3].Color = graphLineColors[i-3];
            }
        }

        private void OnChartEvent(object sender, EventArgs e)
        {
            
            if ((chartData[0] != -9999) && (chartData[1] != -9999) && (chartData[2] != -9999) && (chartData[3] != -9999))
            {

                    //if (((dataCounter > 0) && ((Decimal)chartDataCont[dataCounter - 1].GetValue(3) != chartData[3])) || (dataCounter == 0))
                    //{
                        //chartDataCont[dataCounter] = chartData;
                        setDataToGraph(chartData);
                        dataCounter++;
                    //}
                
            } 
        }

        private void setTitle(string name)
        {
            this.graphName = name;
            Title title = chartXYZ.Titles.Add("Movement angle right leg");
            //title.Font = new System.Drawing.Font("Arial", 16, FontStyle.Bold);           
        }

        public void setNewChartData(Decimal[] message, string currentSensorID)
        {
            if (sensorIdToShow == Int32.Parse(currentSensorID))
            {
                //if (sampleStep == sampleTimeFactor)
                //{
                this.chartData = message;
                //    sampleStep = DEFAULT_SAMPLE_TIME_FACTOR;
                //}
                //else
                //{
                //    sampleStep++;
                //}
            }
        }

        private void setDataToGraph(Decimal[] chartData)
        {
                        chartX.ChartAreas[0].AxisX.Title = "Timestamp [ms]";
            chartX.ChartAreas[0].AxisY.Title = "Angle " + chartXaxisLabel[0] + " [deg]";

            chartY.ChartAreas[0].AxisX.Title = "Timestamp [ms]";
            chartY.ChartAreas[0].AxisY.Title = "Angle " + chartXaxisLabel[1] + " [deg]";

            chartZ.ChartAreas[0].AxisX.Title = "Timestamp [ms]";
            chartZ.ChartAreas[0].AxisY.Title = "Angle " + chartXaxisLabel[2] + " [deg]";

            chartXYZ.ChartAreas[0].AxisX.Title = "Timestamp [ms]";
            chartXYZ.ChartAreas[0].AxisY.Title = "Angle " + chartXaxisLabel[3] + " [deg]";


            // Add data to graph (timestamp for y, sensor data for x)
            chartSeries[0].Points.AddXY(chartData[3], chartData[0]);
            chartX.Invalidate();

            chartSeries[1].Points.AddXY(chartData[3], chartData[1]);
            chartY.Invalidate();

            chartSeries[2].Points.AddXY(chartData[3], chartData[2]);
            chartZ.Invalidate();

            //chartSeries[3].Points.AddXY(chartData[3], chartData[0]);
            //chartSeries[4].Points.AddXY(chartData[3], chartData[1]);
            //chartSeries[5].Points.AddXY(chartData[3], chartData[2]);
            chartXYZ.Invalidate();

            
        }

        private void Snapshot_Click(object sender, EventArgs e)
        {
            ScreenCapture sc = new ScreenCapture();

            // capture entire screen, and save it to a file
            Image img = sc.CaptureScreen();
       
            // capture this window, and save it
            sc.CaptureWindowToFile(this.Handle, FILE_SAVE_PATH + graphName + ".png", ImageFormat.Png);
         
            notifyIcon.Visible = true;

            notifyIcon.BalloonTipTitle = "Movement Diagnose Data";
            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.BalloonTipText = "Screenshot created succesfully";
            notifyIcon.ShowBalloonTip(300);
            
        }

        private void FormX_Closing(object sender, FormClosingEventArgs e)
        {
            formBaseContext.setCheckboxUnchecked_X = CheckState.Unchecked;
            if (notifyIcon != null) notifyIcon.Dispose();

            chartTimer.Stop();
            chartTimer.Dispose();
            chartsExitEventHandler();
        }

        private void numericUpDownSensorSelector_valueChanged(object sender, EventArgs e)
        {
            chartX.Series[0].Points.Clear();
            chartY.Series[0].Points.Clear();
            chartZ.Series[0].Points.Clear();
            for (int i = 0; i < 3; i++) chartXYZ.Series[i].Points.Clear();

            dataCounter = 0;

            this.sensorIdToShow = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

    }
}
