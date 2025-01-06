namespace FamilyTree.BLL.DTO
{
    public class RelationshipDTO
    {
        public int IdPerson { get; set; }
        public int IdRelative { get; set; }
        public int IdTypeRelationship { get; set; }
        public int IdTree { get; set; }
        public RelationshipDTO() { }
        public RelationshipDTO(int idPerson, int idRelative, int idTypeRelationship, int idTree)
        {
            IdPerson = idPerson;
            IdRelative = idRelative;
            IdTypeRelationship = idTypeRelationship;
            IdTree = idTree;
        }
    }
}
