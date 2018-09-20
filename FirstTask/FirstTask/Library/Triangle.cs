namespace FirstTask.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents <see cref="Triangle"/>.
    /// </summary>
    public class Triangle
    {
        /// <summary>
        /// Has ColorSides.
        /// </summary>
        private ColorSide[] sides;
       
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle" /> class and sets all <see cref="ColorSide"/> to <see cref="Color.Black"/>.
        /// </summary>
        public Triangle()
        {
            this.sides = new ColorSide[3];
            for (int i = 0; i < 3; i++)
            {
                this.sides[i] = new ColorSide(Color.Black);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle" /> class and sets all it Three <see cref="ColorSide"/>.
        /// </summary>
        /// <param name="sideA">Represent First <see cref="Triangle"/> <see cref="ColorSide"/> will be set.</param>
        /// <param name="sideB">Represent Second <see cref="Triangle"/> <see cref="ColorSide"/> will be set.</param>
        /// <param name="sideC">Represent Third <see cref="Triangle"/> <see cref="ColorSide"/> will be set.</param>
        /// <exception cref="ArgumentException">Invalid Argument.</exception>
        public Triangle(ColorSide sideA, ColorSide sideB, ColorSide sideC)
        {
            try
            {
                this.sides = new ColorSide[3];
                this.SetSides(sideA, sideB, sideC);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets or sets sides of the <see cref="Triangle"/>.
        /// </summary>
        /// <value>Gets or sets sides.</value>
        public ColorSide[] Sides
        {
            get
            {
                return this.sides;
            }

            set
            {
                this.sides = value;
            }
        }

        /// <summary>
        /// Transforms <see cref="string"/> into <see cref="Triangle"/>.
        /// </summary>
        /// <param name="str"> <see cref="string"/> that will be transformed into <see cref="Triangle"/>.</param>
        /// <exception cref="FormatException">Ivalid Format.</exception>
        public static explicit operator Triangle(string str)
        {
            List<string> buff = str.Split().ToList();
            try
            {
                Color color1 = (Color)Enum.Parse(typeof(Color), buff[0]);
                Color color2 = (Color)Enum.Parse(typeof(Color), buff[2]);
                Color color3 = (Color)Enum.Parse(typeof(Color), buff[4]);

                return new Triangle(
                    new ColorSide(color1, Convert.ToInt32(buff[1])),
                    new ColorSide(color2, Convert.ToInt32(buff[3])),
                    new ColorSide(color3, Convert.ToInt32(buff[5])));
            }
            catch (Exception)
            {
                throw new FormatException("Transmitted string is in wrong format");
            }
        }

        /// <summary>
        /// Clones <see cref="ColorSide"/>s of <see cref="Triangle"/>.
        /// </summary>
        /// <returns>Cloned <see cref="ColorSide"/>s of <see cref="Triangle"/>.</returns>
        public ColorSide[] GetSides()
        {          
            return (ColorSide[])this.sides.Clone();
        }

        /// <summary>
        /// Returns Perimetr of the <see cref="Triangle"/>.
        /// </summary>
        /// <returns>Perimetr of <see cref="Triangle"/>.</returns>
        public int GetPerim()
        {
            int perim = 0;
            foreach (var s in this.sides)
            {
                perim += s.Length;
            }

            return perim;
        }

        /// <summary>
        /// Sets All Three <see cref="ColorSide"/>s of <see cref="Triangle"/>.
        /// </summary>
        /// <param name="sideA">Represent First <see cref="Triangle"/> <see cref="ColorSide"/> will be set.</param>
        /// <param name="sideB">Represent Second <see cref="Triangle"/> <see cref="ColorSide"/> will be set.</param>
        /// <param name="sideC">Represent Third <see cref="Triangle"/> <see cref="ColorSide"/> will be set.</param>
        public void SetSides(ColorSide sideA, ColorSide sideB, ColorSide sideC)
        {
            if (IsTriang(sideA, sideB, sideC) == false)
            {
                throw new ArgumentException("Transmitted sides can not make a triangle");
            }

            this.sides[0] = sideA;
            this.sides[1] = sideB;
            this.sides[2] = sideC;
        }

        /// <summary>
        /// Override <see cref="object.ToString()"/>.
        /// </summary>
        /// <returns>String adaptation of the <see cref="Triangle"/>. <seealso cref="object.ToString()"/>.</returns>
        public override string ToString()
        {
            return string.Format(
                "{0} {1} {2} {3} {4} {5}", 
                this.sides[0].Color, 
                this.sides[0].Length, 
                this.sides[1].Color, 
                this.sides[1].Length, 
                this.sides[2].Color, 
                this.sides[2].Length);
        }

        /// <summary>
        /// Checks if Three <see cref="ColorSide"/>s complete a <see cref="Triangle"/>.
        /// </summary>
        /// <param name="sideA">Represent First <see cref="Triangle"/> <see cref="ColorSide"/> will be checked.</param>
        /// <param name="sideB">Represent Second <see cref="Triangle"/> <see cref="ColorSide"/> will be checked.</param>
        /// <param name="sideC">Represent Third <see cref="Triangle"/> <see cref="ColorSide"/> will be checked.</param>
        /// <returns>True is <see cref="ColorSide"/>s complete <see cref="Triangle"/></returns>
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
    }
}
