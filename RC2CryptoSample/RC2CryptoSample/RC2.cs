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

        public string EncryptMessage
        {
            get
            {
                return this._EncryptionMessage;
            }
        }

        private const string IV = "00000000";


        public RC2(string cryptoKey, string nomalMessage )
        {
            this._CryptoKey = cryptoKey;
            this._NomalMessage = nomalMessage;
        }

        public void Encrypt()
        {
            using (SymmetricAlgorithm rc2Csp = new RC2CryptoServiceProvider())
            {
                rc2Csp.Key = getByts(this._CryptoKey);
                rc2Csp.IV = getByts(IV);

                using (ICryptoTransform transform = rc2Csp.CreateEncryptor())
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
