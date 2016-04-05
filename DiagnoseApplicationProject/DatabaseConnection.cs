using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication6
{
    public class DatabaseConnection
    {
        private int DATABASE_SIZE = 4;
        private string strCon;
        System.Data.SqlClient.SqlDataAdapter dataAdapter, dataAdapter1, dataAdapter2, dataAdapter3, dataAdapterX;
        private DataSet dataSet, dataSetX;
        private int[] maxTableRows;
        private System.Data.SqlClient.SqlConnection dataBase_connection;

        public void UpdateDatabase(System.Data.DataSet dataSet, int tableID)
        {
            try
            {
               // System.Data.SqlClient.SqlCommandBuilder commandBuilder = new System.Data.SqlClient.SqlCommandBuilder(dataAdapter);
               // commandBuilder.DataAdapter.Update(dataSet.Tables[tableID]);
                System.Data.SqlClient.SqlCommandBuilder commandBuilder = new System.Data.SqlClient.SqlCommandBuilder(dataAdapter);
                commandBuilder.DataAdapter.Update(dataSet.Tables[0]);

                System.Data.SqlClient.SqlCommandBuilder commandBuilder1 = new System.Data.SqlClient.SqlCommandBuilder(dataAdapter1);
                commandBuilder1.DataAdapter.Update(dataSet.Tables[1]);

                System.Data.SqlClient.SqlCommandBuilder commandBuilder2 = new System.Data.SqlClient.SqlCommandBuilder(dataAdapter2);
                commandBuilder2.DataAdapter.Update(dataSet.Tables[2]);

                System.Data.SqlClient.SqlCommandBuilder commandBuilder3 = new System.Data.SqlClient.SqlCommandBuilder(dataAdapter3);
                commandBuilder3.DataAdapter.Update(dataSet.Tables[3]);

                
                dataAdapterX = new SqlDataAdapter("SELECT * FROM tbl_rl_j0", dataBase_connection);
                dataAdapterX.Fill(dataSetX, "tbl_rl_j0");
            }
            catch(DBConcurrencyException e){
                Debug.Write("Exception in UpdateDatabase():" + e);
            }
        }

        public DataSet createDatasetsForDb(string dBdescription)
        {
            // Create and open connection to specific database
            dataBase_connection = new System.Data.SqlClient.SqlConnection(dBdescription);
            dataBase_connection.Open();

            // Copy content of database to dataset and close connection
            dataSetX = new System.Data.DataSet();
            dataSet = new System.Data.DataSet();
            //for (int i = 0; i < DATABASE_SIZE; i++)
            //{
            //    dataAdapter = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM tbl_rl_j" + i, dataBase_connection);
            //    dataAdapter.Fill(dataSet, "tbl_rl_j" + i);
            //}
            dataAdapter = new SqlDataAdapter("SELECT * FROM tbl_rl_j0", dataBase_connection);
            dataAdapter.Fill(dataSet, "tbl_rl_j0");

            dataAdapter1 = new SqlDataAdapter("SELECT * FROM tbl_rl_j1", dataBase_connection);
            dataAdapter1.Fill(dataSet, "tbl_rl_j1");

            dataAdapter2 = new SqlDataAdapter("SELECT * FROM tbl_rl_j2", dataBase_connection);
            dataAdapter2.Fill(dataSet, "tbl_rl_j2");

            dataAdapter3 = new SqlDataAdapter("SELECT * FROM tbl_rl_j3", dataBase_connection);
            dataAdapter3.Fill(dataSet, "tbl_rl_j3");
            //dataAdapter = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM tbl_rl_j" + 0, dataBase_connection);
            //dataAdapter.Fill(dataSet, "tbl_rl_j" + 00);

            //dataAdapter1 = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM tbl_rl_j" + 1, dataBase_connection);
            //dataAdapter1.Fill(dataSet, "tbl_rl_j" + 11);

            //dataAdapter2 = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM tbl_rl_j" + 2, dataBase_connection);
            //dataAdapter2.Fill(dataSet, "tbl_rl_j" + 22);

            //dataAdapter3 = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM tbl_rl_j" + 3, dataBase_connection);
            //dataAdapter3.Fill(dataSet, "tbl_rl_j" + 33);

            dataBase_connection.Close();

            return dataSet;
        }

        public int[] getTableSizeForDb(DataSet dataSet)
        {
            maxTableRows = new int[DATABASE_SIZE];
            for (int i = 0; i < DATABASE_SIZE; i++)
            {
                maxTableRows[i] = dataSet.Tables[i].Rows.Count;
            }
            return maxTableRows;
        }

        public void deleteDatabaseContent(string dBdescription)
        {
            dataBase_connection = new System.Data.SqlClient.SqlConnection(dBdescription);
            int MAX_TABLE_AMOUNT = Properties.Settings.Default.MAX_TABLE_AMOUNT;
            if (dataBase_connection != null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = dataBase_connection;

                for (int i = 0; i <= MAX_TABLE_AMOUNT; i++)
                {
                    cmd.CommandText = "DELETE tbl_rl_j" + i;
                    dataBase_connection.Open();
                    cmd.ExecuteNonQuery();
                    dataBase_connection.Close();                    
                }
            }
        }


    }
}
