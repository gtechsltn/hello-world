using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;

namespace WebCrawler
{
    /// <summary>
    /// TODO: Chiến cần luyện cách dùng những hàm, những class ở dưới:
    /// --------------------------------------------------------------
    /// 
    /// System.Console
    /// 
    /// System.Diagnostics
    ///     System.Diagnostics.Debug.WriteLine(...)
    ///     System.Diagnostics.Stopwatch
    ///     
    /// System.IO.File
    /// 
    /// System.IO.Path
    /// 
    /// System.Text.Encoding
    /// 
    /// System.Net.Http.HttpClient
    /// 
    /// System.Net.HttpWebRequest
    /// System.Net.HttpWebResponse
    /// 
    /// System.Net.WebClient
    /// 
    /// System.Configuration
    ///     System.Configuration.ConfigurationManager.ConnectionStrings
    ///     System.Configuration.ConfigurationManager.AppSettings
    ///     
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //File.Read
            //------------------------
            //File.ReadAllBytes(...);
            //File.ReadAllLines(...);
            //File.ReadAllText(...);
            //
            //File.Write
            //------------------------
            //File.WriteAllText(...);
            //File.WriteAllBytes(...);
            //File.WriteAllLines(...);
            //
            //Path.
            //------------------------
            //Path.Combine()
            //Path.GetDirectoryName();
            //Path.GetExtension();
            //Path.GetFileName();
            //Path.GetFileNameWithoutExtension();
            Console.WriteLine("..."); //Viết lên màn hình 1 dòng chữ ...
            Console.ReadKey(); //Dừng lại chương trình, chờ người dùng nhập vào 1 kí tự
        }
    }
}
