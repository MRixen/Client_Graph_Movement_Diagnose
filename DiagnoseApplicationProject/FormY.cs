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


namespace WindowsFormsApplication6
{
    public partial class FormY : Form
    {
        //TODO Check algorithm to split the received string (receiveFromClient(), handleMessage())
        //TOOD Add diagram
        // Save all cycletime-data with article id

        //private System.IO.StreamWriter writer = new System.IO.StreamWriter("DiagnoseDebugLog.log", true);
        private RBC.TcpIpCommunicationUnit tcpDiagnoseClient = null;
        private String dllConfigurationFileName = "";
        //private RBC.Configuration dllConfiguration = null;
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
        private string graphName = "x";
        private NotifyIcon notifyIcon;
        private CheckBox checkbox;
        private FormDatabase formBaseContext;
        private int sensorID;
        private int sampleTimeFactor;
        private int sampleStep;
        private int DEFAULT_SAMPLE_TIME_FACTOR = Properties.Settings.Default.DEFAULT_SAMPLE_TIME_FACTOR;
        private int sensorIdToShow = -1;

        public delegate void ChartYExitEventHandler();
        public event ChartYExitEventHandler chartYExitEventHandler;
        private System.Timers.Timer chartTimer;

        public FormY(Object context, int sampleTimeFactor)
        {
            InitializeComponent();
            formBaseContext = (FormDatabase)context;

            if (sampleTimeFactor >= (DEFAULT_SAMPLE_TIME_FACTOR)) this.sampleTimeFactor = sampleTimeFactor;
            else this.sampleTimeFactor = DEFAULT_SAMPLE_TIME_FACTOR;
            sampleStep = DEFAULT_SAMPLE_TIME_FACTOR;
            this.sensorIdToShow = Convert.ToInt32(numericUpDownSensorSelector.Value);
            firtStart = false;
            notifyIcon = new NotifyIcon();
            chartTimer = new System.Timers.Timer();
            chartTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnChartEvent);
            chartTimer.Interval = sampleTimeFactor * DEFAULT_SAMPLE_TIME_FACTOR;
            chartTimer.Enabled = true;
        }

        private void OnChartEvent(object sender, System.Timers.ElapsedEventArgs e)
        {

        }

        public void setTitle(string name)
        {
            this.graphName = name;
            Title title = chartY.Titles.Add("Movement angle right leg");
            //title.Font = new System.Drawing.Font("Arial", 16, FontStyle.Bold);           
        }

        public void UpdateText(string text)
        {
            //textBox1.Text = text;
        }

        public void setNewChartDataY(string timestamp, string value, string currentSensorID)
        {
            if (sensorIdToShow == Int32.Parse(currentSensorID))
            {
                if (sampleStep == sampleTimeFactor)
                {
                    setDataToGraph(timestamp, value);
                    sampleStep = DEFAULT_SAMPLE_TIME_FACTOR;
                }
                else sampleStep++;
            }
        }

        public Chart getChart()
        {
            return chartY;
        }

        private void setDataToGraph(string xAxisValue, string yAxisValue)
        {
            var seriesY = chartY.Series[0];
            seriesY.ChartType = SeriesChartType.Line;
            chartY.Series[0].BorderWidth = 3;
            chartY.ChartAreas[0].AxisY.Interval = 5;
            chartY.ChartAreas[0].AxisY.Minimum = -60;
            chartY.ChartAreas[0].AxisY.Maximum = 60;
            chartY.ChartAreas[0].AxisX.Interval = 1;
            chartY.ChartAreas[0].AxisX.Title = "Timestamp [ms]";
            chartY.ChartAreas[0].AxisY.Title = "Angle Y [deg]";
            chartY.ChartAreas[0].AxisX.MajorGrid.Interval = 1;

                // Add data to graph (timestamp for y, sensor data for x)
                seriesY.Points.AddXY(xAxisValue, yAxisValue);
                chartY.Invalidate();
        }

        private void FormY_FormClosing(object sender, FormClosingEventArgs e)
        {
            formBaseContext.setCheckboxUnchecked_Y = CheckState.Unchecked;
            if(notifyIcon != null) notifyIcon.Dispose();

            chartTimer.Stop();
            chartTimer.Dispose();
            chartYExitEventHandler();
        }

        private void Snapshot_Click(object sender, EventArgs e)
        {
            Rectangle bounds = this.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                bitmap.Save("C://Users//Manuel.Rixen//Desktop//Y_data_" + graphName + ".jpg", ImageFormat.Jpeg);
            }



            
            notifyIcon.Visible = true;

            notifyIcon.BalloonTipTitle = "Movement Diagnose Y Data";
            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.BalloonTipText = "Screenshot created succesfully";
            notifyIcon.ShowBalloonTip(300);
            
        }

        private void numericUpDownSensorSelector_valueChanged(object sender, EventArgs e)
        {
            chartY.Series[0].Points.Clear();
            this.sensorIdToShow = Convert.ToInt32(((NumericUpDown)sender).Value);
        }
    }
}
