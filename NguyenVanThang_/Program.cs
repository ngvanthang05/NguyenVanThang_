namespace NguyenVanThang
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // S?A ? ?ÂY: Thêm ch? "Admin" (ho?c tên b?t k?) vào trong ngo?c
            Application.Run(new MenuForm("Admin"));
        }
    }
}