using FamilyTree.DAL.Repositories;
using FamilyTree.DAL.Models;
using FamilyTree.BLL.DTO;
using Serilog;

namespace FamilyTree.BLL.Services
{
    public class RoleInTreeService
    {
        private static RoleInTreeRepository RoleInTreeRepository { get; } = RoleInTreeRepository.GetInstance();

        public static void CreateRoleInTree(int idPerson)
        {
            Log.Information("Role In Tree Relationship Service: Create Role In Tree");
            var idTrees = TreeService.GetTreesWithID();
            foreach (var idTree in idTrees)
            {
                var newRoleInTree = new RoleInTree(idPerson, idTree.Id, 3);
                RoleInTreeRepository.CreateRoleInTree(newRoleInTree);
            }
        }

        public static List<RoleInTreeDTO> GetRoleInTree()
        {
            Log.Information("Role In Tree Relationship Service: Get Role In Tree");
            var roles =  RoleInTreeRepository.GetRoleInTree().Result;
            return roles
               .Select(p => new RoleInTreeDTO
               {
                   IdPerson = p.IdPerson,
                   IdTree = p.IdTree,
                   IdTypeRoleInTree = p.IdTypeRoleInTree
               })
               .ToList();
        }

        public static void ChangeRolePerson(int idPerson, int idTree, int idTypeRoleInTree)
        {
            Log.Information("Role In Tree Relationship Service: Change Role Person");
            RoleInTreeRepository.ChangeRolePerson(idPerson, idTree, idTypeRoleInTree);
        }

        public static void CreateRoleRoot(string fullname)
        {
            Log.Information("Role In Tree Relationship Service: Create Role Root");
            var idTree = TreeService.GetCurrentTree().Id;
            var person = PersonService.GetPersonByFullName(fullname);
            RoleInTreeRepository.CreateRole(new RoleInTree(person.Id, idTree, 1));
            var persons = PersonService.GetAllPerson();
            foreach (var item in persons)
            {
                if(item.Id != person.Id)
                {
                    RoleInTreeRepository.CreateRole(new RoleInTree(item.Id, idTree, 3));
                }  
            }
        }

        public static void DeleteRolesInTree(int id)
        {
            Log.Information("Role In Tree Relationship Service: Delete Roles In Tree");
            RoleInTreeRepository.DeleteRolesInTree(id);
        }
    }
}
