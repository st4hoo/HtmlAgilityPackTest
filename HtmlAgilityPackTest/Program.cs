using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HtmlAgilityPackTest
{
    class Program
    {
        static void Main(string[] args)
        {

            string html =
                @"<div class=""article-content""> 
		           <p>text I want text I want text I want text I want <strong> TEXT I WANT TOO </strong></p> 
		           <p>text I want text I want text I want text I want <strong> TEXT I WANT TOO </strong></p> 
	            </div>";

            using (WebClient client = new WebClient())
            {
                client.Encoding = System.Text.Encoding.Unicode;
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var nodes = doc.DocumentNode.SelectNodes("//div[@class='article-content']/p");

                nodes.ToList().ForEach(n =>
                {
                    Console.WriteLine(n.InnerText);
                });

                Console.ReadLine();

            }

        }
    }
}
