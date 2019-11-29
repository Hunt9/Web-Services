using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Practice.App_Code.DAL
{
    public class clsDataSet
    {
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x44, 0x16, 0xee, 0x88, 0x15, 0xdd, 0x41 };
        //clsWDataSet objWDataSet = new clsWDataSet();
        //private bool disposed = false;
        public clsDataSet()
        {
            //string[] dbFieldName = null; //not in use 
            //string dbAdditonalFieldName();
            //string dbAdditonalFieldValue();

            string strTableName = string.Empty;
            string strPrimaryKeyName = string.Empty;
            string strForeignKeyName = string.Empty;
            string intForeignKeyValue = string.Empty;
            string intPrimaryKeyValue = string.Empty;
            string strSPName = string.Empty;

        }

        //struct structTable
        //{
        //    string[] dbFieldName=null;
        //    //string dbAdditonalFieldName();
        //    //string dbAdditonalFieldValue();

        //    string strTableName=string.Empty;
        //    string strPrimaryKeyName = string.Empty;
        //    string strForeignKeyName = string.Empty;
        //    string intForeignKeyValue = string.Empty;
        //    string intPrimaryKeyValue = string.Empty;
        //    string strSPName = string.Empty;

        //public structTable() 
        //{
        //dbFieldName = null;
        //webControlValue = null;
        //strTableName = string.Empty;
        //strPrimaryKeyName =string.Empty;
        //strForeignKeyName = string.Empty;
        //intForeignKeyValue = string.Empty;
        //intPrimaryKeyValue = string.Empty;
        //strSPName = string.Empty;
        //}

        //}

        struct structResult
        {
            //public int intCode;
            //public int intPkCode;
            //public string strMessage;

            public DataSet dstResult;
            public void initialize()
            {
                dstResult = new DataSet();
            }
        }


        public DAL.clsWDataSet.clsReturnObject ExecSP(string strSPName, string[] strKeyName, object[] strKeyValue)
        {
            clsWDataSet objWDataSet = new clsWDataSet();
            //clsWDataSet.clsReturnObject objReturnObject = new clsWDataSet.clsReturnObject();
            try
            {


                clsWDataSet.clsReturnObject objReturnObject = new clsWDataSet.clsReturnObject();

                objReturnObject = objWDataSet.GetAllRecordsByNID(strSPName, strKeyName, strKeyValue);
                return objReturnObject;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public clsWDataSet.clsReturnObject ExecSP(string strSPName)
        {
            clsWDataSet objWDataSet = new clsWDataSet();
            try
            {
                clsWDataSet.clsReturnObject objReturnObject = new clsWDataSet.clsReturnObject();

                objReturnObject = objWDataSet.GetAllRecordsByNID(strSPName);
                return objReturnObject;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public clsWDataSet.clsReturnObject ExecSP(string strSPName, string[] strKeyName, object[] strKeyValue, int CommandTimeOut)
        {

            clsWDataSet objWDataSet = new clsWDataSet();
            try
            {
                clsWDataSet.clsReturnObject objReturnObject = new clsWDataSet.clsReturnObject();


                objReturnObject = objWDataSet.GetAllRecordsByNID(strSPName, strKeyName, strKeyValue, CommandTimeOut);
                return objReturnObject;
            }
            catch (Exception ex)
            {


                throw new Exception(ex.Message);
            }
        }



        public clsWDataSet.clsReturnObject FillCheckBoxList(WebControl ctlControl, string strSPName, string[] strKeyName, object[] strKeyValue, string DisPlayMember, string ValueMember)
        {

            clsWDataSet objWDataSet = new clsWDataSet();

            try
            {

                DataTable dtltemp;
                clsWDataSet.clsReturnObject objReturn;

                objReturn = objWDataSet.GetAllRecordsByNID(strSPName, strKeyName, strKeyValue);



                if (objReturn.intCode != 0)
                {
                    if (ctlControl.GetType() == typeof(CheckBoxList))
                    {

                        CheckBoxList cbo = (CheckBoxList)ctlControl;

                        dtltemp = objReturn.dstResult.Tables[0];

                        cbo.DataTextField = DisPlayMember;

                        cbo.DataValueField = ValueMember;

                        cbo.DataSource = dtltemp;

                        cbo.DataBind();

                    }

                }

                return objReturn;

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        public clsWDataSet.clsReturnObject FillTextBox(WebControl ctlControl, string strSPName, string[] strKeyName, object[] strKeyValue)
        {
            clsWDataSet objWDataSet = new clsWDataSet();
            try
            {
                DataTable dtltemp;
                clsWDataSet.clsReturnObject objReturn;
                objReturn = objWDataSet.GetAllRecordsByNID(strSPName, strKeyName, strKeyValue);

                if (objReturn.intCode != 0)
                {

                    if (ctlControl.GetType() == typeof(System.Web.UI.WebControls.TextBox))
                    {
                        System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox)ctlControl;
                        dtltemp = objReturn.dstResult.Tables[0];
                        txt.Text = Convert.ToString(objReturn.dstResult.Tables[0].Rows[0]["BodyContent"]);
                    }
                }
                return objReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public clsWDataSet.clsReturnObject FillCombo(WebControl ctlControl, string strSPName, string[] strKeyName, object[] strKeyValue, string DisPlayMember, string ValueMember)
        {
            clsWDataSet objWDataSet = new clsWDataSet();
            try
            {
                DataTable dtltemp;
                clsWDataSet.clsReturnObject objReturn;
                objReturn = objWDataSet.GetAllRecordsByNID(strSPName, strKeyName, strKeyValue);

                if (objReturn.intCode != 0)
                {

                    if (ctlControl.GetType() == typeof(DropDownList))
                    {
                        DropDownList cbo = (DropDownList)ctlControl;
                        dtltemp = objReturn.dstResult.Tables[0];
                        cbo.DataTextField = DisPlayMember;
                        cbo.DataValueField = ValueMember;
                        cbo.DataSource = dtltemp;
                        cbo.DataBind();
                    }
                }
                return objReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public clsWDataSet.clsReturnObject FillDDL(object[] ctlControl, string strSPName, string[] strKeyName, object[] strKeyValue, string[] DisPlayMember, string[] ValueMember)
        {
            clsWDataSet objWDataSet = new clsWDataSet();
            try
            {
                DataTable dtltemp;
                clsWDataSet.clsReturnObject objReturn;
                objReturn = objWDataSet.GetAllRecordsByNID(strSPName, strKeyName, strKeyValue);

                if (objReturn.intCode != 0)
                {
                    for (int i = 0; i < ctlControl.Length; i++)
                    {
                        //if (ctlControl.GetType() == typeof(DropDownList))
                        //{
                        DropDownList cbo = (DropDownList)ctlControl[i];
                        dtltemp = objReturn.dstResult.Tables[i];
                        cbo.DataTextField = DisPlayMember[i];
                        cbo.DataValueField = ValueMember[i];
                        cbo.DataSource = dtltemp;
                        cbo.DataBind();
                        //}
                    }
                }
                return objReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public clsWDataSet.clsReturnObject
        public void FillDDL(WebControl ctlControl, string strSPName, string[] strKeyName, object[] strKeyValue, string DisPlayMember, string ValueMember)
        {
            clsWDataSet objWDataSet = new clsWDataSet();
            try
            {
                DataTable dtltemp;
                clsWDataSet.clsReturnObject objReturn;
                objReturn = objWDataSet.GetAllRecordsByNID(strSPName, strKeyName, strKeyValue);

                if (objReturn.intCode != 0)
                {
                    if (ctlControl.GetType() == typeof(DropDownList))
                    {
                        DropDownList cbo = (DropDownList)ctlControl;
                        dtltemp = objReturn.dstResult.Tables[0];
                        cbo.DataTextField = DisPlayMember;
                        cbo.DataValueField = ValueMember;
                        cbo.DataSource = dtltemp;
                        cbo.DataBind();
                    }
                    objReturn = null;
                }
                //return objReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public clsWDataSet.clsReturnObject FillGrid(WebControl ctlControl, string strSPName, string[] strKeyName, object[] strKeyValue)
        {
            clsWDataSet objWDataSet = new clsWDataSet();
            try
            {
                DataTable dtltemp;
                clsWDataSet.clsReturnObject objReturn;
                objReturn = objWDataSet.GetAllRecordsByNID(strSPName, strKeyName, strKeyValue);


                if (objReturn.intCode != 0)
                {

                    if (ctlControl.GetType() == typeof(GridView))
                    {
                        GridView gv = (GridView)ctlControl;
                        dtltemp = objReturn.dstResult.Tables[0];
                        gv.DataSource = dtltemp;
                        gv.DataBind();
                    }
                }
                return objReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public clsWDataSet.clsReturnObject FillDataList(WebControl ctlControl, string strSPName, string[] strKeyName, object[] strKeyValue)
        {
            clsWDataSet objWDataSet = new clsWDataSet();
            try
            {
                DataTable dtltemp;
                clsWDataSet.clsReturnObject objReturn;
                objReturn = objWDataSet.GetAllRecordsByNID(strSPName, strKeyName, strKeyValue);


                if (objReturn.intCode != 0)
                {

                    if (ctlControl.GetType() == typeof(DataList))
                    {
                        DataList dl = (DataList)ctlControl;
                        dtltemp = objReturn.dstResult.Tables[0];
                        dl.DataSource = dtltemp;
                        dl.DataBind();
                    }
                }
                return objReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        public clsWDataSet.clsReturnObject FillRadioList(WebControl ctlControl, string strSPName, string[] strKeyName, object[] strKeyValue, string DisPlayMember, string ValueMember)
        {
            clsWDataSet objWDataSet = new clsWDataSet();
            try
            {
                DataTable dtltemp;
                clsWDataSet.clsReturnObject objReturn;
                objReturn = objWDataSet.GetAllRecordsByNID(strSPName, strKeyName, strKeyValue);

                if (objReturn.intCode != 0)
                {

                    if (ctlControl.GetType() == typeof(RadioButtonList))
                    {
                        RadioButtonList cbo = (RadioButtonList)ctlControl;
                        dtltemp = objReturn.dstResult.Tables[0];
                        cbo.DataTextField = DisPlayMember;
                        cbo.DataValueField = ValueMember;
                        cbo.DataSource = dtltemp;
                        cbo.DataBind();
                    }
                }
                return objReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool ChangeHashPassword(string EmpIndex, string OldPassword, string NewPassword, bool Isforcibly, int UserType)
        {
            try
            {

                SHA256 sha = new SHA256Managed();
                ASCIIEncoding ae = new ASCIIEncoding();
                clsWDataSet.clsReturnObject strResult = new clsWDataSet.clsReturnObject();
                bool Result = false;

                Byte[] OldPassData = ae.GetBytes(OldPassword);
                Byte[] NewPassData = ae.GetBytes(NewPassword);
                Byte[] OldPassDigest = sha.ComputeHash(OldPassData);
                Byte[] NewPassDigest = sha.ComputeHash(NewPassData);
                var OldPasswordHash = BytesToStringConverted(OldPassDigest);
                var NewPasswordHash = BytesToStringConverted(NewPassDigest);
                //var OldPasswordHash = System.Text.Encoding.UTF8.GetString(OldPassDigest, 0, OldPassDigest.Length);
                //var NewPasswordHash = Encoding.Unicode.GetString(NewPassDigest, 0, NewPassDigest.Length);



                string[] strFieldName = { "EmployeeIndex", "OldPasswordHash", "NewPasswordHash", "IsForcibly", "UserType" };
                object[] objFieldValue = { EmpIndex, OldPasswordHash, NewPasswordHash, Isforcibly, UserType };

                strResult = ExecSP("App_um_Hash_ChangePassword", strFieldName, objFieldValue);

                if (strResult.dstResult.Tables.Count > 0)
                {

                    if (Convert.ToInt16(strResult.dstResult.Tables[0].Rows[0]["Result"].ToString()) == 1)
                    {
                        Result = true;
                    }

                    else
                        Result = false;

                }
                return Result;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        static string BytesToStringConverted(byte[] bytes)
        {
            StringBuilder s = new StringBuilder();
            int length = bytes.Length;

            for (int n = 0; n < length - 1; n++)
            {
                s.Append((int)(bytes[n]));
                if (n != length - 1)
                {
                    s.Append(" ");
                }

            }

            return s.ToString();

        }

        

    }
}