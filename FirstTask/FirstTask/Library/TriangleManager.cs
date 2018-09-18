namespace FirstTask.Library
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class TriangleManager
    {
        public string Path { get; set; }

        public List<Triangle> Load()
        {
            List<Triangle> triangles = new List<Triangle>();

            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    while (!sr.EndOfStream)
                    {
                        triangles.Add((Triangle)sr.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return triangles;
        }

        public void Save(Triangle triangle)
        {
            try
            {
                using (StreamWriter wr = new StreamWriter(Path))
                {
                    wr.WriteLine(triangle.ToString());
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
