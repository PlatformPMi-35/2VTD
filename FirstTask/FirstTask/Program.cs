namespace FirstTask
{
    using System;
    using FirstTask.Library;

    /// <summary>
    /// Our Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Runs our Program.
        /// </summary>
        /// <param name="args">Arguments for methos.</param>
        public static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Run();
        }
    }
}
