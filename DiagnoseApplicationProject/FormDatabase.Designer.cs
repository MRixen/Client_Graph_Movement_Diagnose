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
            this.button_importToDb = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button_exportToTxt = new System.Windows.Forms.Button();
            this.checkBox_showDatabase = new System.Windows.Forms.CheckBox();
            this.textBox_sampleTimeFactorGraph = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_maxSamples = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_sampleTimeFactor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.labelSavedRows = new System.Windows.Forms.Label();
            this.label_recordDurationMin = new System.Windows.Forms.Label();
            this.backgroundWorker_CalculateRecordDuration = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_loadTxtToDb = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_DataSet = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_DeleteDb = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_CheckAliveState = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_saveDbToTxt = new System.ComponentModel.BackgroundWorker();
            this.label_recordDurationSec = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_aliveIcon = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_dataBaseId = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_recordToDb
            // 
            this.button_recordToDb.Enabled = false;
            this.button_recordToDb.Location = new System.Drawing.Point(14, 52);
            this.button_recordToDb.Name = "button_recordToDb";
            this.button_recordToDb.Size = new System.Drawing.Size(100, 23);
            this.button_recordToDb.TabIndex = 9;
            this.button_recordToDb.Text = "Record to db";
            this.button_recordToDb.UseVisualStyleBackColor = true;
            this.button_recordToDb.Click += new System.EventHandler(this.recordToDb_Click);
            // 
            // checkBox_showGraphs
            // 
            this.checkBox_showGraphs.AutoSize = true;
            this.checkBox_showGraphs.Location = new System.Drawing.Point(6, 35);
            this.checkBox_showGraphs.Name = "checkBox_showGraphs";
            this.checkBox_showGraphs.Size = new System.Drawing.Size(83, 17);
            this.checkBox_showGraphs.TabIndex = 12;
            this.checkBox_showGraphs.Text = "Show graph";
            this.checkBox_showGraphs.UseVisualStyleBackColor = true;
            this.checkBox_showGraphs.CheckStateChanged += new System.EventHandler(this.checkBox_showGraphs_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox_dataBaseId);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.checkBox_showDatabase);
            this.groupBox1.Controls.Add(this.textBox_sampleTimeFactorGraph);
            this.groupBox1.Controls.Add(this.checkBox_showGraphs);
            this.groupBox1.Location = new System.Drawing.Point(10, 238);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 112);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // button_importToDb
            // 
            this.button_importToDb.Location = new System.Drawing.Point(269, 51);
            this.button_importToDb.Name = "button_importToDb";
            this.button_importToDb.Size = new System.Drawing.Size(156, 23);
            this.button_importToDb.TabIndex = 36;
            this.button_importToDb.Text = "Import extracted steps to db";
            this.button_importToDb.UseVisualStyleBackColor = true;
            this.button_importToDb.Click += new System.EventHandler(this.button_importToDb_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Sample time factor (x * 0.01)";
            // 
            // button_exportToTxt
            // 
            this.button_exportToTxt.Location = new System.Drawing.Point(269, 22);
            this.button_exportToTxt.Name = "button_exportToTxt";
            this.button_exportToTxt.Size = new System.Drawing.Size(156, 23);
            this.button_exportToTxt.TabIndex = 35;
            this.button_exportToTxt.Text = "Export db to txt file";
            this.button_exportToTxt.UseVisualStyleBackColor = true;
            this.button_exportToTxt.Click += new System.EventHandler(this.button_exportToTxt_Click);
            // 
            // checkBox_showDatabase
            // 
            this.checkBox_showDatabase.AutoSize = true;
            this.checkBox_showDatabase.Location = new System.Drawing.Point(6, 73);
            this.checkBox_showDatabase.Name = "checkBox_showDatabase";
            this.checkBox_showDatabase.Size = new System.Drawing.Size(100, 17);
            this.checkBox_showDatabase.TabIndex = 12;
            this.checkBox_showDatabase.Text = "Show database";
            this.checkBox_showDatabase.UseVisualStyleBackColor = true;
            this.checkBox_showDatabase.CheckedChanged += new System.EventHandler(this.checkBox_showDatabase_CheckedChanged);
            // 
            // textBox_sampleTimeFactorGraph
            // 
            this.textBox_sampleTimeFactorGraph.Location = new System.Drawing.Point(113, 32);
            this.textBox_sampleTimeFactorGraph.Name = "textBox_sampleTimeFactorGraph";
            this.textBox_sampleTimeFactorGraph.Size = new System.Drawing.Size(54, 20);
            this.textBox_sampleTimeFactorGraph.TabIndex = 35;
            this.textBox_sampleTimeFactorGraph.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Saved rows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Max. samples";
            // 
            // textBox_maxSamples
            // 
            this.textBox_maxSamples.Location = new System.Drawing.Point(12, 161);
            this.textBox_maxSamples.Name = "textBox_maxSamples";
            this.textBox_maxSamples.Size = new System.Drawing.Size(71, 20);
            this.textBox_maxSamples.TabIndex = 18;
            this.textBox_maxSamples.TextChanged += new System.EventHandler(this.textBox_maxSamples_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Sample time factor (x * 0.01)";
            // 
            // textBox_sampleTimeFactor
            // 
            this.textBox_sampleTimeFactor.Location = new System.Drawing.Point(102, 161);
            this.textBox_sampleTimeFactor.Name = "textBox_sampleTimeFactor";
            this.textBox_sampleTimeFactor.Size = new System.Drawing.Size(52, 20);
            this.textBox_sampleTimeFactor.TabIndex = 20;
            this.textBox_sampleTimeFactor.Text = "10";
            this.textBox_sampleTimeFactor.TextChanged += new System.EventHandler(this.textBox_sampleTimeFactor_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(242, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Record duration";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // labelSavedRows
            // 
            this.labelSavedRows.BackColor = System.Drawing.SystemColors.Window;
            this.labelSavedRows.Location = new System.Drawing.Point(136, 56);
            this.labelSavedRows.Name = "labelSavedRows";
            this.labelSavedRows.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.labelSavedRows.Size = new System.Drawing.Size(63, 20);
            this.labelSavedRows.TabIndex = 29;
            // 
            // label_recordDurationMin
            // 
            this.label_recordDurationMin.BackColor = System.Drawing.SystemColors.Window;
            this.label_recordDurationMin.CausesValidation = false;
            this.label_recordDurationMin.Location = new System.Drawing.Point(266, 161);
            this.label_recordDurationMin.Name = "label_recordDurationMin";
            this.label_recordDurationMin.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label_recordDurationMin.Size = new System.Drawing.Size(63, 20);
            this.label_recordDurationMin.TabIndex = 30;
            // 
            // label_recordDurationSec
            // 
            this.label_recordDurationSec.BackColor = System.Drawing.SystemColors.Window;
            this.label_recordDurationSec.CausesValidation = false;
            this.label_recordDurationSec.Location = new System.Drawing.Point(348, 161);
            this.label_recordDurationSec.Name = "label_recordDurationSec";
            this.label_recordDurationSec.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label_recordDurationSec.Size = new System.Drawing.Size(63, 20);
            this.label_recordDurationSec.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(348, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "[sec]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(266, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "[min]";
            // 
            // label_aliveIcon
            // 
            this.label_aliveIcon.AutoSize = true;
            this.label_aliveIcon.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label_aliveIcon.Location = new System.Drawing.Point(16, 36);
            this.label_aliveIcon.MinimumSize = new System.Drawing.Size(95, 13);
            this.label_aliveIcon.Name = "label_aliveIcon";
            this.label_aliveIcon.Size = new System.Drawing.Size(95, 13);
            this.label_aliveIcon.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(110, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Database - Nr.:";
            // 
            // textBox_dataBaseId
            // 
            this.textBox_dataBaseId.Location = new System.Drawing.Point(112, 73);
            this.textBox_dataBaseId.Name = "textBox_dataBaseId";
            this.textBox_dataBaseId.Size = new System.Drawing.Size(55, 20);
            this.textBox_dataBaseId.TabIndex = 37;
            this.textBox_dataBaseId.Text = "1";
            // 
            // FormDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.label_aliveIcon);
            this.Controls.Add(this.button_importToDb);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label_recordDurationSec);
            this.Controls.Add(this.button_exportToTxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label_recordDurationMin);
            this.Controls.Add(this.labelSavedRows);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_sampleTimeFactor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_maxSamples);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_recordToDb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 400);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "FormDatabase";
            this.Text = "Movement Diagnose";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDatabase_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDatabase_Closed);
            this.Load += new System.EventHandler(this.FormDatabase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_sampleTimeFactor;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_sampleTimeFactorGraph;
        private System.Windows.Forms.Button button_importToDb;
        private System.Windows.Forms.Button button_exportToTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_dataBaseId;
    }
}