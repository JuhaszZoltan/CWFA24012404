namespace RealEstateGUI
{
    internal static class Program
    {
        internal static string ConnectionString = 
            "Server=localhost;" +
            "Database=ingatlan;" +
            "Uid=root;";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new RealEstateForm());
        }
    }
}