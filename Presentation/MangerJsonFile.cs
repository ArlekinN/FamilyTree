using Newtonsoft.Json;

namespace FamilyTree.Presentation
{
    internal static class ManagerJsonFiles
    {
        public static T GetData<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
