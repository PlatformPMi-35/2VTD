using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Library
{
    class PolyLineIOManager
    {
        public static void Save(IEnumerable<PolyLine> lines, string path)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(PolyLine));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, lines);
            }

        }

        public static IEnumerable<PolyLine> Load(string path)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(PolyLine));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                IEnumerable<PolyLine> lines = (IEnumerable<PolyLine>)jsonFormatter.ReadObject(fs);

                return lines;
            }
        }
    }
}
