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
using MySql.Data.MySqlClient;

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
        private bool calibrationIsActive = false;

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
        private int SENSOR_AMOUNT = Properties.Settings.Default.sensorAmount;
        double[] Rx_x = new double[3];
        double[] Rx_y = new double[3];
        double[] Rx_z = new double[3];

        private float recordDuration;
        //private RBC.Configuration dllConfiguration = null;

        private System.ComponentModel.BackgroundWorker backgroundWorker_CalculateRecordDuration, backgroundWorker_DataSet, backgroundWorker_DeleteDb, backgroundWorker_CheckAliveState, backgroundWorker_saveDbToTxt, backgroundWorker_loadTxtToDb;
        private System.ComponentModel.BackgroundWorker backgroundWorker_DataSet2;
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
        private double GRAVITATION_EARTH = 9.81;
        private bool[] sensorCalibrationSet;
        private double[] gs_x;
        private double[] gs_y;
        private double[] gs_z;

        // Data for upload to xampp db
        private string directoryTxtImport;
        private int fileId;
        private bool liteVersion;
        private string db_name;

        #region FORM
        public FormDatabase()
        {
            InitializeComponent();

            // Initialize sensor arrays
            gs_x = new double[SENSOR_AMOUNT];
            gs_y = new double[SENSOR_AMOUNT];
            gs_z = new double[SENSOR_AMOUNT];
            sensorCalibrationSet = new bool[SENSOR_AMOUNT];

            for (int i = 0; i < SENSOR_AMOUNT; i++)
            {
                gs_x[i] = 0;
                gs_y[i] = 0;
                gs_z[i] = 0;
                sensorCalibrationSet[i] = false;
            }

            globalDataSet = new GlobalDataSet();
            helperFunctions = new HelperFunctions(globalDataSet);

            globalDataSet.DebugMode = true;
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
            liteVersion = false;
            notInUseByGraph = true;
            notInUseByDatabase = true;
            sampleStep = DEFAULT_SAMPLE_TIME_FACTOR;
            aliveBit = false;
            recordIsActive = false;
            notExecuted = true;
            firstSensorId = -1;
            writeCycle = 0;
            savedRowCounter = 0;
            helperFunctions.changeElementText(textBox_maxSamples, "3500", false); // Write to textbox to activate event routine and dto calculate measurement duration
        }

        private void FormDatabase_Load(object sender, EventArgs e)
        {
            if (liteVersion)
            {
                helperFunctions.changeElementEnable(buttonCalibrateSensors, false);
                helperFunctions.changeElementEnable(button_recordToDb, false);
            }

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
                formCharts = new FormCharts(this);
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
                        //dataSetTemp = dataSet_Db2;
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
                    // Delete old database content
                    labelSavedRows.Text = "";
                    backgroundWorker_DeleteDb.RunWorkerAsync();
                }
                else;// Do nothing
            }
            else
            {
                sampleStep = DEFAULT_SAMPLE_TIME_FACTOR;
                recordIsActive = false;
                savedRowCounter = 0;
                notExecuted = true;
                firstSensorId = -1;
                helperFunctions.changeElementEnable(textBox_maxSamples, true);
                helperFunctions.changeElementEnable(checkBox_showDatabase, true);
                helperFunctions.changeElementEnable(button_importToDb, true);
                helperFunctions.changeElementEnable(button_exportToTxt, true);
                helperFunctions.changeElementText(button_recordToDb, "Record to db", false);
            }
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

        // Upload extracted movements to remote db
        private void button_uploadSteps_Click(object sender, EventArgs e)
        {
            // TODO: Extract steps automatically
            //       - Take raw data from db 1
            //       - Modify raw data 
            //       - Load extracted steps / modified raw data to remote db (XAMPP)

            // Actual implementation: 
            //       - Export raw data to txt
            //       - Extract steps manually
            //       - Import manually extracted steps in db 1
            //       - Upload to remote db (XAMPP)

            directoryTxtImport = string.Empty;
            string[] fileName;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                directoryTxtImport = openFileDialog1.FileName;
            fileName = (openFileDialog1.SafeFileName).Substring(5).Split('.');

            // Prevent wrong filename format
            try
            {
                fileId = Int32.Parse(fileName[0]);
                if (globalDataSet.DebugMode) Debug.WriteLine("Name: " + fileName[0]);
                db_name = textBox_dbTableName.Text;
            }
            catch (FormatException)
            {
                helperFunctions.changeElementText(textBox_Info, "Filename not supported!", true);
            }
            finally
            {
                // Check if id is inside  filename and not exiting the limit
                if ((fileId >= MIN_TABLE_AMOUNT) && (fileId <= MAX_TABLE_AMOUNT)) backgroundWorker_loadTxtToDb.RunWorkerAsync();
                else helperFunctions.changeElementText(textBox_Info, "File Id not supported!", true);
            }
        }
        #endregion

        #region BACKGROUND WORKER
        private void backgroundWorker_DeleteDb_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Delete the content of all tables
            databaseConnection.deleteDatabaseContent(Properties.Settings.Default.ConnectionString_DataBase);
            //databaseConnection.deleteDatabaseContent(Properties.Settings.Default.ConnectionString_DataBase_RightLeg_extracted);
            dataSet_Db1 = databaseConnection.createDatasetsForDb(Properties.Settings.Default.ConnectionString_DataBase);
            //dataSet_Db2 = databaseConnection.createDatasetsForDb(Properties.Settings.Default.ConnectionString_DataBase_RightLeg_extracted);

            e.Result = databaseConnection.getTableSizeForDb(dataSet_Db1);
        }

        private void backgroundWorker_DeleteDb_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //helperFunctions.changeElementText(labelSavedRows, "");
            // Show duration of measurement
            MAX_WRITE_CYCLE = Int32.Parse(textBox_maxSamples.Text);
            Debug.WriteLine("MAX_WRITE_CYCLE: " + MAX_WRITE_CYCLE);
            recordIsActive = true;
            helperFunctions.changeElementText(button_recordToDb, "Stop recording", false);
            helperFunctions.changeElementEnable(textBox_maxSamples, false);
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
                string fileName;
                if (textBox_context.Text != "") fileName = textBox_context.Text + "_" + i + ".txt";
                else fileName = "noname_" + i + ".txt";

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
            helperFunctions.changeElementEnable(checkBox_showDatabase, false);
            helperFunctions.changeElementEnable(button_exportToTxt, false);
            helperFunctions.changeElementEnable(button_importToDb, false);

            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;
            string returnString = string.Empty;
            int readCounter = 0;

            xampp_removeContent(db_name, fileId);

            using (StreamReader reader = new StreamReader(directoryTxtImport))
            {
                while (!reader.EndOfStream)
                {
                    returnString = reader.ReadLine();

                    // Create message array from semicolon seperated text file 
                    String[] messageData = returnString.Split(';');
                    Decimal[] messageDataAsDecimal = new Decimal[messageData.Length];

                    for (int j = 0; j < 4; j++) messageDataAsDecimal[j] = Decimal.Parse(messageData[j], CultureInfo.InvariantCulture.NumberFormat);
                    if (readCounter > 0)
                    {
                        // Add extracted steps to xampp db with specific content
                        xampp_addContent(db_name, fileId, messageDataAsDecimal);
                        //writeToDb(messageDataAsDecimal, fileId, dataSet_Db1);

                    }
                    readCounter++;
                }

            }
        }

        private void backgroundWorker_loadTxtToDb_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            helperFunctions.changeElementEnable(checkBox_showDatabase, true);
            helperFunctions.changeElementEnable(button_exportToTxt, true);
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
            dataSets[0] = databaseConnection.createDatasetsForDb(Properties.Settings.Default.ConnectionString_DataBase);
            //dataSets[1] = databaseConnection.createDatasetsForDb(Properties.Settings.Default.ConnectionString_DataBase_RightLeg_extracted);
            e.Result = dataSets;
        }

        private void backgroundWorker_DataSet_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataSet[] dataSets = (DataSet[])e.Result;
            dataSet_Db1 = dataSets[0];
            //dataSet_Db2 = dataSets[1];
            maxTableRows_Db1 = databaseConnection.getTableSizeForDb(dataSet_Db1);
            Debug.WriteLine("maxTableRows_Db1: " + maxTableRows_Db1);
            if (!liteVersion) helperFunctions.changeElementEnable(button_recordToDb, true);
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
                e.Result = calculateRecordDuration(Int32.Parse(textBox_maxSamples.Text));
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
                    label_aliveIcon.BeginInvoke((MethodInvoker)delegate () { label_aliveIcon.BackColor = Color.Red; });
                    iconIsRed = true;
                }
                else if ((aliveStopWatch.ElapsedMilliseconds < MAX_ALIVE_SIGNAL_PAUSE) && (aliveBit) && (!iconIsGreen))
                {
                    // Show green icon in gui
                    label_aliveIcon.BeginInvoke((MethodInvoker)delegate () { label_aliveIcon.BackColor = Color.LightGreen; });
                    iconIsGreen = true;
                }
            }
        }

        #endregion

        #region HELP FUNCTIONS

        private void xampp_removeContent(string dbName, int tableId)
        {
            string conStringXampp = "Server=localhost;Database=" + dbName + "; Uid=root;Pwd=rbc;";
            MySqlConnection connection = new MySqlConnection(conStringXampp);
            MySqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM s"+tableId+" WHERE 1";
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void xampp_addContent(string dbName, int tableId, Decimal[] data)
        {
            string conStringXampp = "Server=localhost;Database="+ dbName+"; Uid=root;Pwd=rbc;";
            MySqlConnection connection = new MySqlConnection(conStringXampp);
            MySqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO s"+ tableId + "(x,y,z,timestamp)VALUES(@x,@y,@z,@timestamp)";
                cmd.Parameters.AddWithValue("@x", data[0]);
                cmd.Parameters.AddWithValue("@y", data[1]);
                cmd.Parameters.AddWithValue("@z", data[2]);
                cmd.Parameters.AddWithValue("@timestamp", data[3]);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

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
                        if (k < 4) element = element + dataRow.ItemArray.GetValue(k).ToString() + ";";
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
                if (MessageBox.Show("Start lite version?", "Can't connect to server", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    // user clicked ok
                    liteVersion = true;
                }
                else
                {
                    // user clicked cancel
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

        private void button_calibrateSensors(object sender, EventArgs e)
        {
            for (int i = 0; i < SENSOR_AMOUNT; i++)
            {
                gs_x[i] = 0;
                gs_y[i] = 0;
                gs_z[i] = 0;
                sensorCalibrationSet[i] = false;
            }
            buttonCalibrateSensors.Enabled = false;
        }

        private void button_Ok_Clicked(object sender, EventArgs e)
        {
            textBox_Info.Clear();
        }

        private float calculateRecordDuration(int maxSamples)
        {
            float sampleTime = SAMPLE_TIME;
            return (maxSamples * sampleTime) / 60;
        }

        private void writeToDb(Decimal[] msgArray, int tableID, DataSet dataSet)
        {
            if (dataSet != null)
            {
                DataRow row = dataSet.Tables[tableID].NewRow();

                for (int i = 0; i < msgArray.Length; i++) row[i + 1] = msgArray[i];

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
                sampleTimeFactor = DEFAULT_SAMPLE_TIME_FACTOR;
                sampleStep = sampleTimeFactor;
                backgroundWorker_CalculateRecordDuration.RunWorkerAsync();
            }
        }

        private bool clientConnectionInit()
        {
            tcpDiagnoseClient = new RBC.TcpIpCommunicationUnit("DiagnoseServer", globalDataSet);
            //register the callbackevents from tcpservers
            tcpDiagnoseClient.messageReceivedEvent += new RBC.TcpIpCommunicationUnit.MessageReceivedEventHandler(tcpMsgRecEvent);
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

        void tcpMsgRecEvent(string[] receivedMessage)
        {
            String message = receivedMessage[0];
            double[] sensorValues = new double[3];
            int sensor_joint_ID = Int32.Parse(receivedMessage[1]);

            if (globalDataSet.DebugMode) Debug.WriteLine("receivedMessage: " + receivedMessage[0]);

            aliveBit = true;

            // remove x, y, z character in message string
            message = message.Replace("x", "");
            message = message.Replace("y", "");
            message = message.Replace("z", "");
            //message = message.Replace(".", ",");

            // Split message to x, y, z and timestamp value
            String[] messageData = message.Split(':');
            Decimal[] messageDataAsDecimal = new Decimal[messageData.Length];

            for (int i = 0; i < 3; i++)
            {
                sensorValues[i] = double.Parse(messageData[i], CultureInfo.InvariantCulture.NumberFormat);
                //Debug.WriteLine("sensorValues: " + sensorValues[i]);
            }

            #region Calibration
            if (sensor_joint_ID <= SENSOR_AMOUNT)
            {
                if ((!sensorCalibrationSet[sensor_joint_ID]) & (!buttonCalibrateSensors.Enabled))
                {
                    double alpha = -9999;

                    // Check quadrant
                    if ((sensorValues[1] >= 0) & (sensorValues[2] < 0)) alpha = -(Math.PI / 2) + Math.Acos((sensorValues[1] * GRAVITATION_EARTH) / GRAVITATION_EARTH); // Quadrant 1
                    else if ((sensorValues[1] >= 0) & (sensorValues[2] > 0)) alpha = (Math.PI / 2) - Math.Acos((sensorValues[1] * GRAVITATION_EARTH) / GRAVITATION_EARTH); // Quadrant 2

                    if (alpha != -9999)
                    {
                        // Create rotation matrix around x axis
                        Rx_x[0] = 1;
                        Rx_x[1] = 0;
                        Rx_x[2] = 0;

                        Rx_y[0] = 0;
                        Rx_y[1] = Math.Cos(alpha);
                        Rx_y[2] = -Math.Sin(alpha);

                        Rx_z[0] = 0;
                        Rx_z[1] = Math.Sin(alpha);
                        Rx_z[2] = Math.Cos(alpha);

                        //for (int i = 0; i < 3; i++) Debug.WriteLine("Rx: " + Rx_x[i]);
                        //for (int i = 0; i < 3; i++) Debug.WriteLine("Rx: " + Rx_y[i]);
                        //for (int i = 0; i < 3; i++) Debug.WriteLine("Rx: " + Rx_z[i]);
                        // Set sensor calibration state to "calibration successfull"
                        sensorCalibrationSet[sensor_joint_ID] = true;
                        //Debug.WriteLine("Calibration finished - " + sensor_joint_ID + " -");

                        for (int i = 0; i < SENSOR_AMOUNT; i++)
                        {
                            if (!sensorCalibrationSet[i]) break;
                            else if (i == SENSOR_AMOUNT - 1) helperFunctions.changeElementEnable(buttonCalibrateSensors, true);
                        }

                    }
                    else
                    {
                        helperFunctions.changeElementText(textBox_Info, "Calibration failed!", true);
                        helperFunctions.changeElementEnable(buttonCalibrateSensors, true);
                    }
                }
                #endregion

                #region Set calibration data 

                // Modify sensor values with calibration data
                gs_x[sensor_joint_ID] = ((Rx_x[0] * sensorValues[0]) + (Rx_x[1] * sensorValues[1]) + (Rx_x[2] * sensorValues[2])) * 90;
                gs_y[sensor_joint_ID] = ((Rx_y[0] * sensorValues[0]) + (Rx_y[1] * sensorValues[1]) + (Rx_y[2] * sensorValues[2])) * 90;
                gs_z[sensor_joint_ID] = ((Rx_z[0] * sensorValues[0]) + (Rx_z[1] * sensorValues[1]) + (Rx_z[2] * sensorValues[2])) * 90;

                // Set calibration data only when checkbox is checked 

                if (checkBox_showCalibData.Checked)
                {
                    // Convert double to decimal
                    messageDataAsDecimal[0] = Convert.ToDecimal(gs_x[sensor_joint_ID], CultureInfo.InvariantCulture.NumberFormat);
                    messageDataAsDecimal[1] = Convert.ToDecimal(gs_y[sensor_joint_ID], CultureInfo.InvariantCulture.NumberFormat);
                    messageDataAsDecimal[2] = Convert.ToDecimal(gs_z[sensor_joint_ID], CultureInfo.InvariantCulture.NumberFormat);
                }
                else for (int i = 0; i < messageDataAsDecimal.Length - 1; i++) messageDataAsDecimal[i] = Decimal.Parse(messageData[i], CultureInfo.InvariantCulture.NumberFormat) * 90;

                // Get timestamp
                messageDataAsDecimal[3] = Decimal.Parse(messageData[3], CultureInfo.InvariantCulture.NumberFormat);
                #endregion
            }
            else
            {
                messageDataAsDecimal[0] = 0;
                messageDataAsDecimal[1] = 0;
                messageDataAsDecimal[2] = 0;
                helperFunctions.changeElementText(textBox_Info, "Failure in sensor id!", true);
            }

            // Save to db
            if (recordIsActive)
            {
                // Save write cycles to stop if max write cycle is reached     
                if (sampleStep == sampleTimeFactor)
                {
                    if ((writeCycle < MAX_WRITE_CYCLE))
                    {
                        if (!notExecuted) writeToDb(messageDataAsDecimal, sensor_joint_ID, dataSet_Db1);
                        if (sensor_joint_ID == firstSensorId)
                        {
                            sampleStep = DEFAULT_SAMPLE_TIME_FACTOR;
                            writeCycle++;
                            helperFunctions.changeElementText(labelSavedRows, writeCycle.ToString(), false);
                        }
                    }
                    else
                    {
                        writeCycle = 0;
                        recordIsActive = false;
                        savedRowCounter = 0;
                        notExecuted = true;
                        firstSensorId = -1;
                        button_recordToDb.BeginInvoke((MethodInvoker)delegate () { button_recordToDb.PerformClick(); });
                        helperFunctions.changeElementEnable(textBox_maxSamples, true);
                        helperFunctions.changeElementText(button_recordToDb, "Record to db", false);
                        MessageBox.Show("Measurement finished.");
                    }
                }
                else if (sensor_joint_ID == firstSensorId) sampleStep++;

                // Save first sensor id to calculate correct sample time
                // Next sample is when the first sensor id comes again
                if (notExecuted)
                {
                    firstSensorId = sensor_joint_ID;
                    notExecuted = false;
                }
            }
            // Show sensor values in graph
            if ((checkBox_showGraphs.Checked) && (formCharts != null)) formCharts.setNewChartData(messageDataAsDecimal, sensor_joint_ID);

            aliveBit = false;
            if (globalDataSet.ShowProgramDuration) Debug.WriteLine(globalDataSet.Timer_programExecution.ElapsedMilliseconds - globalDataSet.TimerValue);
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
