namespace FamilyTree.Models
{
    internal class Relationship
    {
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public int IdRelative { get; set; }
        public int IdTypeRelationship { get; set; }
        public Relationship() { }
        public Relationship(int idPerson, int idRelative, int idTypeRelationship) 
        {
            IdPerson = idPerson;
            IdRelative = idRelative;
            IdTypeRelationship = idTypeRelationship;
        }
    }
}
