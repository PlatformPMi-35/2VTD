namespace Task2.Library
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Manager for Saving/Loading <see cref="PolyLine"/>.
    /// </summary>
    public class PolyLineIOManager
    {
        /// <summary>
        /// Saves <see cref="PolyLine"/>.
        /// </summary>
        /// <param name="lines"><see cref="List{PolyLine}"/> to save.</param>
        /// <param name="path">Path to File.</param>
        public static void Save(List<PolyLine> lines, string path)
        {
            try
            {
                //цей об'єкт записує дані в хмл файл
                XmlSerializer formatter = new XmlSerializer(typeof(List<PolyLine>));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, lines);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Loads <see cref="PolyLine"/>.
        /// </summary>
        /// <param name="path">Path to File.</param>
        /// <returns><see cref="List{PolyLine}"/> of <see cref="PolyLine"/>s.</returns>
        public static List<PolyLine> Load(string path)
        {
            try
            {
                //цей об'єкт зчитує дані з хмл файлу
                XmlSerializer formatter = new XmlSerializer(typeof(List<PolyLine>));
                List<PolyLine> lines = new List<PolyLine>();

                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    lines = (List<PolyLine>)formatter.Deserialize(fs);
                }

                return lines;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
