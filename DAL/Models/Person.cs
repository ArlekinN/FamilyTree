namespace FamilyTree.DAL.Models
{
    public class Person : BaseIdEntity
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }

        public Person() { }
        public Person(string lastname, string firstname, string surname, string birthday, string gender, int idRoleInTree)
        {
            Lastname = lastname;
            Firstname = firstname;
            Surname =  surname;
            Birthday = birthday;
            Gender = gender;
        }

        public string GetInfoForTree()
        {
            return $"{Lastname} {Firstname} {Surname} ({Birthday})";
        }

        public string GetFullname()
        {
            return $"{Lastname} {Firstname} {Surname}";
        }
    }
}
