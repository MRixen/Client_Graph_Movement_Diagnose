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
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_dataBaseId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox_showDatabase = new System.Windows.Forms.CheckBox();
            this.textBox_sampleTimeFactorGraph = new System.Windows.Forms.TextBox();
            this.button_importToDb = new System.Windows.Forms.Button();
            this.button_exportToTxt = new System.Windows.Forms.Button();
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_recordToDb
            // 
            this.button_recordToDb.Enabled = false;
            this.button_recordToDb.Location = new System.Drawing.Point(19, 64);
            this.button_recordToDb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.checkBox_showGraphs.Location = new System.Drawing.Point(8, 43);
            this.checkBox_showGraphs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_showGraphs.Name = "checkBox_showGraphs";
            this.checkBox_showGraphs.Size = new System.Drawing.Size(105, 21);
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
            this.groupBox1.Location = new System.Drawing.Point(13, 293);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(613, 138);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(147, 70);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 17);
            this.label8.TabIndex = 38;
            this.label8.Text = "Database - Nr.:";
            // 
            // textBox_dataBaseId
            // 
            this.textBox_dataBaseId.Location = new System.Drawing.Point(149, 90);
            this.textBox_dataBaseId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_dataBaseId.Name = "textBox_dataBaseId";
            this.textBox_dataBaseId.Size = new System.Drawing.Size(72, 22);
            this.textBox_dataBaseId.TabIndex = 37;
            this.textBox_dataBaseId.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(148, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 17);
            this.label7.TabIndex = 36;
            this.label7.Text = "Sample time factor (x * 0.01)";
            // 
            // checkBox_showDatabase
            // 
            this.checkBox_showDatabase.AutoSize = true;
            this.checkBox_showDatabase.Location = new System.Drawing.Point(8, 90);
            this.checkBox_showDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_showDatabase.Name = "checkBox_showDatabase";
            this.checkBox_showDatabase.Size = new System.Drawing.Size(127, 21);
            this.checkBox_showDatabase.TabIndex = 12;
            this.checkBox_showDatabase.Text = "Show database";
            this.checkBox_showDatabase.UseVisualStyleBackColor = true;
            this.checkBox_showDatabase.CheckedChanged += new System.EventHandler(this.checkBox_showDatabase_CheckedChanged);
            // 
            // textBox_sampleTimeFactorGraph
            // 
            this.textBox_sampleTimeFactorGraph.Location = new System.Drawing.Point(151, 39);
            this.textBox_sampleTimeFactorGraph.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_sampleTimeFactorGraph.Name = "textBox_sampleTimeFactorGraph";
            this.textBox_sampleTimeFactorGraph.Size = new System.Drawing.Size(71, 22);
            this.textBox_sampleTimeFactorGraph.TabIndex = 35;
            this.textBox_sampleTimeFactorGraph.Text = "1";
            // 
            // button_importToDb
            // 
            this.button_importToDb.Location = new System.Drawing.Point(359, 63);
            this.button_importToDb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_importToDb.Name = "button_importToDb";
            this.button_importToDb.Size = new System.Drawing.Size(208, 28);
            this.button_importToDb.TabIndex = 36;
            this.button_importToDb.Text = "Import extracted steps to db";
            this.button_importToDb.UseVisualStyleBackColor = true;
            this.button_importToDb.Click += new System.EventHandler(this.button_importToDb_Click);
            // 
            // button_exportToTxt
            // 
            this.button_exportToTxt.Location = new System.Drawing.Point(359, 27);
            this.button_exportToTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_exportToTxt.Name = "button_exportToTxt";
            this.button_exportToTxt.Size = new System.Drawing.Size(208, 28);
            this.button_exportToTxt.TabIndex = 35;
            this.button_exportToTxt.Text = "Export db to txt file";
            this.button_exportToTxt.UseVisualStyleBackColor = true;
            this.button_exportToTxt.Click += new System.EventHandler(this.button_exportToTxt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Saved rows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Max. samples";
            // 
            // textBox_maxSamples
            // 
            this.textBox_maxSamples.Location = new System.Drawing.Point(16, 198);
            this.textBox_maxSamples.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_maxSamples.Name = "textBox_maxSamples";
            this.textBox_maxSamples.Size = new System.Drawing.Size(93, 22);
            this.textBox_maxSamples.TabIndex = 18;
            this.textBox_maxSamples.TextChanged += new System.EventHandler(this.textBox_maxSamples_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 178);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Sample time factor (x * 0.01)";
            // 
            // textBox_sampleTimeFactor
            // 
            this.textBox_sampleTimeFactor.Location = new System.Drawing.Point(136, 198);
            this.textBox_sampleTimeFactor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_sampleTimeFactor.Name = "textBox_sampleTimeFactor";
            this.textBox_sampleTimeFactor.Size = new System.Drawing.Size(68, 22);
            this.textBox_sampleTimeFactor.TabIndex = 20;
            this.textBox_sampleTimeFactor.Text = "1";
            this.textBox_sampleTimeFactor.TextChanged += new System.EventHandler(this.textBox_sampleTimeFactor_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(113, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(323, 198);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 25);
            this.label5.TabIndex = 23;
            this.label5.Text = "=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(355, 159);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "Record duration";
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
            this.labelSavedRows.Location = new System.Drawing.Point(181, 69);
            this.labelSavedRows.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSavedRows.Name = "labelSavedRows";
            this.labelSavedRows.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.labelSavedRows.Size = new System.Drawing.Size(84, 25);
            this.labelSavedRows.TabIndex = 29;
            // 
            // label_recordDurationMin
            // 
            this.label_recordDurationMin.BackColor = System.Drawing.SystemColors.Window;
            this.label_recordDurationMin.CausesValidation = false;
            this.label_recordDurationMin.Location = new System.Drawing.Point(355, 198);
            this.label_recordDurationMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_recordDurationMin.Name = "label_recordDurationMin";
            this.label_recordDurationMin.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label_recordDurationMin.Size = new System.Drawing.Size(84, 25);
            this.label_recordDurationMin.TabIndex = 30;
            // 
            // label_recordDurationSec
            // 
            this.label_recordDurationSec.BackColor = System.Drawing.SystemColors.Window;
            this.label_recordDurationSec.CausesValidation = false;
            this.label_recordDurationSec.Location = new System.Drawing.Point(464, 198);
            this.label_recordDurationSec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_recordDurationSec.Name = "label_recordDurationSec";
            this.label_recordDurationSec.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label_recordDurationSec.Size = new System.Drawing.Size(84, 25);
            this.label_recordDurationSec.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(464, 178);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 17);
            this.label10.TabIndex = 31;
            this.label10.Text = "[sec]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(355, 178);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 17);
            this.label11.TabIndex = 33;
            this.label11.Text = "[min]";
            // 
            // label_aliveIcon
            // 
            this.label_aliveIcon.AutoSize = true;
            this.label_aliveIcon.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label_aliveIcon.Location = new System.Drawing.Point(21, 44);
            this.label_aliveIcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_aliveIcon.MinimumSize = new System.Drawing.Size(127, 16);
            this.label_aliveIcon.Name = "label_aliveIcon";
            this.label_aliveIcon.Size = new System.Drawing.Size(127, 17);
            this.label_aliveIcon.TabIndex = 34;
            // 
            // FormDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 434);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(661, 481);
            this.MinimumSize = new System.Drawing.Size(661, 481);
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