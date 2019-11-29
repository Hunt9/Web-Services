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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "GET",
       ResponseFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Bare,
       UriTemplate = "DoTransaction?CurrencyAmount={CurrencyAmount}&CurrencyType={CurrencyType}&SourceUserId={SourceUserId}&TargetUserId={TargetUserId}&AccountType={AccountType}&Signature={Signature}")]
       Header DoTransaction(string CurrencyAmount, string CurrencyType, string SourceUserId, string TargetUserId, string AccountType, string Signature);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "RegisterUser?Name={Name}&Description={Description}&Email={Email}&Password={Password}&Signature={Signature}")]
        Header RegisterUser(string Name, string Description, string Email, string Password, string Signature);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "Login?Email={Email}&Password={Password}&Signature={Signature}")]
        Header Login(string Email, string Password, string Signature);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "TransactionHistory?UserId={UserId}&Signature={Signature}")]
        TransactionHistory TransactionHistory(string UserId, string Signature);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "UpdateWallet?UserId={UserId}&AccountId={AccountId}&Balance={Balance}&AccountType={AccountType}&Signature ={Signature}")]
        Header UpdateWallet(string UserId, string AccountId, string Balance, string AccountType, string Signature);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "VerifyAccount? UserId ={UserId}&AccountType={AccountType}&AccountId={AccountId}&Signature={Signature}")]
        Header VerifyAccount(string UserId, string AccountType, string AccountId, string Signature);


    }
}
