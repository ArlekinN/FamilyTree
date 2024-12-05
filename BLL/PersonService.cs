using FamilyTree.DAL.Repositories;
using FamilyTree.Models;

namespace FamilyTree.BLL
{
    internal class PersonService
    {
        private static readonly PersonRepository _personRepository = PersonRepository.GetInstance();
        private static readonly RoleInTreeRepository _roleInTreeRepository = RoleInTreeRepository.GetInstance();
        public static void CreatePerson(Person person)
        {
            _personRepository.CreatePerson(person);   
        }
        public static List<string> GetAllPerson()
        {
            var persons = _personRepository.GetPersons().Result;
            var names = persons
                .Select(person => $"{person.Lastname} {person.Firstname} {person.Surname}")
                .ToList();
            return names;
        }

        public static List<string> GetPersonsOutsideTree()
        {
            var persons = _personRepository.GetPersons().Result;
            var rolesInTree = _roleInTreeRepository.GetRoleInTree().Result;
            var personOutsideTree = persons
                .Where(person => rolesInTree.Any(role => role.Id == person.IdRoleInTree && role.Title == "Отсутствует"))
                .ToList();
            var names = personOutsideTree
                .Select(person => $"{person.Lastname} {person.Firstname} {person.Surname}")
                .ToList();
            return names;
        }
        public static List<string> GetPersonsInTree()
        {
            var persons = _personRepository.GetPersons().Result;
            var rolesInTree = _roleInTreeRepository.GetRoleInTree().Result;
            var personOutsideTree = persons
                .Where(person => rolesInTree.Any(role => role.Id == person.IdRoleInTree && role.Title != "Отсутствует"))
                .ToList();
            var names = personOutsideTree
                .Select(person => $"{person.Lastname} {person.Firstname} {person.Surname}")
                .ToList();
            return names;
        }
        public static Person GetPersonByFullName(string fullName)
        {
            string[] partsFullName = fullName.Split(' ');
            var lastName = partsFullName[0];
            var firstName = partsFullName[1];
            var surname = partsFullName[2];
            var persons = _personRepository.GetPersons().Result;
            var person = persons
                .FirstOrDefault(p => p.Lastname == lastName && p.Firstname == firstName && p.Surname == surname);
            return person;
        }

        public static Person GetPersonById(int id)
        {
            var persons = _personRepository.GetPersons().Result;
            var person = persons.FirstOrDefault(p => p.Id == id);
            return person;
        }

        public static void CreateNewTree(string fullnameNewRoot)
        {
            _personRepository.ClearTree();
            var person = GetPersonByFullName(fullnameNewRoot);
            _personRepository.CreateNewRoot(person.Id);
        }
        
    }
}
