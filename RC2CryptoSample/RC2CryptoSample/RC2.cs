using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RC2CryptoSample
{
    public class RC2
    {

        //暗号キー
        private string _CryptoKey;

        private string _NomalMessage;

        private string _EncryptionMessage;

        private const string IV = "000";


        public RC2(string cryptoKey, string nomalMessage )
        {
            this._CryptoKey = cryptoKey;
            this._NomalMessage = nomalMessage;
        }

        public string EncryptString()
        {
            using (SymmetricAlgorithm csp = new DESCryptoServiceProvider())
            {
                csp.Key = getByts(this._CryptoKey);
                csp.IV = getByts(IV);

                using (ICryptoTransform transform = csp.CreateEncryptor())
                {
                    byte[] source = Encoding.UTF8.GetBytes(_NomalMessage);
                    byte[] encrypted = transform.TransformFinalBlock(source, 0, source.Length);

                    _EncryptionMessage = Convert.ToBase64String(encrypted);
                }

            }
        }



        private byte[] getByts(string txt)
        {
            return ASCIIEncoding.ASCII.GetBytes(txt);
        }


    }
}
