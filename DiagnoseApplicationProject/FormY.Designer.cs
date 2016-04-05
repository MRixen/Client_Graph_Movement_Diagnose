using System;
namespace WindowsFormsApplication6
{
    partial class FormY
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
            this.chartY = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownSensorSelector = new System.Windows.Forms.NumericUpDown();
            this.label_sensorID = new System.Windows.Forms.Label();
            this.Snapshot = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartY)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSensorSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.chartY, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(730, 658);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // chartY
            // 
            chartArea1.Name = "ChartArea1";
            this.chartY.ChartAreas.Add(chartArea1);
            this.chartY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartY.Location = new System.Drawing.Point(3, 38);
            this.chartY.Name = "chartY";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chartY.Series.Add(series1);
            this.chartY.Size = new System.Drawing.Size(724, 617);
            this.chartY.TabIndex = 3;
            this.chartY.Text = "chartY";
            title1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            this.chartY.Titles.Add(title1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDownSensorSelector);
            this.panel1.Controls.Add(this.label_sensorID);
            this.panel1.Controls.Add(this.Snapshot);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 29);
            this.panel1.TabIndex = 5;
            // 
            // numericUpDownSensorSelector
            // 
            this.numericUpDownSensorSelector.Location = new System.Drawing.Point(152, 5);
            this.numericUpDownSensorSelector.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownSensorSelector.Name = "numericUpDownSensorSelector";
            this.numericUpDownSensorSelector.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownSensorSelector.TabIndex = 12;
            this.numericUpDownSensorSelector.ValueChanged += new System.EventHandler(this.numericUpDownSensorSelector_valueChanged);
            // 
            // label_sensorID
            // 
            this.label_sensorID.AutoSize = true;
            this.label_sensorID.Location = new System.Drawing.Point(89, 8);
            this.label_sensorID.Name = "label_sensorID";
            this.label_sensorID.Size = new System.Drawing.Size(57, 13);
            this.label_sensorID.TabIndex = 11;
            this.label_sensorID.Text = "Sensor ID:";
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
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // FormY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 658);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "FormY";
            this.Text = "Movement Diagnose - Window 2 (Y-Value)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormY_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartY)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSensorSelector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        // Added
        private String messageOld = "";
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartY;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Snapshot;
        private System.Windows.Forms.Label label_sensorID;
        private System.Windows.Forms.NumericUpDown numericUpDownSensorSelector;
    }
}

