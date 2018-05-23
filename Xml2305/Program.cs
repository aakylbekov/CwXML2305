using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Xml2305
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("view-source_https___habr.com_rss_interesting_.xml");

            PrintXml(doc);

            XmlElement status = doc.CreateElement("status");
            status.InnerText = "Active";

            XmlNodeList title = doc.GetElementsByTagName("title");
            //var test = title[0]; //proverka

            XmlElement root = doc.DocumentElement;
            //dobavlenie
            //root.AppendChild(status);
            //root.InsertAfter(status, title[0]);
            //root.InsertBefore(status, title[0]);

            CreateElement(doc, "Alen");

            Console.ForegroundColor = ConsoleColor.White;
            doc.Save("view-source_https___habr.com_rss_interesting_.xml");

            Console.WriteLine("--------------------");
            Console.WriteLine("File saved");
            Console.WriteLine("--------------------");

           
        }

        public static void PrintXml(XmlDocument doc)
        {
            var root = doc.DocumentElement;
            foreach (XmlNode item in root.ChildNodes)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(item.Name);
                Console.ForegroundColor = ConsoleColor.White;
                if (item.HasChildNodes)
                {
                    foreach (XmlNode child in item.ChildNodes)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("  " + child.Name);
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
            }
        }

        public static void CreateElement(XmlDocument doc, string elementName)
        {
            //1
            Console.ForegroundColor = ConsoleColor.Green;
            XmlElement element = doc.CreateElement(elementName);
            element.InnerText = DateTime.Now.ToString();
           
            XmlAttribute xmlAtr = doc.CreateAttribute("Id");
            xmlAtr.InnerText = "32324";

            element.Attributes.Append(xmlAtr);

            XmlElement root = doc.DocumentElement;
            root.AppendChild(element);
           
           

        }
    }
}
