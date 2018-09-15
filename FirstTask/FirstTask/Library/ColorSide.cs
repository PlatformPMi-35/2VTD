namespace FirstTask.Library
{
    using System;
    using FirstTask.Interfaces;

    internal struct ColorSide : IColor
    {
        private Color color;

        private int length;

        public ColorSide(Color color)
        {
            this.color = color;
            this.length = 1;
        }

        public ColorSide(Color color, int length)
        {
            this.color = color;
            if (length > 0)
            {
                this.length = length;
            }
            else
            {
                this.length = 1;
            }
        }

        public int Length
        {
            get
            {
                return this.length;
            }

            set
            {
                if (value > 0)
                {
                    this.length = value;
                }
                else
                {
                    throw new ArgumentException("Transmitted value was less than or equal to zero", this.Length.GetType().FullName);
                }
            }
        }

        Color IColor.Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }
    }
}
