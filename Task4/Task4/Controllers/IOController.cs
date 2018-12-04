namespace Task4.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Input/Output Controller for Requests.
    /// </summary>
    public static class IOController
    {
        /// <summary>
        /// Loads Requests from Xml file.
        /// </summary>
        /// <param name="path">Path to Xml file.</param>
        /// <returns>Returns <see cref="List{string}"/> of Requests.</returns>
        public static List<string> Load(string path = @"../../Requests.xml")
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

        /// <summary>
        /// Serializes <see cref="IEnumerable{string}"/> to file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="toSave"><see cref="string"/> to save.</param>
        public static void SerializeTo(string path, IEnumerable<string> toSave)
        {
            List<string> lst = new List<string>(toSave);
            XmlSerializer xmlSerializer = new XmlSerializer(lst.GetType());
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, lst);
            }
        }

        /// <summary>
        /// Saves <see cref="IEnumerable{string}"/> to file.
        /// </summary>
        /// <param name="toSave"><see cref="IEnumerable{string}"/> to save.</param>
        /// <param name="path">Path to file.</param>
        public static void SaveTo(IEnumerable<string> toSave, string path = @"../../Results.csv")
        {
            File.WriteAllLines(path, toSave);            
        }
    }
}
