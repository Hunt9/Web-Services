using Practice.App_Code.DAL;
using Practice.App_Code.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Practice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        clsWDataSet.clsReturnObject structDB = new clsWDataSet.clsReturnObject();
        clsDataSet objDataset = new clsDataSet();


        public Header RegisterUser(string Name, string Description, string Email, string Password, string Signature)
        {
            Header header = new Header();
            
            try
            {

                md5 CheckSum = new md5();
                if (CheckSum.CheckSignature(Name + Description + Email + Password, Signature))
                {


                    string[] strFieldName = { "Name", "Description", "Email", "Password" };
                    object[] objFieldValue = { Name, Description, Email, Password };

                    structDB = objDataset.ExecSP("sp_insert_user", strFieldName, objFieldValue, 3600);

                    if (structDB.intCode == 1)
                    {

                        if (structDB.dstResult.Tables[0].Rows.Count > 0)
                        {
                            header = new Header
                            {
                                userid = structDB.dstResult.Tables[0].Rows[0]["UserId"].ToString(),
                                code = "400",
                                message = "User Successfully Created!",
                                status = "Success"
                            };


                        }
                    }
                    else
                    {
                        header = new Header
                        {
                            userid = "0",
                            code = "404",
                            message = "User Creation Unsuccessfully!",
                            status = "Unsuccessful"
                        };
                    }
                }
                else
                {
                    header = new Header
                    {
                        userid = "0",
                        code = "-1",
                        message = "Authentication Error",
                        status = "Unsuccessful"
                    };
                }

            }
        
            catch (Exception ex)
            {


                header = new Header
                {
                    userid = "0",
                    code = "405",
                    message = ex.Message,
                    status = "Unsuccessful"
                };
            }

            return header;
        }

        public Header Login(string Email, string Password, string Signature)
        {
            Header header = new Header();

            try
            {

                md5 CheckSum = new md5();
                if (CheckSum.CheckSignature(Email + Password, Signature))
                {


                    string[] strFieldName = { "Email", "Password" };
                    object[] objFieldValue = { Email, Password };

                    structDB = objDataset.ExecSP("sp_login_user", strFieldName, objFieldValue, 3600);

                    if (structDB.intCode == 1)
                    {

                        if (structDB.dstResult.Tables[0].Rows.Count > 0)
                        {
                            header = new Header
                            {
                                userid = structDB.dstResult.Tables[0].Rows[0]["Userid"].ToString(),
                                code = "400",
                                message = "User Login Successfully!",
                                status = "Success"
                            };


                        }
                    }
                    else
                    {
                        header = new Header
                        {
                            userid = "0",
                            code = "404",
                            message = "User Login Unsuccessfully!",
                            status = "Unsuccessful"
                        };
                    }
                }
                else
                {
                    header = new Header
                    {
                        userid = "0",
                        code = "-1",
                        message = "Authentication Error",
                        status = "Unsuccessful"
                    };
                }
            }
            catch (Exception ex)
            {


                header = new Header
                {
                    userid = "0",
                    code = "405",
                    message = ex.Message,
                    status = "Unsuccessful"
                };
            }

            return header;


        }

        public TransactionHistory TransactionHistory(string UserId, string Signature)
        {
            TransactionHistory transactionHistory = new TransactionHistory();

            try
            {

                md5 CheckSum = new md5();
                if (CheckSum.CheckSignature(UserId, Signature))
                {


                    string[] strFieldName = { "UserId"};
                    object[] objFieldValue = { UserId};

                    structDB = objDataset.ExecSP("sp_transaction_history", strFieldName, objFieldValue, 3600);

                    if (structDB.intCode == 1)
                    {

                        if (structDB.dstResult.Tables[0].Rows.Count > 0)
                        {
                            transactionHistory = new TransactionHistory
                            {
                                Transactionid = Convert.ToInt32(structDB.dstResult.Tables[0].Rows[0]["Transactionid"].ToString()),
                                CurrencyType = structDB.dstResult.Tables[0].Rows[0]["CurrencyType"].ToString(),
                                TransactionType = structDB.dstResult.Tables[0].Rows[0]["TransactionType"].ToString(),
                                CurrencyAmount = structDB.dstResult.Tables[0].Rows[0]["CurrencyAmount"].ToString(),
                                ProcessedAt = structDB.dstResult.Tables[0].Rows[0]["ProcessedAt"].ToString(),
                                State = structDB.dstResult.Tables[0].Rows[0]["State"].ToString()
                                
                            };


                        }
                    }
                    else
                    {
                        transactionHistory = null;
                   
                    }
                }

                else
                {

                    transactionHistory = new TransactionHistory
                    {
                        Transactionid = 0,
                        CurrencyType = "invalid",
                        TransactionType = "invalid",
                        CurrencyAmount = "invalid",
                        ProcessedAt = "invalid",
                        State = "Authentication Error"

                    };
                }
            }
            catch (Exception ex)
            {


                transactionHistory = new TransactionHistory
                {
                    Transactionid = 0,
                    CurrencyType = "invalid",
                    TransactionType = "invalid",
                    CurrencyAmount = "invalid",
                    ProcessedAt = "invalid",
                    State = ex.Message

                };
            }

            return transactionHistory;

        }

        public Header UpdateWallet(string UserId, string AccountId, string Balance, string AccountType, string Signature)
        {

            Header header = new Header();

            try
            {

                md5 CheckSum = new md5();
                if (CheckSum.CheckSignature(UserId + AccountId + Balance + AccountType, Signature))
                {


                    string[] strFieldName = { "UserId", "AccountId", "Balance", "AccountType" };
                    object[] objFieldValue = { UserId, AccountId, Balance, AccountType };

                    structDB = objDataset.ExecSP("sp_update_wallet", strFieldName, objFieldValue, 3600);

                    if (structDB.intCode == 1)
                    {

                        if (structDB.dstResult.Tables[0].Rows.Count > 0)
                        {
                            header = new Header
                            {
                                userid = structDB.dstResult.Tables[0].Rows[0]["Userid"].ToString(),
                                code = "400",
                                message = "Wallet Updated Successfully!",
                                status = "Success"
                            };


                        }
                    }
                    else
                    {
                        header = new Header
                        {
                            userid = "0",
                            code = "404",
                            message = "Wallet Update Unsuccessfull!",
                            status = "Unsuccessful"
                        };
                    }
                }
                else
                {

                    header = new Header
                    {
                        userid = "0",
                        code = "405",
                        message = "Authentication Error",
                        status = "Unsuccessful"
                    };

                }
            }
            catch (Exception ex)
            {


                header = new Header
                {
                    userid = "0",
                    code = "405",
                    message = ex.Message,
                    status = "Unsuccessful"
                };
            }

            return header;
        }

        public Header VerifyAccount(string UserId, string AccountType, string AccountId, string Signature)
        {

            Header header = new Header();

            try
            {

                md5 CheckSum = new md5();
                if (CheckSum.CheckSignature(UserId + AccountType + AccountId, Signature))
                {


                    string[] strFieldName = { "UserId", "AccountType", "AccountId" };
                    object[] objFieldValue = { UserId, AccountType, AccountId};

                    structDB = objDataset.ExecSP("sp_verify_account", strFieldName, objFieldValue, 3600);

                    if (structDB.intCode == 1)
                    {

                        if (structDB.dstResult.Tables[0].Rows.Count > 0)
                        {
                            header = new Header
                            {
                                userid = structDB.dstResult.Tables[0].Rows[0]["Userid"].ToString(),
                                code = "400",
                                message = "Account Verified Successfully!",
                                status = "Success"
                            };


                        }
                    }
                    else
                    {
                        header = new Header
                        {
                            userid = "0",
                            code = "404",
                            message = "Account Could not be Verified!",
                            status = "Unsuccessful"
                        };
                    }
                }

                else
                {

                    header = new Header
                    {
                        userid = "0",
                        code = "405",
                        message = "Authentication Error",
                        status = "Unsuccessful"
                    };

                }
            }
            catch (Exception ex)
            {


                header = new Header
                {
                    userid = "0",
                    code = "405",
                    message = ex.Message,
                    status = "Unsuccessful"
                };
            }

            return header;
        }

        public Header DoTransaction(string CurrencyAmount, string CurrencyType, string SourceUserId, string TargetUserId, string AccountType, string Signature)
        {

            Header header = new Header();

            try
            {

                md5 CheckSum = new md5();
                if (CheckSum.CheckSignature(CurrencyAmount + CurrencyType + SourceUserId + TargetUserId+ AccountType, Signature))
                {


                    string[] strFieldName = { "CurrencyAmount","CurrencyType","SourceUserId","TargetUserId","AccountType"};
                    object[] objFieldValue = { CurrencyAmount, CurrencyType, SourceUserId, AccountType, AccountType };

                    structDB = objDataset.ExecSP("sp_insert_transaction", strFieldName, objFieldValue, 3600);

                    if (structDB.intCode == 1)
                    {

                        if (structDB.dstResult.Tables[0].Rows.Count > 0)
                        {
                            header = new Header
                            {
                                userid = structDB.dstResult.Tables[0].Rows[0]["Userid"].ToString(),
                                code = "400",
                                message = "Transaction Successfully Processed!",
                                status = "Success"
                            };


                        }
                    }
                    else
                    {
                        header = new Header
                        {
                            userid = "0",
                            code = "404",
                            message = "Transaction Failed!",
                            status = "Unsuccessful"
                        };
                    }
                }


                else
                {

                    header = new Header
                    {
                        userid = "0",
                        code = "405",
                        message = "Authentication Error",
                        status = "Unsuccessful"
                    };

                }
            }
            catch (Exception ex)
            {


                header = new Header
                {
                    userid = "0",
                    code = "405",
                    message = ex.Message,
                    status = "Unsuccessful"
                };
            }

            return header;
        }
    }
}
