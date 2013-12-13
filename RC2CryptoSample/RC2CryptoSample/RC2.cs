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

        public string NomarlMessage
        {
            get
            {
                return this._NomalMessage;
            }
        }

        private string _EncryptionMessage;

        public string EncryptMessage
        {
            set
            {
                this._EncryptionMessage = value;
            }
            get
            {
                return this._EncryptionMessage;
            }
        }

        private string _IV;
        public string IV
        {
            get
            {
                if (this._IV == null)
                {
                    this._IV = "00000000";
                }
                return this._IV;
            }
            set
            {
                this._IV = value;
            }
        }
           


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

                using (ICryptoTransform encryptor = rc2Csp.CreateEncryptor())
                {
                    byte[] source = Encoding.UTF8.GetBytes(_NomalMessage);
                    byte[] encrypted = encryptor.TransformFinalBlock(source, 0, source.Length);

                    _EncryptionMessage = Convert.ToBase64String(encrypted);
                }

            }
        }


        public void Decrypt()
        {
            using (SymmetricAlgorithm rc2Csp = new RC2CryptoServiceProvider())
            {
                rc2Csp.Key = getByts(this._CryptoKey);
                rc2Csp.IV = getByts(IV);

                using (ICryptoTransform encryptor = rc2Csp.CreateDecryptor())
                {
                    byte[] source = Convert.FromBase64String(_EncryptionMessage);
                    byte[] decrypted = encryptor.TransformFinalBlock(source, 0, source.Length);

                    this._NomalMessage=Encoding.UTF8.GetString(decrypted);
                }
            }
        }







        private byte[] getByts(string txt)
        {
            return ASCIIEncoding.ASCII.GetBytes(txt);
        }


    }
}
