﻿using System;
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
    public partial class FormX : Form
    {
        //TODO Check algorithm to split the received string (receiveFromClient(), handleMessage())
        //TOOD Add diagram
        // Save all cycletime-data with article id

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
        private FormDatabase formBaseContext;
        private int sensorID;


        public FormX(Object context, int sensorID)
        {
            InitializeComponent();
            formBaseContext = (FormDatabase)context;

            this.sensorID = sensorID;
            label_sensorID.Text = "Sensor ID: " + this.sensorID;
            firtStart = false;
            // label1.Text = "Bereich: " + MIN_X_INCREMENT + " - " + MAX_X_INCREMENT;
            notifyIcon = new NotifyIcon();

            
        }

        public Chart getChart()
        {
            return chartX;
        }

        private void setTitle(string name)
        {
            this.graphName = name;
            Title title = chartX.Titles.Add("Movement angle right leg");
            //title.Font = new System.Drawing.Font("Arial", 16, FontStyle.Bold);           
        }

        private void UpdateText(string text)
        {
            //textBox1.Text = text;
        }

        public void UpdateChart1(string[] msg)
        {
            setDataToGraph(msg);
        }

        private void setDataToGraph(String[] message)
        {
            //Debug.Write("message[0]: " + message[0] + "\n");

            var seriesX = chartX.Series[0];
            seriesX.ChartType = SeriesChartType.Line;
            chartX.Series[0].BorderWidth = 3;
            chartX.ChartAreas[0].AxisY.Interval = 5;
            chartX.ChartAreas[0].AxisY.Minimum = -60;
            chartX.ChartAreas[0].AxisY.Maximum = 60;
            chartX.ChartAreas[0].AxisX.Interval = 1;
            chartX.ChartAreas[0].AxisX.Title = "Timestamp [ms]";
            chartX.ChartAreas[0].AxisY.Title = "Angle X [deg]";
            chartX.ChartAreas[0].AxisX.MajorGrid.Interval = 1;

            //stopWatch2.Start();

            //if ((message[1] != messageOld) && ((stopWatch2.ElapsedMilliseconds) >= (stopWatchOld + (xAxisRate * 1000))))
            //{
                // Add data to graph (timestamp for y, sensor data for x)
                seriesX.Points.AddXY(message[3], message[0]);
                chartX.Invalidate();
                //stopWatchOld = stopWatch2.ElapsedMilliseconds;
            //}
            //messageOld = message[1];
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
                bitmap.Save("C://Users//Manuel.Rixen//Desktop//X_data_" + graphName + ".jpg", ImageFormat.Jpeg);
            }



            
            notifyIcon.Visible = true;

            notifyIcon.BalloonTipTitle = "Movement Diagnose X Data";
            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.BalloonTipText = "Screenshot created succesfully";
            notifyIcon.ShowBalloonTip(300);
            
        }

        private void FormX_Closing(object sender, FormClosingEventArgs e)
        {
            formBaseContext.setCheckboxUnchecked_X = CheckState.Unchecked;
            if (notifyIcon != null) notifyIcon.Dispose();
        }

    }
}
