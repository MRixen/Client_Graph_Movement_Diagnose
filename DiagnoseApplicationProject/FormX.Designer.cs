using System;
namespace WindowsFormsApplication6
{
    partial class FormX
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_sensorID = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Snapshot = new System.Windows.Forms.Button();
            this.chartX = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.numericUpDownSensorSelector = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSensorSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartX, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(715, 644);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDownSensorSelector);
            this.panel1.Controls.Add(this.label_sensorID);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.Snapshot);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(709, 29);
            this.panel1.TabIndex = 4;
            // 
            // label_sensorID
            // 
            this.label_sensorID.AutoSize = true;
            this.label_sensorID.Location = new System.Drawing.Point(249, 8);
            this.label_sensorID.Name = "label_sensorID";
            this.label_sensorID.Size = new System.Drawing.Size(57, 13);
            this.label_sensorID.TabIndex = 9;
            this.label_sensorID.Text = "Sensor ID:";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(89, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Pause";
            this.toolTip1.SetToolTip(this.button3, "Create an image of the graph.");
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(169, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Clear";
            this.toolTip1.SetToolTip(this.button2, "Create an image of the graph.");
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Snapshot
            // 
            this.Snapshot.Location = new System.Drawing.Point(9, 3);
            this.Snapshot.Name = "Snapshot";
            this.Snapshot.Size = new System.Drawing.Size(74, 23);
            this.Snapshot.TabIndex = 6;
            this.Snapshot.Text = "Snapshot";
            this.toolTip1.SetToolTip(this.Snapshot, "Create an image of the graph.");
            this.Snapshot.UseVisualStyleBackColor = true;
            this.Snapshot.Click += new System.EventHandler(this.Snapshot_Click);
            // 
            // chartX
            // 
            chartArea1.Name = "ChartArea1";
            this.chartX.ChartAreas.Add(chartArea1);
            this.chartX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartX.Location = new System.Drawing.Point(3, 38);
            this.chartX.Name = "chartX";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chartX.Series.Add(series1);
            this.chartX.Size = new System.Drawing.Size(709, 603);
            this.chartX.TabIndex = 3;
            this.chartX.Text = "chartX";
            title1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            this.chartX.Titles.Add(title1);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // numericUpDownSensorSelector
            // 
            this.numericUpDownSensorSelector.Location = new System.Drawing.Point(310, 5);
            this.numericUpDownSensorSelector.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownSensorSelector.Name = "numericUpDownSensorSelector";
            this.numericUpDownSensorSelector.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownSensorSelector.TabIndex = 10;
            this.numericUpDownSensorSelector.ValueChanged += new System.EventHandler(this.numericUpDownSensorSelector_valueChanged);
            // 
            // FormX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 644);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "FormX";
            this.Text = "Movement Diagnose - Window 1 (X-Value)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormX_Closing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSensorSelector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        // Added
        private String messageOld = "";
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Snapshot;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartX;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_sensorID;
        private System.Windows.Forms.NumericUpDown numericUpDownSensorSelector;
    }
}

