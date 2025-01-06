namespace FamilyTree.BLL.DTO
{
    public class RoleInTreeDTO
    {
        public int IdPerson { get; set; }
        public int IdTree { get; set; }
        public int IdTypeRoleInTree { get; set; }
        public RoleInTreeDTO() { }
        public RoleInTreeDTO(int idPerson, int isTree, int idTypeRoleInTree)
        {
            IdPerson = idPerson;
            IdTree = isTree;
            IdTypeRoleInTree = idTypeRoleInTree;
        }
    }
}
