using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;

namespace CSHomework09
{
    class Program
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {
            Program myProgram=new Program();
            string startUrl="https://movie.douban.com";
            if(args.Length>=1)
                startUrl=args[0];
            myProgram.urls.Add(startUrl,false); //加入初始页面

            new Thread(myProgram.Crawl).Start();    //开始爬行
            new Thread(myProgram.Crawl).Start();    //多线程
            new Thread(myProgram.Crawl).Start();
            new Thread(myProgram.Crawl).Start();
            new Thread(myProgram.Crawl).Start();
        }
        private void Crawl()
        {
            Console.WriteLine("开始爬虫.......");
            while(true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;//未访问网页
                    current = url;
                }
                Console.WriteLine("爬行" + current + "页面！");

                string html = DownLoad(current);

                urls[current] = true;
                count++;
                Parse(html);
            }
        }
        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            /* 
            *零个或多个
            +一个或多个
             */
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}