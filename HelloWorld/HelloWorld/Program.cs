using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace HelloWorld
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string webpage = "https://hocdientucoban.com/mau-kich-ban-chuong-trinh-hop-lop/";
            string browser = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            string filePath = $@"{Environment.CurrentDirectory}\index.html";
            DownloadIfFileDoesNotExists(webpage, filePath);
            RemoveAllScriptTags(filePath);
            Process.Start(browser, filePath);
            GetContent(filePath);
            Process.Start("Notepad.exe", filePath);
            Console.Write("Press any key to exit..");
            Console.ReadKey();
        }

        private static void GetContent(string filePath)
        {
            string[] whiteList = new[]
            {
                "#comment", "html", "head",
                "title", "body", "img", "p",
                "a"
            };
            string html = File.ReadAllText(filePath, Encoding.UTF8);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            List<HtmlNode> nodesToRemove = new List<HtmlNode>();
            System.Collections.IEnumerator e = doc
                .CreateNavigator()
                .SelectDescendants(XPathNodeType.All, false)
                .GetEnumerator();
            while (e.MoveNext())
            {
                HtmlNode node =
                    ((HtmlNodeNavigator)e.Current)
                    .CurrentNode;
                if (!whiteList.Contains(node.Name))
                {
                    nodesToRemove.Add(node);
                }
            }
            nodesToRemove.ForEach(node => node.Remove());
            StringBuilder sb = new StringBuilder();
            using (StringWriter w = new StringWriter(sb))
            {
                doc.Save(w);
            }
            Console.WriteLine(sb.ToString());
            //File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        private static void RemoveAllScriptTags(string filePath)
        {
            string input = File.ReadAllText(filePath, Encoding.UTF8);
            string output = string.Empty;
            Regex rRemScript = new Regex(@"<script[^>]*>[\s\S]*?</script>");
            output = rRemScript.Replace(input, "");

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(output);

            doc.DocumentNode.Descendants()
                            .Where(n => n.Name == "script" || n.Name == "style")
                            .ToList()
                            .ForEach(n => n.Remove());
            doc.Save(filePath);
            //File.WriteAllText(filePath, output, Encoding.UTF8);
            Process.Start("Notepad.exe", filePath);
        }

        private static void DownloadIfFileDoesNotExists(string webpage, string filePath)
        {
            if (!File.Exists(filePath) || string.IsNullOrWhiteSpace(File.ReadAllText(filePath, Encoding.UTF8)))
            {
                WebRequest request = WebRequest.Create(webpage);
                WebResponse response = request.GetResponse();
                string content = null;
                using (StreamReader streamreader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    content = streamreader.ReadToEnd();
                }
                File.WriteAllText(filePath, content, Encoding.UTF8);
            }
        }
    }
}