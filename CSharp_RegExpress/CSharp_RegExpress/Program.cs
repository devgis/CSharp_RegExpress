using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CSharp_RegExpress
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());


            string TaobaoLink = "<a href=\"http://www.taobao.com\" title=\"特殊的\" target=\"_blank\"/><a href=\"http://www.taobao.com\" title=\"淘宝网 - 淘！我喜欢\" target=\"_blank\">淘宝</a><a href=\"http://www.taobao.com\" title=\"淘宝网 - 淘！我喜欢\" target=\"_blank\">淘宝</a><a href=\"http://www.taobao.com\" title=\"淘宝网 - 淘！我喜欢\" target=\"_blank\">淘宝</a><a href=\"http://www.taobao.com\" title=\"淘宝网 - 淘！我喜欢\" target=\"_blank\">淘宝</a><a href=\"http://www.taobao.com\" title=\"淘宝网 - 淘！我喜欢\" target=\"_blank\">淘宝</a>";
            string RegexStr = @"<a[^>]+href=""(\S+)""[^>]+title=""([\s\S]+?)""[^>]+>(\S+)</a>";
            Console.WriteLine($"TaobaoLink:\r\n{TaobaoLink}\r\n");
            Console.WriteLine($"RegexStr:\r\n{RegexStr}\r\n");
            Match mat = Regex.Match(TaobaoLink, RegexStr);
            for (int i = 0; i < mat.Groups.Count; i++)
            {
                Console.WriteLine("第" + i + "组：" + mat.Groups[i].Value);
            }
            Console.WriteLine("------------------------------------------------------------------");
            RegexStr = @"<a.*?(/a>|/>)"; //@"<a.*?/a>";
            var mats = Regex.Matches(TaobaoLink, RegexStr);
            Console.WriteLine($"TaobaoLink:\r\n{TaobaoLink}\r\n");
            Console.WriteLine($"RegexStr:\r\n{RegexStr}\r\n");
            for (int i = 0; i < mats.Count; i++)
            {
                for (int j = 0; j < mats[i].Groups.Count; j++)
                {
                    Console.WriteLine($"第{i}{j}组：" + mats[i].Groups[j].Value);
                }
            }

            Console.WriteLine("------------------------------------------------------------------");
            RegexStr = @"<a.*^[/>].*?</a>|<a.*?/>"; //@"<a.*?/a>";
            mats = Regex.Matches(TaobaoLink, RegexStr);
            Console.WriteLine($"TaobaoLink:\r\n{TaobaoLink}\r\n");
            Console.WriteLine($"RegexStr:\r\n{RegexStr}\r\n");
            for (int i = 0; i < mats.Count; i++)
            {
                for (int j = 0; j < mats[i].Groups.Count; j++)
                {
                    Console.WriteLine($"第{i}{j}组：" + mats[i].Groups[j].Value);
                }
            }

            Console.Read();
        }
    }
}
