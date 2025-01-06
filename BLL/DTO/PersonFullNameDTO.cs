namespace FamilyTree.BLL.DTO
{
    public class PersonFullNameDTO
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public PersonFullNameDTO(string lastname, string firstname, string surname)
        {
            Lastname = lastname;
            Firstname = firstname;
            Surname = surname;
        }
    }
}
