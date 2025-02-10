using FamilyTree.DAL.Repositories;
using FamilyTree.DAL.Models;
using FamilyTree.BLL.DTO;
using Serilog;

namespace FamilyTree.BLL.Services
{
    public class TreeService
    {
        private static TreeRepository TreeRepository { get; } = TreeRepository.GetInstance();

        public static List<string> GetNamesTree()
        {
            Log.Information("Tree Relationship Service: Get Names Tree");
            var trees = TreeRepository.GetTrees().Result;
            var persons = PersonService.GetAllPerson();
            var names = persons
                .Where(p => trees.Any(t => t.IdPerson == p.Id))
                .Select(p=> p.GetFullname())
                .ToList();
            return names;
        }

        public static void ChangeCurrentTree(string fullname)
        {
            Log.Information("Tree Relationship Service: Change Current Tree");
            var person = PersonService.GetPersonByFullName(fullname);
            TreeRepository.ChangeCurrentTree(person.Id);
        }

        public static List<TreeDTO> GetTrees()
        {
            Log.Information("Tree Relationship Service:  Get Trees");
            var trees =  TreeRepository.GetTrees().Result;
            return trees
               .Select(p => new TreeDTO
               {
                   IdPerson = p.IdPerson,
                   CurrentTree = p.CurrentTree
               })
               .ToList();
        }

        public static List<Tree> GetTreesWithID()
        {
            Log.Information("Tree Relationship Service: Get Trees With ID");
            return TreeRepository.GetTrees().Result;
        }

        public static Tree GetCurrentTree()
        {
            Log.Information("Tree Relationship Service: Get Current Tree");
            var trees = TreeRepository.GetTrees().Result;
            var currnetIdTree = trees.FirstOrDefault(t => t.CurrentTree == true);
            return currnetIdTree;
        }

        public static void ChangeRootCurrentTree(int id)
        {
            Log.Information("Tree Relationship Service: Change Root Current Tree");
            TreeRepository.ChangeRootCurrentTree(id);
        }

        public static void CreateTree(string fullname)
        {
            Log.Information("Tree Relationship Service:  Create Tree");
            var person = PersonService.GetPersonByFullName(fullname);
            TreeRepository.CreateTree(person.Id);
            ChangeCurrentTree(fullname);
        }

        public static void DeleteTree(int id)
        {
            Log.Information("Tree Relationship Service:  Delete Tree");
            TreeRepository.DeleteTree(id);
        }
    }
}
