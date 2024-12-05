using FamilyTree.DAL.Repositories;
using FamilyTree.Models;

namespace FamilyTree.BLL
{
    internal class TypeRoleInTreeService
    {
        private static readonly TypeRoleInTreeRepository _typeRoleInTreeRepository = TypeRoleInTreeRepository.GetInstance();

        // список всех ролей в древе
        public static List<TypeRoleInTree> GetRoleInTree()
        {
            return _typeRoleInTreeRepository.GetRoleInTree().Result;
        }
    }
}
