namespace WindowsFormsApplication6
{
    partial class FormDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDatabase));
            this.button_recordToDb = new System.Windows.Forms.Button();
            this.checkBox_showGraphs = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_maxSamples = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_recordDurationMin = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_recordDurationSec = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonCalibrateSensors = new System.Windows.Forms.Button();
            this.checkBox_showCalibData = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_context = new System.Windows.Forms.TextBox();
            this.checkBox_showDatabase = new System.Windows.Forms.CheckBox();
            this.button_importToDb = new System.Windows.Forms.Button();
            this.button_exportToTxt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.labelSavedRows = new System.Windows.Forms.Label();
            this.backgroundWorker_CalculateRecordDuration = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_loadTxtToDb = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_DataSet = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_DeleteDb = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_CheckAliveState = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_saveDbToTxt = new System.ComponentModel.BackgroundWorker();
            this.label_aliveIcon = new System.Windows.Forms.Label();
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.button_Ok = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_dbTableName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_recordToDb
            // 
            this.button_recordToDb.Enabled = false;
            this.button_recordToDb.Location = new System.Drawing.Point(13, 17);
            this.button_recordToDb.Margin = new System.Windows.Forms.Padding(4);
            this.button_recordToDb.Name = "button_recordToDb";
            this.button_recordToDb.Size = new System.Drawing.Size(133, 28);
            this.button_recordToDb.TabIndex = 9;
            this.button_recordToDb.Text = "Record to db";
            this.button_recordToDb.UseVisualStyleBackColor = true;
            this.button_recordToDb.Click += new System.EventHandler(this.recordToDb_Click);
            // 
            // checkBox_showGraphs
            // 
            this.checkBox_showGraphs.AutoSize = true;
            this.checkBox_showGraphs.Location = new System.Drawing.Point(447, 13);
            this.checkBox_showGraphs.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_showGraphs.Name = "checkBox_showGraphs";
            this.checkBox_showGraphs.Size = new System.Drawing.Size(105, 21);
            this.checkBox_showGraphs.TabIndex = 12;
            this.checkBox_showGraphs.Text = "Show graph";
            this.checkBox_showGraphs.UseVisualStyleBackColor = true;
            this.checkBox_showGraphs.CheckStateChanged += new System.EventHandler(this.checkBox_showGraphs_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_maxSamples);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label_recordDurationMin);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label_recordDurationSec);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.buttonCalibrateSensors);
            this.groupBox1.Controls.Add(this.checkBox_showCalibData);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox_context);
            this.groupBox1.Location = new System.Drawing.Point(14, 179);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(617, 161);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "Record duration";
            // 
            // textBox_maxSamples
            // 
            this.textBox_maxSamples.Location = new System.Drawing.Point(16, 58);
            this.textBox_maxSamples.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_maxSamples.Name = "textBox_maxSamples";
            this.textBox_maxSamples.Size = new System.Drawing.Size(93, 22);
            this.textBox_maxSamples.TabIndex = 18;
            this.textBox_maxSamples.TextChanged += new System.EventHandler(this.textBox_maxSamples_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Max. samples";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(120, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 25);
            this.label5.TabIndex = 23;
            this.label5.Text = "=";
            // 
            // label_recordDurationMin
            // 
            this.label_recordDurationMin.BackColor = System.Drawing.SystemColors.Window;
            this.label_recordDurationMin.CausesValidation = false;
            this.label_recordDurationMin.Location = new System.Drawing.Point(152, 56);
            this.label_recordDurationMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_recordDurationMin.Name = "label_recordDurationMin";
            this.label_recordDurationMin.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label_recordDurationMin.Size = new System.Drawing.Size(84, 25);
            this.label_recordDurationMin.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(261, 36);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 17);
            this.label10.TabIndex = 31;
            this.label10.Text = "[sec]";
            // 
            // label_recordDurationSec
            // 
            this.label_recordDurationSec.BackColor = System.Drawing.SystemColors.Window;
            this.label_recordDurationSec.CausesValidation = false;
            this.label_recordDurationSec.Location = new System.Drawing.Point(261, 56);
            this.label_recordDurationSec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_recordDurationSec.Name = "label_recordDurationSec";
            this.label_recordDurationSec.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label_recordDurationSec.Size = new System.Drawing.Size(84, 25);
            this.label_recordDurationSec.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(152, 36);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 17);
            this.label11.TabIndex = 33;
            this.label11.Text = "[min]";
            // 
            // buttonCalibrateSensors
            // 
            this.buttonCalibrateSensors.Location = new System.Drawing.Point(433, 19);
            this.buttonCalibrateSensors.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCalibrateSensors.Name = "buttonCalibrateSensors";
            this.buttonCalibrateSensors.Size = new System.Drawing.Size(133, 28);
            this.buttonCalibrateSensors.TabIndex = 39;
            this.buttonCalibrateSensors.Text = "Calibrate Sensors";
            this.buttonCalibrateSensors.UseVisualStyleBackColor = true;
            this.buttonCalibrateSensors.Click += new System.EventHandler(this.button_calibrateSensors);
            // 
            // checkBox_showCalibData
            // 
            this.checkBox_showCalibData.AutoSize = true;
            this.checkBox_showCalibData.Location = new System.Drawing.Point(433, 55);
            this.checkBox_showCalibData.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_showCalibData.Name = "checkBox_showCalibData";
            this.checkBox_showCalibData.Size = new System.Drawing.Size(165, 21);
            this.checkBox_showCalibData.TabIndex = 39;
            this.checkBox_showCalibData.Text = "Show calibration data";
            this.checkBox_showCalibData.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 102);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 17);
            this.label9.TabIndex = 38;
            this.label9.Text = "Filename";
            // 
            // textBox_context
            // 
            this.textBox_context.Location = new System.Drawing.Point(16, 122);
            this.textBox_context.Name = "textBox_context";
            this.textBox_context.Size = new System.Drawing.Size(168, 22);
            this.textBox_context.TabIndex = 37;
            // 
            // checkBox_showDatabase
            // 
            this.checkBox_showDatabase.AutoSize = true;
            this.checkBox_showDatabase.Location = new System.Drawing.Point(447, 38);
            this.checkBox_showDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_showDatabase.Name = "checkBox_showDatabase";
            this.checkBox_showDatabase.Size = new System.Drawing.Size(127, 21);
            this.checkBox_showDatabase.TabIndex = 12;
            this.checkBox_showDatabase.Text = "Show database";
            this.checkBox_showDatabase.UseVisualStyleBackColor = true;
            this.checkBox_showDatabase.CheckedChanged += new System.EventHandler(this.checkBox_showDatabase_CheckedChanged);
            // 
            // button_importToDb
            // 
            this.button_importToDb.Location = new System.Drawing.Point(13, 88);
            this.button_importToDb.Margin = new System.Windows.Forms.Padding(4);
            this.button_importToDb.Name = "button_importToDb";
            this.button_importToDb.Size = new System.Drawing.Size(133, 28);
            this.button_importToDb.TabIndex = 36;
            this.button_importToDb.Text = "Upload steps";
            this.button_importToDb.UseVisualStyleBackColor = true;
            this.button_importToDb.Click += new System.EventHandler(this.button_uploadSteps_Click);
            // 
            // button_exportToTxt
            // 
            this.button_exportToTxt.Location = new System.Drawing.Point(13, 52);
            this.button_exportToTxt.Margin = new System.Windows.Forms.Padding(4);
            this.button_exportToTxt.Name = "button_exportToTxt";
            this.button_exportToTxt.Size = new System.Drawing.Size(133, 28);
            this.button_exportToTxt.TabIndex = 35;
            this.button_exportToTxt.Text = "Export to txt file";
            this.button_exportToTxt.UseVisualStyleBackColor = true;
            this.button_exportToTxt.Click += new System.EventHandler(this.button_exportToTxt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Saved rows";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
            // 
            // labelSavedRows
            // 
            this.labelSavedRows.BackColor = System.Drawing.SystemColors.Window;
            this.labelSavedRows.Location = new System.Drawing.Point(157, 20);
            this.labelSavedRows.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSavedRows.Name = "labelSavedRows";
            this.labelSavedRows.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.labelSavedRows.Size = new System.Drawing.Size(119, 25);
            this.labelSavedRows.TabIndex = 29;
            // 
            // label_aliveIcon
            // 
            this.label_aliveIcon.AutoSize = true;
            this.label_aliveIcon.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label_aliveIcon.Location = new System.Drawing.Point(6, 18);
            this.label_aliveIcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_aliveIcon.MinimumSize = new System.Drawing.Size(5, 25);
            this.label_aliveIcon.Name = "label_aliveIcon";
            this.label_aliveIcon.Size = new System.Drawing.Size(5, 25);
            this.label_aliveIcon.TabIndex = 34;
            // 
            // textBox_Info
            // 
            this.textBox_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Info.ForeColor = System.Drawing.Color.Red;
            this.textBox_Info.Location = new System.Drawing.Point(7, 26);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.Size = new System.Drawing.Size(539, 50);
            this.textBox_Info.TabIndex = 40;
            // 
            // button_Ok
            // 
            this.button_Ok.Location = new System.Drawing.Point(553, 32);
            this.button_Ok.Margin = new System.Windows.Forms.Padding(4);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(53, 34);
            this.button_Ok.TabIndex = 42;
            this.button_Ok.Text = "Clear";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Clicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Info);
            this.groupBox2.Controls.Add(this.button_Ok);
            this.groupBox2.Location = new System.Drawing.Point(13, 348);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(617, 92);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 41;
            this.label4.Text = "db name";
            // 
            // textBox_dbTableName
            // 
            this.textBox_dbTableName.Location = new System.Drawing.Point(157, 95);
            this.textBox_dbTableName.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_dbTableName.Name = "textBox_dbTableName";
            this.textBox_dbTableName.Size = new System.Drawing.Size(119, 22);
            this.textBox_dbTableName.TabIndex = 40;
            // 
            // FormDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 453);
            this.Controls.Add(this.textBox_dbTableName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_recordToDb);
            this.Controls.Add(this.checkBox_showDatabase);
            this.Controls.Add(this.checkBox_showGraphs);
            this.Controls.Add(this.button_importToDb);
            this.Controls.Add(this.button_exportToTxt);
            this.Controls.Add(this.labelSavedRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_aliveIcon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(661, 500);
            this.MinimumSize = new System.Drawing.Size(661, 500);
            this.Name = "FormDatabase";
            this.Text = "Movement Diagnose";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDatabase_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDatabase_Closed);
            this.Load += new System.EventHandler(this.FormDatabase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button button_recordToDb;
        private System.Windows.Forms.CheckBox checkBox_showGraphs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_maxSamples;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox_showDatabase;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label labelSavedRows;
        public System.Windows.Forms.Label label_recordDurationMin;
        public System.Windows.Forms.Label label_recordDurationSec;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_aliveIcon;
        private System.Windows.Forms.Button button_importToDb;
        private System.Windows.Forms.Button button_exportToTxt;
        private System.Windows.Forms.TextBox textBox_context;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonCalibrateSensors;
        private System.Windows.Forms.CheckBox checkBox_showCalibData;
        private System.Windows.Forms.TextBox textBox_Info;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_dbTableName;
    }
}