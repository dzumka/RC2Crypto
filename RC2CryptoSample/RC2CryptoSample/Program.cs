using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC2CryptoSample
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("暗号キーを5文字（アルファベット）入力して下さい");
            var key = Console.ReadLine();


            WriteLine("暗号化したテキストを入力して下さい");
            var message = Console.ReadLine();


            WriteLine("暗号化 Start");

            var crypto = new RC2(key, message);
            crypto.Encrypt();

            WriteLine("暗号化 End");
            WriteLine("");
            WriteLine(crypto.EncryptMessage);
            WriteLine("");
            WriteLine("");

            WriteLine("復号化 Start");
            crypto.Decrypt();
            WriteLine("復号化 End");
            WriteLine(crypto.NomarlMessage);



            Console.ReadLine();

        }



        private static void WriteLine(string txt)
        {
            Console.WriteLine(txt);
        }

    }
}
