using System.Runtime.CompilerServices;

namespace FamilyTree.Common
{
    internal static class RootDirectory
    {
        public static string GetPath([CallerFilePath] string callerFilePath = "")
        {
            return Directory.GetParent(Path.GetDirectoryName(callerFilePath)).FullName;
        }
    }
}
