using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Practice.App_Code.DAL
{
    public class md5
    {
        string AppSalt = "bca2c785b14f79b3d5ec0d5db2f95d4dc385ffbb1a023e089625v987bd41a555";


        public bool CheckSignature(string Parameter, string Signature)
        {



            
            string a = Parameter + AppSalt;

            string b = encrypt(a);

            int test = string.Compare(b, Signature);

            if (test == 0)
            {
                return true;

            }

            else
            {
                return false;


            }



        }

        public static string encrypt(string bhash)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(bhash));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2").ToLower());
            }
            bhash = strBuilder.ToString();
            return bhash;


        }

        public static string Decrypt(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(Encoding.UTF8.GetBytes("bca2c785b14f79b3d5ec0d5db2f95d4dc385ffbb1a023e089625v987bd41a555"));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }

        public string makeRequest(string Parameter)
        {

            
            string a = Parameter + AppSalt;

            string b = encrypt(a);

            return b;
        }




    }


}
