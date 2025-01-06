using FamilyTree.DAL.Repositories;
using FamilyTree.DAL.Models;
using FamilyTree.BLL.DTO;

namespace FamilyTree.BLL.Services
{
    public class TreeService
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

        // изменение текущее древа
        public static void ChangeCurrentTree(string fullname)
        {
            var person = PersonService.GetPersonByFullName(fullname);
            _treeRepository.ChangeCurrentTree(person.Id);
        }

        // список древ
        public static List<TreeDTO> GetTrees()
        {
            var trees =  _treeRepository.GetTrees().Result;
            return trees
               .Select(p => new TreeDTO
               {
                   IdPerson = p.IdPerson,
                   CurrentTree = p.CurrentTree
               })
               .ToList();
        }

        // список древ c id
        public static List<Tree> GetTreesWithID()
        {
            return _treeRepository.GetTrees().Result;
        }

        // получени текущего древа
        public static Tree GetCurrentTree()
        {
            var trees = _treeRepository.GetTrees().Result;
            var currnetIdTree = trees.FirstOrDefault(t => t.CurrentTree == true);
            return currnetIdTree;
        }

        // изменение корня текущего древа
        public static void ChangeRootCurrentTree(int id)
        {
            _treeRepository.ChangeRootCurrentTree(id);
        }

        // создание нового древа
        public static void CreateTree(string fullname)
        {
            var person = PersonService.GetPersonByFullName(fullname);
            _treeRepository.CreateTree(person.Id);
            ChangeCurrentTree(fullname);
        }

        // удалить древо
        public static void DeleteTree(int id)
        {
            _treeRepository.DeleteTree(id);
        }
    }
}
