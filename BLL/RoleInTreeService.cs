using FamilyTree.DAL.Repositories;
using FamilyTree.DAL.Models;

namespace FamilyTree.BLL
{
    public class RoleInTreeService
    {
        private static readonly RoleInTreeRepository _roleInTreeRepository = RoleInTreeRepository.GetInstance();

        // создание роли для человека во всех деревьях
        public static void CreateRoleInTree(int idPerson)
        {
            var idTrees = TreeService.GetTrees();
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

        // Создать новый корень и заполнить для других людей, что их нет в этом древе
        public static void CreateRoleRoot(string fullname)
        {
            var idTree = TreeService.GetCurrentTree().Id;
            var person = PersonService.GetPersonByFullName(fullname);
            _roleInTreeRepository.CreateRole(new RoleInTree(person.Id, idTree, 1));
            var persons = PersonService.GetAllPerson();
            foreach (var item in persons)
            {
                if(item.Id != person.Id)
                {
                    _roleInTreeRepository.CreateRole(new RoleInTree(item.Id, idTree, 3));
                }  
            }
        }

        // удалить все роли у древа
        public static void DeleteRolesInTree(int id)
        {
            _roleInTreeRepository.DeleteRolesInTree(id);
        }
    }
}
