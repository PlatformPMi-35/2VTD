namespace FirstTask.Library
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class TriangleManager
    {
        public List<Triangle> Load(string path)
        {
            List<Triangle> triangles = new List<Triangle>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
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

        public void Save(string path, Triangle triangle)
        {
            try
            {
                using (StreamWriter wr = new StreamWriter(path))
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
