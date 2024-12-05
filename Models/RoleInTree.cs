namespace FamilyTree.Models
{
    internal class RoleInTree
    {
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public int IdTree { get; set; }
        public int IdTypeRoleInTree { get; set; }
        public RoleInTree(int idPerson, int isTree, int idTypeRoleInTree)
        {
            IdPerson = idPerson;
            IdTree = isTree;
            IdTypeRoleInTree = idTypeRoleInTree;
        }
    }
}
