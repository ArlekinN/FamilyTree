namespace FamilyTree.Models
{
    internal class Person
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Genre { get; set; }
        public List<int> Relatives { get; set; }
    }
}
