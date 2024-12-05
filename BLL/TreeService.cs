using FamilyTree.DAL.Repositories;
using FamilyTree.Models;

namespace FamilyTree.BLL
{
    internal class TreeService
    {
        private static readonly TreeRepository _treeRepository = TreeRepository.GetInstance();

        // список имен людей в корнях древ
        public static List<string> GetNamesTree()
        {
            var trees = _treeRepository.GetTrees().Result;
            var persons = PersonService.GetAllPerson();
            var names = persons
                .Where(p => trees.Any(t => t.IdPerson == p.Id))
                .Select(p=> p.GetFullname())
                .ToList();
            return names;
        }

        // изменение текущего древа
        public static void ChangeCurrentTree(string fullname)
        {
            var person = PersonService.GetPersonByFullName(fullname);
            _treeRepository.ChangeCurrentTree(person.Id);
        }

        // список древ
        public static List<Tree> GetIdsTree()
        {
            return _treeRepository.GetTrees().Result;
        }
    }
}
