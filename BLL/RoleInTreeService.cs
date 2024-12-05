using FamilyTree.DAL.Repositories;
using FamilyTree.Models;

namespace FamilyTree.BLL
{
    internal class RoleInTreeService
    {
        private static readonly RoleInTreeRepository _roleInTreeRepository = RoleInTreeRepository.GetInstance();

        // список всех ролей в древе
        public static List<RoleInTree> GetRoleInTree()
        {
            return _roleInTreeRepository.GetRoleInTree().Result;
        }
    }
}
