namespace Task2.Library
{
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Json;

    /// <summary>
    /// Manager for Saving/Loading <see cref="PolyLine"/>.
    /// </summary>
    public class PolyLineIOManager
    {
        /// <summary>
        /// Saves <see cref="PolyLine"/>.
        /// </summary>
        /// <param name="lines"><see cref="IEnumerable{PolyLine}"/> to save.</param>
        /// <param name="path">Path to File.</param>
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

        /// <summary>
        /// Loads <see cref="PolyLine"/>.
        /// </summary>
        /// <param name="path">Path to File.</param>
        /// <returns><see cref="IEnumerable{PolyLine}"/> of <see cref="PolyLine"/>s.</returns>
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
