namespace FirstTask.Library
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// <see cref="TriangleManager"/> works with <see cref="Triangle"/>.
    /// </summary>
    internal class TriangleManager
    {
        /// <summary>
        /// Loads <see cref="Triangle"/>s ffrom file.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <returns>Returns <see cref="List{Triangle}"/>.</returns>
        public SortedList<int, Triangle> Load(string path)
        {
            SortedList<int, Triangle> triangles = new SortedList<int, Triangle>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        Triangle buffTriang = (Triangle)sr.ReadLine();
                        triangles.Add(Perim(buffTriang), buffTriang);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return triangles;
        }

        /// <summary>
        /// Saves <see cref="Triangle"/> to the file.
        /// </summary>
        /// <param name="path">Path, where <see cref="Triangle"/> will be saved.</param>
        /// <param name="triangle"><see cref="Triangle"/> that will be saved.</param>
        public void Save(string path, Triangle triangle)
        {
            try
            {
                using (StreamWriter wr = new StreamWriter(path))
                {
                    wr.WriteLine(triangle.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Perim(Triangle triangle)
        {
            int res = 0;
            foreach (ColorSide s in triangle.GetSides())
            {
                res += s.Length;
            }
            return res;
        }
    }
}