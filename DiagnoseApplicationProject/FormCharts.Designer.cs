using System;
namespace WindowsFormsApplication6
{
    partial class FormCharts
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartZ = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartXYZ = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownSensorSelector = new System.Windows.Forms.NumericUpDown();
            this.label_sensorID = new System.Windows.Forms.Label();
            this.Snapshot = new System.Windows.Forms.Button();
            this.chartY = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartX = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_measurementContext = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartXYZ)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSensorSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartX)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chartZ, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chartXYZ, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartY, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartX, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 562);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // chartZ
            // 
            chartArea1.Name = "ChartArea1";
            this.chartZ.ChartAreas.Add(chartArea1);
            this.chartZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartZ.Location = new System.Drawing.Point(3, 301);
            this.chartZ.Name = "chartZ";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chartZ.Series.Add(series1);
            this.chartZ.Size = new System.Drawing.Size(286, 258);
            this.chartZ.TabIndex = 9;
            this.chartZ.Text = "chartZ";
            title1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            this.chartZ.Titles.Add(title1);
            // 
            // chartXYZ
            // 
            chartArea2.Name = "ChartArea1";
            this.chartXYZ.ChartAreas.Add(chartArea2);
            this.chartXYZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartXYZ.Location = new System.Drawing.Point(295, 301);
            this.chartXYZ.Name = "chartXYZ";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series2";
            series4.ChartArea = "ChartArea1";
            series4.Name = "Series3";
            this.chartXYZ.Series.Add(series2);
            this.chartXYZ.Series.Add(series3);
            this.chartXYZ.Series.Add(series4);
            this.chartXYZ.Size = new System.Drawing.Size(286, 258);
            this.chartXYZ.TabIndex = 3;
            this.chartXYZ.Text = "chartXYZ";
            title2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            this.chartXYZ.Titles.Add(title2);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDownSensorSelector);
            this.panel1.Controls.Add(this.label_sensorID);
            this.panel1.Controls.Add(this.Snapshot);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 29);
            this.panel1.TabIndex = 4;
            // 
            // numericUpDownSensorSelector
            // 
            this.numericUpDownSensorSelector.Location = new System.Drawing.Point(150, 5);
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
            // label_sensorID
            // 
            this.label_sensorID.AutoSize = true;
            this.label_sensorID.Location = new System.Drawing.Point(89, 8);
            this.label_sensorID.Name = "label_sensorID";
            this.label_sensorID.Size = new System.Drawing.Size(57, 13);
            this.label_sensorID.TabIndex = 9;
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
            // chartY
            // 
            chartArea3.Name = "ChartArea1";
            this.chartY.ChartAreas.Add(chartArea3);
            this.chartY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartY.Location = new System.Drawing.Point(295, 38);
            this.chartY.Name = "chartY";
            series5.ChartArea = "ChartArea1";
            series5.Name = "Series1";
            this.chartY.Series.Add(series5);
            this.chartY.Size = new System.Drawing.Size(286, 257);
            this.chartY.TabIndex = 6;
            this.chartY.Text = "chartY";
            title3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Title1";
            this.chartY.Titles.Add(title3);
            // 
            // chartX
            // 
            chartArea4.Name = "ChartArea1";
            this.chartX.ChartAreas.Add(chartArea4);
            this.chartX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartX.Location = new System.Drawing.Point(3, 38);
            this.chartX.Name = "chartX";
            series6.ChartArea = "ChartArea1";
            series6.Name = "Series1";
            this.chartX.Series.Add(series6);
            this.chartX.Size = new System.Drawing.Size(286, 257);
            this.chartX.TabIndex = 7;
            this.chartX.Text = "chartX";
            title4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.Name = "Title1";
            this.chartX.Titles.Add(title4);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_measurementContext);
            this.panel2.Location = new System.Drawing.Point(295, 3);
            this.panel2.MinimumSize = new System.Drawing.Size(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 29);
            this.panel2.TabIndex = 8;
            // 
            // label_measurementContext
            // 
            this.label_measurementContext.AutoSize = true;
            this.label_measurementContext.Location = new System.Drawing.Point(3, 8);
            this.label_measurementContext.Name = "label_measurementContext";
            this.label_measurementContext.Size = new System.Drawing.Size(115, 13);
            this.label_measurementContext.TabIndex = 9;
            this.label_measurementContext.Text = "Measurement context: ";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // FormCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "FormCharts";
            this.Text = "Movement Diagnose - Window 1 (X-Value)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormX_Closing);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartXYZ)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSensorSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartX)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chartXYZ;
        private System.Windows.Forms.Label label_sensorID;
        private System.Windows.Forms.NumericUpDown numericUpDownSensorSelector;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartY;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartX;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_measurementContext;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartZ;
    }
}

