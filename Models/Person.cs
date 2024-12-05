namespace FamilyTree.Models
{
    internal class Person
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public int IdRoleInTree { get; set; }

        public Person() { }
        public Person(string lastname, string firstname, string surname, string birthday, string gender, int idRoleInTree)
        {
            Lastname = lastname;
            Firstname = firstname;
            Surname =  surname;
            Birthday = birthday;
            Gender = gender;
            IdRoleInTree = idRoleInTree;
        }

        public string GetInfoForTree()
        {
            return $"{Lastname} {Firstname} {Surname} ({Birthday})";
        }
    }
}
