using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Framework.Utils
{
    public static class Text
    {
        /// <summary>
        /// 按位生随机码
        /// </summary>
        /// <param name="codeCount"></param>
        /// <returns></returns>
        public static string CreateRandomCode(int codeCount = 4)
        {
            int number;
            string randomCode = string.Empty;
            Random random = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                number = random.Next(100);
                switch (number % 3)
                {
                    case 0:
                        randomCode += ((char)('0' + (char)(number % 10))).ToString();
                        break;
                    case 1:
                        randomCode += ((char)('a' + (char)(number % 26))).ToString();
                        break;
                    case 2:
                        randomCode += ((char)('A' + (char)(number % 26))).ToString();
                        break;
                    default:
                        break;
                }
            }
            return randomCode;
        }
        /// <summary>
        /// EDC加密过程
        /// </summary>
        /// <param name="pToDecrypt">被加密的字符串</param>
        /// <param name="sKey">密匙（只支持8个字节的密匙）</param>
        /// <returns></returns>
        public static string ToEncrypt(this string pToEncrypt, string sKey)
        {
            //访问数据加密标准(DES)算法的加密服务提供程序 (CSP) 版本的包装对象
            DESCryptoServiceProvider Des = new DESCryptoServiceProvider();
            //建立加密对象的密钥和偏移量
            Des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法
            Des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            //把字符串放到byte数组中
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            MemoryStream ms = new MemoryStream();//创建其支持存储区为内存的流　
            //定义将数据流链接到加密转换的流
            CryptoStream cs = new CryptoStream(ms, Des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //上面已经完成了把加密后的结果放到内存中去
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }

        /// <summary>
        /// DEC 解密过程
        /// </summary>
        /// <param name="pToDecrypt">被解密的字符串</param>
        /// <param name="sKey">密钥（只支持8个字节的密钥，同前面的加密密钥相同）</param>
        /// <returns>返回被解密的字符串</returns>
        public static string ToDecrypt(this string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider Des = new DESCryptoServiceProvider();
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }
            //建立加密对象的密钥和偏移量，此值重要，不能修改
            Des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            Des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, Des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

    }
}
