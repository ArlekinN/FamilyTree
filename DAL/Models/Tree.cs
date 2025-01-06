namespace FamilyTree.DAL.Models
{
    public class Tree : BaseIdEntity
    {
        public int IdPerson { get; set; }
        public bool CurrentTree { get; set; }
        public Tree() { }
    }
}
