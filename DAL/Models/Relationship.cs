namespace FamilyTree.Models
{
    public class Relationship
    {
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public int IdRelative { get; set; }
        public int IdTypeRelationship { get; set; }
        public int IdTree { get; set; }
        public Relationship() { }
        public Relationship(int idPerson, int idRelative, int idTypeRelationship, int idTree) 
        {
            IdPerson = idPerson;
            IdRelative = idRelative;
            IdTypeRelationship = idTypeRelationship;
            IdTree = idTree;
        }
    }
}
