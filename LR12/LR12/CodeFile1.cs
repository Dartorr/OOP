using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Linq;
using System.Xml;
using System.Linq;

namespace LW12
{
   
    public class Program
    {
        
        [Serializable]
        public class Stuff
        {
            public int Cost;
            public int Age;

            public Stuff()
            {

            }
        }

        [Serializable]
        public class Tech : Stuff //наследование Tech от Stuff
        {
            public string Model;
            public int Power_consumption;
            public int Complexity;

            public Tech()
            {
                Cost = 0;
                Age = 1;
                Model = "oleg";
                Power_consumption = 5;
                Complexity = 2;
            }

            public Tech(int a)
            {
                Cost = 0;
                Age = 1;
                Model = "oleg";
                Power_consumption = 5;
                Complexity = 2;
            }
        }



        public static void Main(string[] args)
        {
            Tech oleg = new Tech();

            //json
            using (FileStream fs = new FileStream("Oleg/Tech.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync(fs, oleg);
            }

            using (FileStream fs = new FileStream("Oleg/Tech.json", FileMode.OpenOrCreate))
            {
                var restTech = JsonSerializer.DeserializeAsync<Tech>(fs);
                Console.WriteLine(restTech);
            }


            //bin
            BinaryFormatter nbf = new BinaryFormatter();
            using (FileStream fs = new FileStream("Oleg/tech.dat", FileMode.OpenOrCreate))
            {
                nbf.Serialize(fs, oleg);

            }


            //xml
            XmlSerializer xmlser = new XmlSerializer(type: typeof(Tech));
            using (FileStream fs = new FileStream("Oleg/Tech.xml", FileMode.OpenOrCreate))
            {
                xmlser.Serialize(fs, oleg);
            }


            //soap
            SoapFormatter soapser = new SoapFormatter();
            using (FileStream fs = new FileStream("Oleg/Tech.soap", FileMode.OpenOrCreate))
            {
                soapser.Serialize(fs, oleg);
            }


            //массив в xml
            Tech[] mass = new Tech[] { new Tech(), new Tech(), new Tech(), new Tech(), };
            using (FileStream fs = new FileStream("Oleg/mass.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xmlmass_ser = new XmlSerializer(typeof(Tech[]));
                xmlmass_ser.Serialize(fs, mass);
            }


            //XPath
            XmlDocument xml = new XmlDocument();
            xml.Load("Oleg/mass.xml");
            XmlElement xml_root = xml.DocumentElement;
            XmlNodeList nodeList = xml_root.SelectNodes("*");
            foreach (XmlNode t in nodeList) Console.WriteLine(t.SelectSingleNode("Model").InnerText);


            //Linq to xml
            XDocument xDocument = XDocument.Load("Oleg/mass_for_linq.xml");
            var items = from t in xDocument.Element("ArrayOfTech").Elements("Tech")
                        where t.Element("Model").Value != "oleg"
                        select t;
            foreach (var t in items) Console.WriteLine(t);

        }
    }
}
