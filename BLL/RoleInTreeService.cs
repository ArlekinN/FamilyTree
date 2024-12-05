using FamilyTree.DAL.Repositories;
using FamilyTree.Models;

namespace FamilyTree.BLL
{
    internal class RoleInTreeService
    {
        private static readonly RoleInTreeRepository _roleInTreeRepository = RoleInTreeRepository.GetInstance();

        public static void CreateRoleInTree(int idPerson)
        {
            var idTrees = TreeService.GetIdsTree();
            foreach (var idTree in idTrees)
            {
                var newRoleInTree = new RoleInTree(idPerson, idTree.Id, 3);
                _roleInTreeRepository.CreateRoleInTree(newRoleInTree);
            }
        }
    }
}
