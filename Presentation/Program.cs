using FamilyTree.DAL;

namespace FamilyTree
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Initialization.InitializationData();

            Application.Run(new Presentation.MainForm());
        }
    }
}