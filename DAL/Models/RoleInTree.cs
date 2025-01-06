namespace FamilyTree.DAL.Models
{
    public class RoleInTree : BaseIdEntity
    {
        public int IdPerson { get; set; }
        public int IdTree { get; set; }
        public int IdTypeRoleInTree { get; set; }
        public RoleInTree() { }
        public RoleInTree(int idPerson, int isTree, int idTypeRoleInTree)
        {
            IdPerson = idPerson;
            IdTree = isTree;
            IdTypeRoleInTree = idTypeRoleInTree;
        }
    }
}
