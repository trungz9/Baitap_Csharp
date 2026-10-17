using WinFormsApp2.bul;
using WinFormsApp2.data.DAO;
using WinFormsApp2.views;

namespace WinFormsApp2
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

            var classDataAccess = new ClassDataAccess();
            var studentDataAccess = new StudentDataAccess();
            var classBusiness = new ClassBusiness(classDataAccess);
            var studentBusiness = new StudentBusiness(studentDataAccess, classBusiness);

            Application.Run(new QLSV(studentBusiness, classBusiness));
        }
    }
}