namespace Task2.Library
{
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Json;

    public class PolyLineIOManager
    {
        public static void Save(IEnumerable<PolyLine> lines, string path)
        {
            try
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(PolyLine));

                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, lines);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            
        }

        public static IEnumerable<PolyLine> Load(string path)
        {
            try
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(PolyLine));

                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    IEnumerable<PolyLine> lines = (IEnumerable<PolyLine>)jsonFormatter.ReadObject(fs);

                    return lines;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }
    }
}
