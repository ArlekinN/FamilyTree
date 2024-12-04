namespace FamilyTree.Models
{
    internal class Person
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Genre { get; set; }
        public bool RootTree { get; set; }
        public List<int> Relatives { get; set; }

        public Person(string lastname, string firstname, string surname, string birthday, string genre)
        {
            Lastname = lastname;
            Firstname = firstname;
            Surname =  surname;
            Birthday = birthday;
            Genre = genre;
        }
    }
}
