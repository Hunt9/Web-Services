using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Practice.App_Code.DAL
{
    public class clsDbCnn
    {
        private String strDatabase;
        private String strServer;
        private String strUserID;
        private String strPassword;
        private String strMaxPoolSize;
        private String strConnectionString;
        public SqlConnection cnn;
        public SqlTransaction tran;
        private bool disposed = false;



        public string Database
        {
            set { this.strDatabase = value; }
        }

        public string Server
        {
            set { this.strServer = value; }
        }

        public string UserId
        {
            set { this.strUserID = value; }
        }

        public string Password
        {
            set { this.strPassword = value; }
        }
        public string MaxPool
        {
            set { this.strMaxPoolSize = value; }
        }


        public void SetDBProperties()
        {
            strServer = System.Configuration.ConfigurationManager.AppSettings["dbServer"];
            strDatabase = System.Configuration.ConfigurationManager.AppSettings["dbName"];
            strUserID = System.Configuration.ConfigurationManager.AppSettings["UserID"];
            strPassword = System.Configuration.ConfigurationManager.AppSettings["Pwd"];
            strMaxPoolSize = System.Configuration.ConfigurationManager.AppSettings["MaxPoolSize"];



            //strServer = System.Configuration.ConfigurationManager.AppSettings["NEdbServer"];
            //strDatabase = System.Configuration.ConfigurationManager.AppSettings["NEdbName"];
            //strUserID = System.Configuration.ConfigurationManager.AppSettings["NEUserID"];
            //strPassword = System.Configuration.ConfigurationManager.AppSettings["NEPwd"];


        }

        public SqlConnection ConnectToDatabase()
        {
            SetDBProperties();
            strConnectionString = "Server=" + strServer + ";Database=" + strDatabase + ";uid=" + strUserID + ";pwd=" + strPassword + ";Max Pool Size=" + strMaxPoolSize;

            try
            {
                cnn = new SqlConnection(strConnectionString);
                cnn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cnn;
        }

        public SqlConnection ConnectToDB()
        {
            SetDBProperties();
            strConnectionString = "Server=" + strServer + ";Database=" + strDatabase + ";uid=" + strUserID + ";pwd=" + strPassword + ";Max Pool Size=" + strMaxPoolSize;

            try
            {
                cnn = new SqlConnection(strConnectionString);
                cnn.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cnn;
        }
        public void DisConnectToDatabase()
        {
            cnn.Close();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern. 
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                cnn.Dispose();
            }

            // Free any unmanaged objects here. 
            //cnn.Dispose();
            disposed = true;
        }

        ~clsDbCnn()
        {
            Dispose(false);
            //objEncrypt = null;
        }

    }
}