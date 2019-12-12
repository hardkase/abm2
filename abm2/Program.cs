using System;
using System.Data;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace abm2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> answers = new List<string>();
            string[] match = new string[] { "MWB", "TRV", "CAR" };
            XmlDocument xmldoc = new XmlDocument();
            string xmlDocPath = "c:/code/abm_test/abm2/test2.xml";
            XmlNodeList xmlnode;
            FileStream fs = new FileStream(xmlDocPath, FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("Reference");
            for (var i = 0; i < xmlnode.Count; i++)
            {
                var check = xmlnode[i].Attributes["RefCode"].Value;
                if (Array.IndexOf(match, check) >= 0)
                {
                    //Now we need to get the Inner Text of the associated child node
                    answers.Add(xmlnode[i].FirstChild.InnerText);
                }
            }
            foreach (string text in answers)
            {
                Console.WriteLine(text);
            }
            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}
