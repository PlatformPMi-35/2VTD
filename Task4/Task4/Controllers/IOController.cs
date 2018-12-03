using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Task4.Controllers
{
    internal static class IOController
    {
        internal static List<string> Load(string path = @"../../Requests.xml")
        {
            List<string> res = new List<string>();
            XmlSerializer xmlSerializer = new XmlSerializer(res.GetType());
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                XmlReader xmlReader = XmlReader.Create(fileStream, null);
                if (xmlSerializer.CanDeserialize(xmlReader))
                {
                    res = (List<string>)xmlSerializer.Deserialize(xmlReader);
                }
                else
                {
                    throw new XmlException("Cannot Deserialize!");
                }
            }

            return res;
        }

        internal static void SerializeTo(string path, IEnumerable<string> toSave)
        {
            List<string> lst = new List<string>(toSave);
            XmlSerializer xmlSerializer = new XmlSerializer(lst.GetType());
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, lst);
            }
        }

        internal static void SaveTo(IEnumerable<string> toSave, string path = @"../../Results.csv")
        {
            File.WriteAllLines(path, toSave);            
        }
    }
}
