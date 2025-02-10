using FamilyTree.Common;
using FamilyTree.DAL;

namespace FamilyTree
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Initialization.InitializationData();
            Logger.Initialize();
            Application.Run(new Presentation.MainForm());
        }
    }
}