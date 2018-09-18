namespace FirstTask.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Triangle
    {
        private ColorSide[] sides;

        public Triangle()
        {
            sides = new ColorSide[3];
            for (int i = 0; i < 3; i++)
            {
                sides[i] = new ColorSide(Color.Black);
            }
        }

        public Triangle(ColorSide sideA, ColorSide sideB, ColorSide sideC)
        {
            try
            {
                sides = new ColorSide[3];
                SetSides(sideA, sideB, sideC);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static bool IsTriang(ColorSide sideA, ColorSide sideB, ColorSide sideC)
        {
            if (sideA.Length + sideB.Length <= sideC.Length ||
                            sideA.Length + sideC.Length <= sideB.Length ||
                            sideB.Length + sideC.Length <= sideA.Length)
            {
                return false;
            }
            return true;
        }

        public ColorSide[] GetSides()
        {          
            return (ColorSide[])sides.Clone();
        }

        public void SetSides(ColorSide sideA, ColorSide sideB, ColorSide sideC)
        {
            if (IsTriang(sideA, sideB, sideC) == false)
            {
                throw new ArgumentException("Transmitted sides can not make a triangle");
            }

            sides[0] = sideA;
            sides[1] = sideB;
            sides[2] = sideC;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5}", 
                sides[0].Color, sides[0].Length, sides[1].Color, sides[1].Length, sides[2].Color, sides[2].Length);
        }

        public static explicit operator Triangle(string str)
        {
            List<string> buff = str.Split().ToList();
            try
            {
                Color color1 = (Color)Enum.Parse(typeof(Color), buff[0]);
                Color color2 = (Color)Enum.Parse(typeof(Color), buff[2]);
                Color color3 = (Color)Enum.Parse(typeof(Color), buff[4]);

                return new Triangle( new ColorSide(color1, Convert.ToInt32(buff[1])),
                    new ColorSide(color2, Convert.ToInt32(buff[3])),
                    new ColorSide(color3, Convert.ToInt32(buff[5])));
            }
            catch (Exception)
            {
                throw new FormatException("Transmitted string is in wrong format");
            }
        }
    }
}
