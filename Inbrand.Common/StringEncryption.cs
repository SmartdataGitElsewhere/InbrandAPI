using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Inbrand.Common
{
    public class StringEncryption
    {
        public static string Encrypt(string strToEncrypt, string strKey)
        {
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto =
                    new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
                byte[] byteHash, byteBuff;
                string strTempKey = strKey;
                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
                byteBuff = ASCIIEncoding.ASCII.GetBytes(strToEncrypt);
                return Convert.ToBase64String(objDESCrypto.CreateEncryptor().
                    TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }
            catch (Exception ex)
            {
                return "Wrong Input. " + ex.Message;
            }
        }

        public Stream GetCsvStream<T>(IEnumerable<T> list)
        {
            Type type = list.ToList()[0].GetType();
            string newLine = Environment.NewLine;
            MemoryStream memoryStream = null;
            if (list != null && list.Count() > 0)
                memoryStream = new MemoryStream();
            else return null;
            var sw = new StreamWriter(memoryStream);
            //make a new instance of the class name we figured out to get its props
            object o = Activator.CreateInstance(type);
            //gets all properties
            PropertyInfo[] props = o.GetType().GetProperties();

            //foreach of the properties in class above, write out properties
            //this is the header row
            sw.Write(string.Join(",", props.Select(d => d.Name).ToArray()) + newLine);

            //this acts as datarow
            foreach (var item in list)
            {
                //this acts as datacolumn
                var row = string.Join(",", props.Select(d => item.GetType()
                                                                .GetProperty(d.Name)
                                                                .GetValue(item, null) != null ? item.GetType()
                                                                .GetProperty(d.Name)
                                                                .GetValue(item, null)
                                                                .ToString().Contains(",") ? "\"" + item.GetType()
                                                                .GetProperty(d.Name)
                                                                .GetValue(item, null)
                                                                .ToString() + "\"" : item.GetType()
                                                                .GetProperty(d.Name)
                                                                .GetValue(item, null)
                                                                .ToString() : string.Empty)
                                                        .ToArray());
                sw.Write(row + newLine);
            }
            sw.Flush();
            return memoryStream;
        }
    }
}
