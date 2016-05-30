using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication6
{
    public partial class FormDatabase : Form
    {
        private FormCharts formCharts;
        public delegate void UpdateSavedRowCounter(string text);

        DatabaseConnection databaseConnection;
        string conString;
        DataSet dataSet_Db1, dataSet_Db2;
        DataRow dRow;
        private int[] maxTableRows_Db1;
        int inc = 0;
        private bool recordIsActive = false;

        private System.IO.StreamWriter writer = new System.IO.StreamWriter("DiagnoseDebugLog.log", true);
        private RBC.TcpIpCommunicationUnit tcpDiagnoseClient = null;
        private String dllConfigurationFileName = "";
        private int writeCycle;
        private int MAX_WRITE_CYCLE;
        private int sampleStep;
        private CheckBox xSenderCheckbox;
        private CheckBox ySenderCheckbox;
        private CheckBox zSenderCheckbox;
        private DatabaseList dataBaseList;
        private CheckBox senderCheckbox;
        private int savedRowCounter;
        private int tablePresentID = -1;
        private int MAX_TABLE_AMOUNT = Properties.Settings.Default.MAX_TABLE_AMOUNT;
        private int MIN_TABLE_AMOUNT = Properties.Settings.Default.MIN_TABLE_AMOUNT;
        private float SAMPLE_TIME = Properties.Settings.Default.SAMPLE_TIME;
        private int DEFAULT_SAMPLE_TIME_FACTOR = Properties.Settings.Default.DEFAULT_SAMPLE_TIME_FACTOR;
        private int MAX_ALIVE_SIGNAL_PAUSE = Properties.Settings.Default.MAX_ALIVE_SIGNAL_PAUSE;
        private string FILE_SAVE_PATH = Properties.Settings.Default.FILE_SAVE_PATH;

        private float recordDuration;
        //private RBC.Configuration dllConfiguration = null;

        private System.ComponentModel.BackgroundWorker backgroundWorker_CalculateRecordDuration, backgroundWorker_DataSet, backgroundWorker_DeleteDb, backgroundWorker_CheckAliveState, backgroundWorker_saveDbToTxt, backgroundWorker_loadTxtToDb;
        private int sampleTimeFactor;

        private bool notExecuted;
        private int firstSensorId;
        private HelperFunctions helperFunctions;
        private bool aliveBit;
        private int aliveTimer;
        private Stopwatch aliveStopWatch = new Stopwatch();

        GlobalDataSet globalDataSet;

        long timeStamp_startTime;
        Stopwatch timer_timeStamp = new Stopwatch();
        private bool notInUseByGraph, notInUseByDatabase;


        #region FORM
        public FormDatabase()
        {
            InitializeComponent();

            globalDataSet = new GlobalDataSet();
            helperFunctions = new HelperFunctions(globalDataSet);

            globalDataSet.DebugMode = false;
            globalDataSet.ShowProgramDuration = false;

            backgroundWorker_CalculateRecordDuration.DoWork += new DoWorkEventHandler(backgroundWorker_CalculateRecordDuration_DoWork);
            backgroundWorker_CalculateRecordDuration.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_CalculateRecordDuration_RunWorkerCompleted);

            backgroundWorker_DeleteDb.DoWork += new DoWorkEventHandler(backgroundWorker_DeleteDb_DoWork);
            backgroundWorker_DeleteDb.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_DeleteDb_RunWorkerCompleted);

            backgroundWorker_DataSet.DoWork += new DoWorkEventHandler(backgroundWorker_DataSet_DoWork);
            backgroundWorker_DataSet.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_DataSet_RunWorkerCompleted);

            backgroundWorker_saveDbToTxt.DoWork += new DoWorkEventHandler(backgroundWorker_saveDbToTxt_DoWork);
            backgroundWorker_saveDbToTxt.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_saveDbToTxt_RunWorkerCompleted);

            backgroundWorker_loadTxtToDb.DoWork += new DoWorkEventHandler(backgroundWorker_loadTxtToDb_DoWork);
            backgroundWorker_loadTxtToDb.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_loadTxtToDb_RunWorkerCompleted);

            backgroundWorker_CheckAliveState.DoWork += new DoWorkEventHandler(backgroundWorker_CheckAliveState_DoWork);


            // Initialize
            notInUseByGraph = true;
            notInUseByDatabase = true;
            sampleStep = DEFAULT_SAMPLE_TIME_FACTOR;
            aliveBit = false;
            recordIsActive = false;
            notExecuted = true;
            firstSensorId = -1;
            writeCycle = 0;
            savedRowCounter = 0;
            helperFunctions.changeElementText(textBox_maxSamples, "2500"); // Write to textbox to activate event routine and dto calculate measurement duration
        }

        private void FormDatabase_Load(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker_DataSet.RunWorkerAsync();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            // Check sensor alive in background
            backgroundWorker_CheckAliveState.RunWorkerAsync();
        }

        private void FormDatabase_Closed(object sender, FormClosedEventArgs e)
        {
            closeApplication();
        }

        private void FormDatabase_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                tcpDiagnoseClient.closeAllConnections();
                if (backgroundWorker_CheckAliveState.IsBusy) backgroundWorker_CheckAliveState.CancelAsync();
                closeApplication();
            }
            else
            {
                // DO nothing
            }
        }

        private void checkBox_showGraphs_CheckedChanged(object sender, EventArgs e)
        {

            xSenderCheckbox = (CheckBox)sender;
            if (((CheckBox)sender).Checked)
            {
                // Load and start form
                formCharts = new FormCharts(this, Int32.Parse(textBox_sampleTimeFactorGraph.Text));
                formCharts.chartsExitEventHandler += new FormCharts.ChartsExitEventHandler(eventMethod_chartsExitEventHandler);
                formCharts.Show();
            }
            else formCharts.Close();
        }

        private void checkBox_showDatabase_CheckedChanged(object sender, EventArgs e)
        {
            senderCheckbox = (CheckBox)sender;
            int databaseId = Int32.Parse(textBox_dataBaseId.Text);
            DataSet dataSetTemp = new DataSet();

            if (((CheckBox)sender).Checked)
            {
                // Load and start form
                switch (databaseId)
                {
                    case 1: 
                        dataSetTemp = dataSet_Db1;
                        break;
                    case 2:
                        dataSetTemp = dataSet_Db2;
                        break;
                    default:
                        dataSetTemp = dataSet_Db1;
                        break;
                }
                dataBaseList = new DatabaseList(this, dataSetTemp, databaseConnection, databaseId);
                dataBaseList.Show();
            }
            else
            {
                try
                {
                    dataBaseList.Close();
                }
                catch (Exception)
                {

                }
            }
        }

        public CheckState setCheckboxUnchecked_Y
        {
            set { ySenderCheckbox.CheckState = CheckState.Unchecked; }
        }

        public CheckState setCheckboxUnchecked_X
        {
            set { xSenderCheckbox.CheckState = CheckState.Unchecked; }
        }

        public CheckState setCheckboxUnchecked_Z
        {
            set { zSenderCheckbox.CheckState = CheckState.Unchecked; }
        }

        //private void button_clearDb(object sender, EventArgs e)
        //{
        //    maxTableRows = deleteFromDb();
        //    labelSavedRows.Text = "";
        //    // TODO: Do this in seperate thread and check if database is clear
        //    MessageBox.Show("Database cleared succesfully.");
        //}

        private void textBoxTablePresentID_textChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            tablePresentID = Int32.Parse(textBox.Text);
        }

        private void textBox_maxSamples_TextChanged(object sender, EventArgs e)
        {
            initSampleRate();
        }

        private void textBox_sampleTimeFactor_TextChanged(object sender, EventArgs e)
        {
            initSampleRate();
        }

        private void recordToDb_Click(object sender, EventArgs e)
        {
            if (button_recordToDb.Text.Equals("Record to db"))
            {
                // Show dialog to warn user and clear database
                if (MessageBox.Show("Delete database content?", "Database re-initialization", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    // Start timer to get timestamps
                    notInUseByDatabase = false;
                    if (!timer_timeStamp.IsRunning) startTimerTimestamp();

                    // Delete old database content
                    backgroundWorker_DeleteDb.RunWorkerAsync();
                }
                else
                {
                    // Do nothing
                }
            }
            else
            {
                // Stop timer and indicate that we didnt use it here
                if (timer_timeStamp.IsRunning && notInUseByGraph) timer_timeStamp.Stop();
                notInUseByDatabase = true;

                sampleStep = DEFAULT_SAMPLE_TIME_FACTOR;
                recordIsActive = false;
                savedRowCounter = 0;
                notExecuted = true;
                firstSensorId = -1;
                helperFunctions.changeElementEnable(textBox_maxSamples, true);
                helperFunctions.changeElementEnable(textBox_sampleTimeFactor, true);
                helperFunctions.changeElementEnable(checkBox_showDatabase, true);
                helperFunctions.changeElementEnable(button_importToDb, true);
                helperFunctions.changeElementEnable(button_exportToTxt, true);
                helperFunctions.changeElementText(button_recordToDb, "Record to db");
            }
        }

        private void startTimerTimestamp()
        {
            timer_timeStamp.Reset();
            timer_timeStamp.Start();
            timeStamp_startTime = timer_timeStamp.ElapsedMilliseconds;
        }

        public CheckState setCheckboxUnchecked_DbList
        {
            set { senderCheckbox.CheckState = CheckState.Unchecked; }
        }

        // Export actual database content to txt with semicolon seperated values
        private void button_exportToTxt_Click(object sender, EventArgs e)
        {
            backgroundWorker_saveDbToTxt.RunWorkerAsync();
        }

        // Import extracted movements to new db
        private void button_importToDb_Click(object sender, EventArgs e)
        {
            backgroundWorker_loadTxtToDb.RunWorkerAsync();
        }
        #endregion

        #region BACKGROUND WORKER
        private void backgroundWorker_DeleteDb_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Delete the content of all tables
            databaseConnection.deleteDatabaseContent(Properties.Settings.Default.ConnectionString_DataBase_RightLeg);
            databaseConnection.deleteDatabaseContent(Properties.Settings.Default.ConnectionString_DataBase_RightLeg_extracted);
            dataSet_Db1 = databaseConnection.createDatasetsForDb(Properties.Settings.Default.ConnectionString_DataBase_RightLeg);
            dataSet_Db2 = databaseConnection.createDatasetsForDb(Properties.Settings.Default.ConnectionString_DataBase_RightLeg_extracted);

            e.Result = databaseConnection.getTableSizeForDb(dataSet_Db1);
        }

        private void backgroundWorker_DeleteDb_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            helperFunctions.changeElementText(labelSavedRows, "");
            // Show duration of measurment
            MAX_WRITE_CYCLE = Int32.Parse(textBox_maxSamples.Text);
            recordIsActive = true;
            helperFunctions.changeElementText(button_recordToDb, "Stop recording");
            helperFunctions.changeElementEnable(textBox_maxSamples, false);
            helperFunctions.changeElementEnable(textBox_sampleTimeFactor, false);
            helperFunctions.changeElementEnable(checkBox_showDatabase, false);
            helperFunctions.changeElementEnable(button_exportToTxt, false);
            helperFunctions.changeElementEnable(button_importToDb, false);
            maxTableRows_Db1 = (int[])e.Result;
        }

        private void backgroundWorker_saveDbToTxt_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            helperFunctions.changeElementEnable(button_exportToTxt, false);
            helperFunctions.changeElementEnable(button_recordToDb, false);
            helperFunctions.changeElementEnable(button_importToDb, false);

            int[] maxTableRows = databaseConnection.getTableSizeForDb(dataSet_Db1);
            string header = "x[deg];y[deg];z[deg];timestamp[ms]";

            for (int i = 0; i < maxTableRows.Length; i++)
            {
                string fileName = "table_" + i + ".txt";
                using (StreamWriter writer = new StreamWriter(FILE_SAVE_PATH + fileName, false))
                {
                    writer.WriteLine(header);
                }
                saveDbToFile(i, maxTableRows, fileName);
            }
        }

        private void backgroundWorker_saveDbToTxt_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            helperFunctions.changeElementEnable(button_exportToTxt, true);
            helperFunctions.changeElementEnable(button_recordToDb, true);
            helperFunctions.changeElementEnable(button_importToDb, true);
        }

        private void backgroundWorker_loadTxtToDb_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            helperFunctions.changeElementEnable(button_exportToTxt, false);
            helperFunctions.changeElementEnable(button_recordToDb, false);
            helperFunctions.changeElementEnable(button_importToDb, false);

            string returnString = "";

            databaseConnection.deleteDatabaseContent(Properties.Settings.Default.ConnectionString_DataBase_RightLeg_extracted);
            dataSet_Db2 = databaseConnection.createDatasetsForDb(Properties.Settings.Default.ConnectionString_DataBase_RightLeg_extracted);


            for (int i = 0; i < maxTableRows_Db1.Length; i++)
            {
                string fileName = "table_" + i + ".txt";
                int readCounter = 0;

                using (StreamReader reader = new StreamReader(FILE_SAVE_PATH + fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        returnString = reader.ReadLine();

                        // Create message array from semicolon seperated text file 
                        String[] messageData = returnString.Split(';');
                        Decimal[] messageDataAsDecimal = new Decimal[messageData.Length];

                        for (int j = 0; i < messageDataAsDecimal.Length; j++) messageDataAsDecimal[j] = Decimal.Parse(messageData[j], CultureInfo.InvariantCulture.NumberFormat) * 90;
                        if (readCounter > 0) writeToDb(messageDataAsDecimal, i, dataSet_Db2);
                        readCounter++;
                    }

                }
            }
        }

        private void backgroundWorker_loadTxtToDb_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            helperFunctions.changeElementEnable(button_exportToTxt, true);
            helperFunctions.changeElementEnable(button_recordToDb, true);
            helperFunctions.changeElementEnable(button_importToDb, true);
        }

        private void backgroundWorker_DataSet_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;
            databaseConnection = new DatabaseConnection(globalDataSet);
            DataSet[] dataSets = new DataSet[2];

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This will be available to the 
            // RunWorkerCompleted eventhandler.

            // Create databases for the raw sensor values AND for the extracted movement
            dataSets[0] = databaseConnection.createDatasetsForDb(Properties.Settings.Default.ConnectionString_DataBase_RightLeg);
            dataSets[1] = databaseConnection.createDatasetsForDb(Properties.Settings.Default.ConnectionString_DataBase_RightLeg_extracted);
            e.Result = dataSets;
        }

        private void backgroundWorker_DataSet_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataSet[] dataSets = (DataSet[])e.Result;
            dataSet_Db1 = dataSets[0];
            dataSet_Db2 = dataSets[1];
            maxTableRows_Db1 = databaseConnection.getTableSizeForDb(dataSet_Db1);
            helperFunctions.changeElementEnable(button_recordToDb, true);
            helperFunctions.changeElementEnable(checkBox_showDatabase, true);
            helperFunctions.changeElementEnable(button_exportToTxt, true);
            helperFunctions.changeElementEnable(button_importToDb, true);
        }

        private void backgroundWorker_CalculateRecordDuration_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            try
            {
                e.Result = calculateRecordDuration(Int32.Parse(textBox_maxSamples.Text), int.Parse(textBox_sampleTimeFactor.Text));
            }
            catch (Exception)
            {
                e.Result = 0.0f;
            }
        }

        private void backgroundWorker_CalculateRecordDuration_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            recordDuration = (float)e.Result;
            try
            {
                MAX_WRITE_CYCLE = Int32.Parse(textBox_maxSamples.Text);
            }
            catch (Exception)
            {
                MAX_WRITE_CYCLE = 0;
            }
            label_recordDurationMin.Text = recordDuration.ToString();
            label_recordDurationSec.Text = (recordDuration * 60).ToString();
        }

        private void backgroundWorker_CheckAliveState_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            bool stopWatchStarted = false;
            bool stopWatchStopped = true;
            bool iconIsRed = false;
            bool iconIsGreen = false;

            while (true)
            {
                if (!aliveBit && !stopWatchStarted)
                {
                    aliveStopWatch.Start();
                    stopWatchStopped = false;
                    stopWatchStarted = true;
                }
                else if (aliveBit && !stopWatchStopped)
                {
                    aliveStopWatch.Stop();
                    aliveStopWatch.Reset();
                    stopWatchStopped = true;
                    stopWatchStarted = false;
                }
                if ((aliveStopWatch.ElapsedMilliseconds > MAX_ALIVE_SIGNAL_PAUSE) && (!iconIsRed))
                {
                    // Show red icon in gui
                    label_aliveIcon.BeginInvoke((MethodInvoker)delegate() { label_aliveIcon.BackColor = Color.Red; });
                    iconIsRed = true;
                }
                else if ((aliveStopWatch.ElapsedMilliseconds < MAX_ALIVE_SIGNAL_PAUSE) && (aliveBit) && (!iconIsGreen))
                {
                    // Show green icon in gui
                    label_aliveIcon.BeginInvoke((MethodInvoker)delegate() { label_aliveIcon.BackColor = Color.LightGreen; });
                    iconIsGreen = true;
                }
            }
        }

        #endregion

        #region HELP FUNCTIONS

        private void saveDbToFile(int tableID, int[] maxTableRows, string fileName)
        {
            string element;
            if (dataSet_Db1 != null)
            {
                for (int j = 0; j < maxTableRows[tableID]; j++)
                {
                    DataRow dataRow = dataSet_Db1.Tables[tableID].Rows[j];
                    element = "";

                    for (int k = 1; k <= 4; k++)
                    {
                        if(k<4) element = element + dataRow.ItemArray.GetValue(k).ToString() + ";";
                        else element = element + dataRow.ItemArray.GetValue(k).ToString();
                    }
                    // Append data to file.

                    using (StreamWriter writer = new StreamWriter(FILE_SAVE_PATH + fileName, true))
                    {
                        writer.WriteLine(element);
                    }
                }
            }
        }

        private void eventMethod_chartsExitEventHandler()
        {
            formCharts = null;
        }

        public void startApplication()
        {
            if (!clientConnectionInit())
            {
                // Show dialog to give user possibility to reconnect
                // Otherwise start other forms and continue with normal execution
                if (MessageBox.Show("Try reconnect?", "Can't connect to server", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // user clicked yes
                    startApplication();
                }
                else
                {
                    // user clicked no
                    closeApplication();
                }
            }
            else
            {
            }
        }

        private void closeApplication()
        {
            // Stop timer to measure program execution
            if (globalDataSet.ShowProgramDuration) globalDataSet.Timer_programExecution.Stop();

            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }

        private float calculateRecordDuration(int maxSamples, int sampleTimeFactor)
        {
            float sampleTime = SAMPLE_TIME;
            return (maxSamples * (sampleTimeFactor * sampleTime)) / 60;
        }

        private void writeToDb(Decimal[] msgArray, int tableID, DataSet dataSet)
        {
            if (dataSet != null)
            {
                DataRow row = dataSet.Tables[tableID].NewRow();
       
                for (int i = 0; i < msgArray.Length; i++) row[i+1] = msgArray[i];

                dataSet.Tables[tableID].Rows.Add(row);

                try
                {
                    databaseConnection.UpdateDatabase(dataSet, tableID);
                    maxTableRows_Db1[tableID]++;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }

        }

        private void initSampleRate()
        {
            if (!backgroundWorker_CalculateRecordDuration.IsBusy)
            {
                try
                {
                    if (Int32.Parse(textBox_sampleTimeFactor.Text) >= DEFAULT_SAMPLE_TIME_FACTOR) sampleTimeFactor = Int32.Parse(textBox_sampleTimeFactor.Text);
                    else sampleTimeFactor = DEFAULT_SAMPLE_TIME_FACTOR;
                }
                catch (Exception)
                {
                    sampleTimeFactor = DEFAULT_SAMPLE_TIME_FACTOR;
                }
                sampleStep = sampleTimeFactor;
                backgroundWorker_CalculateRecordDuration.RunWorkerAsync();
            }
        }

        private bool clientConnectionInit()
        {
            tcpDiagnoseClient = new RBC.TcpIpCommunicationUnit("DiagnoseServer", globalDataSet);
            //register the callbackevents from tcpservers
            tcpDiagnoseClient.messageReceivedEvent += new RBC.TcpIpCommunicationUnit.MessageReceivedEventHandler(tcpDiagnoseServer_messageReceivedEvent);
            tcpDiagnoseClient.errorEvent += new RBC.TcpIpCommunicationUnit.ErrorEventHandler(tcpPLCServer_errorEvent);
            tcpDiagnoseClient.statusChangedEvent += new RBC.TcpIpCommunicationUnit.StatusChangedEventHandler(tcpDiagnoseServer_statusChangedEvent);
            return tcpDiagnoseClient.clientInit();
        }

        #endregion

        #region CLIENT
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
            String message = receivedMessage[0];
            String sensor_joint_ID = receivedMessage[1];

            if(globalDataSet.DebugMode) Debug.WriteLine("receivedMessage: " + receivedMessage[0]);

            aliveBit = true;

            // remove x, y, z character in message string
            message = message.Replace("x", "");
            message = message.Replace("y", "");
            message = message.Replace("z", "");
            //message = message.Replace(".", ",");

            // Split message to x, y, z and timestamp value
            String[] messageData = message.Split(':');

            // Convert message to float -> IMPORTANT: REMOVE THE NUMBER 40 WHEN THE CALCULATION IS CORRECTLY IMPLEMENTED HERE AND AT ANOTHER PLACE IN CODE (when read txt to db)
            Decimal[] messageDataAsDecimal = new Decimal[messageData.Length+1];
            for (int i = 0; i < messageData.Length; i++) messageDataAsDecimal[i] = Decimal.Parse(messageData[i], CultureInfo.InvariantCulture.NumberFormat) * 90;

            // Generate timestamp
            messageDataAsDecimal[3] = timer_timeStamp.ElapsedMilliseconds - timeStamp_startTime;
            messageDataAsDecimal[3] = Math.Round((messageDataAsDecimal[3]/1000), 3, MidpointRounding.AwayFromZero);

            // Save to db
            if (recordIsActive)
            {
                // Save write cycles to stop if max write cycle is reached     
                if (sampleStep == sampleTimeFactor)
                {
                    if ((writeCycle < MAX_WRITE_CYCLE))
                    {
                        if (!notExecuted) writeToDb(messageDataAsDecimal, Int32.Parse(sensor_joint_ID), dataSet_Db1);
                        if (Int32.Parse(sensor_joint_ID) == firstSensorId)
                        {
                            sampleStep = DEFAULT_SAMPLE_TIME_FACTOR;
                            writeCycle++;
                            helperFunctions.changeElementText(labelSavedRows, writeCycle.ToString());
                        }
                    }
                    else
                    {
                        writeCycle = 0;
                        recordIsActive = false;
                        savedRowCounter = 0;
                        notExecuted = true;
                        firstSensorId = -1;
                        button_recordToDb.BeginInvoke((MethodInvoker)delegate() { button_recordToDb.PerformClick(); });
                        helperFunctions.changeElementEnable(textBox_maxSamples, true);
                        helperFunctions.changeElementText(button_recordToDb, "Record to db");
                        MessageBox.Show("Measurement finished.");
                    }
                }
                else if (Int32.Parse(sensor_joint_ID) == firstSensorId) sampleStep++;

                // Save first sensor id to calculate correct sample time
                // Next sample is when the first sensor id comes again
                if (notExecuted)
                {
                    firstSensorId = Int32.Parse(sensor_joint_ID);
                    notExecuted = false;
                }
            }
            // Show sensor values in graph
            if ((checkBox_showGraphs.Checked) && (formCharts != null))
            {
                // Start timer to get timestamps
                notInUseByGraph = false;
                if (!timer_timeStamp.IsRunning) startTimerTimestamp();

                formCharts.setNewChartData(messageDataAsDecimal, sensor_joint_ID);
            }
            // Stop timer and indicate that we didnt use it here     
            else if (timer_timeStamp.IsRunning && notInUseByDatabase) timer_timeStamp.Stop();
            notInUseByGraph = true;

            aliveBit = false;
            if(globalDataSet.ShowProgramDuration) Debug.WriteLine(globalDataSet.Timer_programExecution.ElapsedMilliseconds - globalDataSet.TimerValue);
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
        #endregion


    }
}
