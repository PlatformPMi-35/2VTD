namespace FirstTask.Library
{
    using System;
    using FirstTask.Interfaces;

    /// <summary>
    /// Represents Color Side. Implements <see cref="IColor"/>.
    /// </summary>
    public struct ColorSide : IColor
    {
        /// <summary>
        /// Color of the ColorSide.
        /// </summary>
        private Color color;

        /// <summary>
        /// Length of the ColorSide.
        /// </summary>
        private int length;

        /// <summary> 
        /// Initializes a new instance of the <see cref="ColorSide" /> struct and sets its Color.
        /// </summary>
        /// <param name="color">Color that will be set.</param>
        public ColorSide(Color color)
        {
            this.color = color;
            this.length = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorSide" /> struct and sets its Color and Length.
        /// </summary>
        /// <param name="color">Color that will be set.</param>
        /// <param name="length">Length that will be set.</param>
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

        /// <summary>
        /// Gets or sets Length of the ColorSide.
        /// </summary>
        /// <value>
        /// Gets or sets Length.
        /// </value>
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

        /// <summary>
        /// Gets or sets Color of the ColorSide.
        /// </summary>
        /// <value>Gets or sets Color.</value>
        public Color Color
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