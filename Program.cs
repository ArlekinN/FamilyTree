using FamilyTree.DAL;
using FamilyTree.Presentation;

namespace FamilyTree
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Initialization.InitializationData();

            Application.Run(new MainForm());
        }
    }
}