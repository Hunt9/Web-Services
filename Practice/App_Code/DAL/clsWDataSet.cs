using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace Practice.App_Code.DAL
{
    public class clsWDataSet
    {
        
        //public struct strucResult
        //{
        private DAL.clsDbCnn objdb = new DAL.clsDbCnn();
        private System.Data.SqlClient.SqlCommand cmd;
        SqlTransaction trans;
        //private System.Data.SqlClient.SqlParameter dpr;

        private SqlDataAdapter adpCommon = new SqlDataAdapter();
        private DataSet dstCommon = new DataSet();
        private string strStoredProcedure;
        public string strExpiryMessage = "Your evaluation version has been expired"; //'If we will give evalutionary versions
        private bool disposed = false;
        private string strViewName = "tbl";
        //strucResult struc;
        clsReturnObject objReturnObject;

        //bool blnIsExpirDate = true;

        public class clsReturnObject : IDisposable
        {
            public int intCode;
            public int intPkCode;
            public string strMessage;
            public DataSet dstResult;//=new DataSet();
            private bool disposed = false;
            public clsReturnObject()
            {
                dstResult = new DataSet();
                //clsWDataSet obj = new clsWDataSet();
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
                    dstResult.Dispose();

                }

                // Free any unmanaged objects here. 
                //dstResult.Dispose();
                disposed = true;
            }

            ~clsReturnObject()
            {
                Dispose(false);
            }

        }

        public clsWDataSet()
        {
            objReturnObject = new clsReturnObject();
        }


        //    public int intCode;
        //    public int intPkCode;
        //    public string strMessage;
        //    public  DataSet dstResult;//=new DataSet();
        //void clsDataSet()
        //{
        //    dstResult=new DataSet();
        //    //clsWDataSet obj = new clsWDataSet();
        //}

        //public strucResult()
        //{
        //    dstResult = new DataSet();
        //}
        //}

        public void BeginTrans()
        {
            //SqlTransaction trans;
            trans = objdb.cnn.BeginTransaction("transaction");
            cmd.Transaction = trans;
        }
        public void CommitTran()
        {
            trans.Commit();
        }
        public void RollBackTran()
        {
            trans.Rollback();
        }


        public clsReturnObject GetAllRecordsByNID(string strSPName, string[] strFetchIDName, object[] lngFetchID)
        {
            try
            {

                using (SqlConnection sqlconn = objdb.ConnectToDB())
                {

                    cmd = new System.Data.SqlClient.SqlCommand(strStoredProcedure, sqlconn);
                    cmd.CommandText = strSPName;
                    cmd.CommandTimeout = 36000;
                    if (strFetchIDName.Length > 0)
                    {
                        int i;
                        for (i = 0; i <= strFetchIDName.Length - 1; i++)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@" + strFetchIDName[i], lngFetchID[i]);
                        }
                    }

                    adpCommon.SelectCommand = cmd;
                    dstCommon.Clear();
                    adpCommon.Fill(dstCommon, this.strViewName);
                    objReturnObject.dstResult.Clear();
                    objReturnObject.dstResult = dstCommon;
                    objReturnObject.intCode = 1;

                    objdb.DisConnectToDatabase();
                }
                //System.Data.SqlClient.SqlConnection sqlcnn;
                //strStoredProcedure = strSPName;
                //sqlcnn = objdb.ConnectToDB();
                //cmd = new System.Data.SqlClient.SqlCommand(strStoredProcedure, sqlcnn);


                //if (strFetchIDName.Length > 0)
                //{
                //    int i;
                //    for (i = 0; i <= strFetchIDName.Length - 1; i++)
                //    {
                //        log.Info("with parametersIdName =" + strFetchIDName[i] + "   with parameters Values" + lngFetchID[i]);
                //        cmd.CommandType = CommandType.StoredProcedure;
                //        cmd.Parameters.AddWithValue("@" + strFetchIDName[i], lngFetchID[i]);
                //    }
                //}

                //adpCommon.SelectCommand = cmd;
                //adpCommon.Fill(dstCommon, this.strViewName);
                ////struc.dstResult = dstCommon;
                ////struc.intCode = 1;
                //objReturnObject.dstResult = dstCommon;
                //objReturnObject.intCode = 1;

                //objdb.DisConnectToDatabase();

            }
            catch (System.Exception GetError)
            {

                objReturnObject.intCode = 0;
                objReturnObject.strMessage = GetError.Message;
                throw new Exception(GetError.Message);
            }


            return objReturnObject;
        }

        public clsReturnObject GetAllRecordsByNID(string strSPName)
        {
            try
            {
                System.Data.SqlClient.SqlConnection sqlcnn;
                strStoredProcedure = strSPName;
                sqlcnn = objdb.ConnectToDB();
                cmd = new System.Data.SqlClient.SqlCommand(strStoredProcedure, sqlcnn);

                //If strFetchIDName IsNot Nothing Then
                //    Dim i As Integer
                //    For i = 0 To strFetchIDName.Length - 1
                //        With cmd
                //            .CommandType = CommandType.StoredProcedure
                //            .Parameters.AddWithValue("@" & strFetchIDName(i), lngFetchID(i))
                //        End With
                //    Next
                //End If
                adpCommon.SelectCommand = cmd;
                adpCommon.Fill(dstCommon, this.strViewName);
                objReturnObject.dstResult = dstCommon;
                objReturnObject.intCode = 1;

                objdb.DisConnectToDatabase();

            }
            catch (System.Exception GetError)
            {
                objReturnObject.intCode = 0;
                objReturnObject.strMessage = GetError.Message;
                throw new Exception(GetError.Message);
            }

            return objReturnObject;
        }

        public clsReturnObject GetAllRecordsByNID(string strSPName, string[] strFetchIDName, object[] lngFetchID, int CommandTimeout)
        {
            
            try
            {

                strStoredProcedure = strSPName;

                using (SqlConnection sqlconn = objdb.ConnectToDB())
                {

                    cmd = new System.Data.SqlClient.SqlCommand(strStoredProcedure, sqlconn);
                    cmd.CommandText = strSPName;
                    cmd.CommandTimeout = CommandTimeout;
                    if (strFetchIDName.Length > 0)
                    {
                        int i;
                        for (i = 0; i <= strFetchIDName.Length - 1; i++)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@" + strFetchIDName[i], lngFetchID[i]);
                        }
                    }

                    adpCommon.SelectCommand = cmd;
                    adpCommon.Fill(dstCommon, this.strViewName);
                    objReturnObject.dstResult = dstCommon;
                    objReturnObject.intCode = 1;

                    objdb.DisConnectToDatabase();

                }





            }
            catch (System.Exception GetError)
            {

                
                objReturnObject.intCode = 0;
                objReturnObject.strMessage = GetError.Message;
                throw new Exception(GetError.Message);
            }


            return objReturnObject;
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
                objdb.Dispose();
                dstCommon.Dispose();
                adpCommon.Dispose();
                cmd.Dispose();
                objReturnObject.Dispose();
            }

            // Free any unmanaged objects here. 
            //objdb.Dispose();
            //dstCommon.Dispose();
            //adpCommon.Dispose();
            //cmd.Dispose();
            //objReturnObject.Dispose();
            disposed = true;
        }

        ~clsWDataSet()
        {
            Dispose(false);
        }
    }
}