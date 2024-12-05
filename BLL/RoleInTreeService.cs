using FamilyTree.DAL.Repositories;
using FamilyTree.Models;

namespace FamilyTree.BLL
{
    internal class RoleInTreeService
    {
        private static readonly RoleInTreeRepository _roleInTreeRepository = RoleInTreeRepository.GetInstance();

        // создание роли для человека во всех деревьях
        public static void CreateRoleInTree(int idPerson)
        {
            var idTrees = TreeService.GetIdsTree();
            foreach (var idTree in idTrees)
            {
                var newRoleInTree = new RoleInTree(idPerson, idTree.Id, 3);
                _roleInTreeRepository.CreateRoleInTree(newRoleInTree);
            }
        }

        // список ролей
        public static List<RoleInTree> GetRoleInTree()
        {
            return _roleInTreeRepository.GetRoleInTree().Result;
        }

        // изменение роли человека в древе
        public static void ChangeRolePerson(int idPerson, int idTree, int idTypeRoleInTree)
        {
            _roleInTreeRepository.ChangeRolePerson(idPerson, idTree, idTypeRoleInTree);
        }

        public static void CreateRoleRoot(string fullname)
        {
            var idTree = TreeService.GetCurrentTree().Id;
            var person = PersonService.GetPersonByFullName(fullname);
            var newRoleInTree = new RoleInTree(person.Id, idTree, 1);
            _roleInTreeRepository.CreateRoleRoot(newRoleInTree);
        }
    }
}
