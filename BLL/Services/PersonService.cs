using FamilyTree.DAL.Repositories;
using FamilyTree.DAL.Models;
using FamilyTree.BLL.DTO;
using System.Globalization;
using Serilog;

namespace FamilyTree.BLL.Services
{
    public class PersonService
    {
        private static PersonRepository PersonRepository { get; } = PersonRepository.GetInstance();
        
        public static void CreatePerson(Person person)
        {
            Log.Information("Person Service: Create Person");
            PersonRepository.CreatePerson(person);
            var persons = GetAllPerson();
            var idPerson = persons.FirstOrDefault(p => p.Lastname == person.Lastname && p.Firstname == person.Firstname && p.Surname == person.Surname).Id;
            RoleInTreeService.CreateRoleInTree(idPerson);
        }

        public static List<string> GetAllNamesPerson()
        {
            Log.Information("Person Service: Get All Names Person");
            var persons = PersonRepository.GetPersons().Result;
            var names = persons
                .Select(person => $"{person.Lastname} {person.Firstname} {person.Surname}")
                .ToList();
            return names;
        }

        public static List<string> GetPersonsOutsideTree()
        {
            Log.Information("Person Service: Get Persons Outside Tree");
            var idTree = TreeService.GetCurrentTree().Id;
            var persons = PersonRepository.GetPersons().Result;
            var roles = RoleInTreeService.GetRoleInTree();
            var personOutsideTree = persons
                .Where(person => roles.Any(r => r.IdTree == idTree && r.IdTypeRoleInTree == 3 && r.IdPerson == person.Id))
                .Select(person => $"{person.Lastname} {person.Firstname} {person.Surname}")
                .ToList();
            return personOutsideTree;
        }

        public static List<string> GetPersonsInTree()
        {
            Log.Information("Person Service: Get Persons In Tree");
            var idTree = TreeService.GetCurrentTree().Id;
            var persons = PersonRepository.GetPersons().Result;
            var roles = RoleInTreeService.GetRoleInTree();
            var personOutsideTree = persons
                .Where(person => roles.Any(r => r.IdTree == idTree && r.IdTypeRoleInTree != 3 && r.IdPerson == person.Id))
                .Select(person => $"{person.Lastname} {person.Firstname} {person.Surname}")
                .ToList();
            return personOutsideTree;
        }

        public static Person GetPersonByFullName(string fullName)
        {
            Log.Information("Person Service: Get Person By Full Name");
            var partsFullName = fullName.Split(' ');
            PersonFullNameDTO personDTO = new (partsFullName[0], partsFullName[1], partsFullName[2]); 
            var persons = PersonRepository.GetPersons().Result;
            var person = persons
                .FirstOrDefault(p => p.Lastname == personDTO.Lastname && p.Firstname == personDTO.Firstname && p.Surname == personDTO.Surname);
            return person;
        }

        public static Person GetPersonById(int id)
        {
            Log.Information("Person Service: Get Person By Id");
            var persons = PersonRepository.GetPersons().Result;
            var person = persons.FirstOrDefault(p => p.Id == id);
            return person;
        }

        public static int GetAgeAncestor(string fullnameAncestor, string fullnameDescendant)
        {
            Log.Information("Person Service: Get Age Ancestor");
            var personAncestor = GetPersonByFullName(fullnameAncestor).Birthday;
            var personDescendant = GetPersonByFullName(fullnameDescendant).Birthday;
            var birthdayAncestor = DateTime.ParseExact(personAncestor, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var birthdayDescendant = DateTime.ParseExact(personDescendant, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            return (birthdayDescendant.Year - birthdayAncestor.Year);
        }
        
        public static Person GetRootPerson()
        {
            Log.Information("Person Service: Get Root Person");
            var currentTree = TreeService.GetCurrentTree();
            var persons = PersonRepository.GetPersons().Result;
            return persons.FirstOrDefault(p => p.Id == currentTree.IdPerson);
        }

        public static List<Person> GetAllPerson()
        {
            Log.Information("Person Service: Get All Person");
            return PersonRepository.GetPersons().Result;
        }
    }
}
