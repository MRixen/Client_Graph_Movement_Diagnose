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

        public FormY()
        {
            InitializeComponent();
            firtStart = false;
            // label1.Text = "Bereich: " + MIN_X_INCREMENT + " - " + MAX_X_INCREMENT;
            notifyIcon = new NotifyIcon();
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

        public void UpdateChart1(string[] msg)
        {
            setDataToGraph(msg);
        }

        public Chart getChart()
        {
            return chartY;
        }

        void tcpDiagnoseServer_statusChangedEvent(string statusMessage)
        {
            //try
            //{
            //    if (tcpDiagnoseServer.dllConfiguration.debuggingActive == true)
            //    {
            //        this.writer.WriteLine("Statuschange - Diagnose: " + statusMessage);
            //        this.writer.Flush();
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        //public void SetConfigurationPath(String configurationpath)
        //{
        //    dllConfigurationFileName = configurationpath;

        //    this.loadConfiguration();
        //}

        void tcpPLCServer_errorEvent(string errorMessage)
        {
            System.Windows.Forms.MessageBox.Show("Error occured - " + errorMessage);
        }

        void tcpDiagnoseServer_messageReceivedEvent(string[] receivedMessage)
        {           
            //Debug.Write("rec message: " + receivedMessage[0] + "\n");
            Debug.Write("rec command: " + receivedMessage[1] + "\n");  

            String message = receivedMessage[0];
            String command = receivedMessage[1];
            try
            {
                switch (command)
                {

                    case "0":
                        // remove x, y, z character in message string
                        message = message.Replace("x", "");
                        message = message.Replace("y", "");
                        message = message.Replace("z", "");
                        //message = message.Replace(".", ",");
                        Debug.Write("mod message: " + message + "\n");  

                        // Split message to x, y, z and timestamp value
                        String[] messageData = message.Split(':');

                        //Debug.Write("Run UpdatChart1\n");
                        chartY.Invoke(new RBC.TcpIpCommunicationUnit.UpdateChartCallback(this.UpdateChart1),
                        new object[] { messageData });
                        break;
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    default:
                        break;
                }
            }
            catch (InvalidOperationException e)
            {

            }
        }

        //private void loadConfiguration()
        //{
        //    //if (System.IO.File.Exists(this.dllConfigurationFileName))
        //    //{
        //    //    System.Xml.Serialization.XmlSerializer formatter = new System.Xml.Serialization.XmlSerializer(typeof(RBC.Configuration));
        //    //    System.IO.FileStream aFile = new System.IO.FileStream(this.dllConfigurationFileName, System.IO.FileMode.Open);
        //    //    byte[] buffer = new byte[aFile.Length];
        //    //    aFile.Read(buffer, 0, (int)aFile.Length);
        //    //    System.IO.MemoryStream stream = new System.IO.MemoryStream(buffer);
        //    //    this.dllConfiguration = (RBC.Configuration)formatter.Deserialize(stream);
        //    //    aFile.Close();
        //    //    stream.Close();
        //    //}
        //    //else
        //    //{

        //        this.dllConfiguration = new RBC.Configuration();
        //        this.dllConfiguration.debuggingActive = false;
        //    //}
        //}

        private void cyclesButtonClicked(object sender, EventArgs e)
        {
            //try
            //{
            //    int xAxisRateTemp = Int32.Parse(textBox1.Text);
            //    if ((xAxisRateTemp >= 1) && (xAxisRateTemp <= 10)) xAxisRate = xAxisRateTemp;
            //}
            //catch (System.FormatException ex)
            //{

            //}
        }

        private void setDataToGraph(String[] message)
        {
            //Debug.Write("message[1]: " + message[1] + "\n");

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

            //stopWatch2.Start();

            //if ((message[1] != messageOld) && ((stopWatch2.ElapsedMilliseconds) >= (stopWatchOld + (xAxisRate * 1000))))
            //{
                // Add data to graph (timestamp for y, sensor data for x)
                seriesY.Points.AddXY(message[3], message[1]);
                chartY.Invalidate();
                //stopWatchOld = stopWatch2.ElapsedMilliseconds;
            //}
            //messageOld = message[1];
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.Equals((sender as Button).Name, @"CloseButton"))
            {
                // Do something proper to CloseButton.
            }
            else
            {
                tcpDiagnoseClient.closeAllConnections();
            }

            if(notifyIcon != null) notifyIcon.Dispose();
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

            notifyIcon.BalloonTipTitle = "Movement Diagnose";
            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.BalloonTipText = "Screenshot created succesfully";
            notifyIcon.ShowBalloonTip(1000);
            
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
                    }


    }
}
