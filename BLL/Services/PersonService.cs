using FamilyTree.DAL.Repositories;
using FamilyTree.DAL.Models;
using FamilyTree.BLL.DTO;
using System.Globalization;

namespace FamilyTree.BLL.Services
{
    public class PersonService
    {
        private static readonly PersonRepository _personRepository = PersonRepository.GetInstance();
        
        // создание человека 
        public static void CreatePerson(Person person)
        {
            _personRepository.CreatePerson(person);
            var persons = GetAllPerson();
            var idPerson = persons.FirstOrDefault(p => p.Lastname == person.Lastname && p.Firstname == person.Firstname && p.Surname == person.Surname).Id;
            RoleInTreeService.CreateRoleInTree(idPerson);
        }

        // список имен всех людей
        public static List<string> GetAllNamesPerson()
        {
            var persons = _personRepository.GetPersons().Result;
            var names = persons
                .Select(person => $"{person.Lastname} {person.Firstname} {person.Surname}")
                .ToList();
            return names;
        }

        // спиок имен людей, которых нет в древе
        public static List<string> GetPersonsOutsideTree()
        {
            var idTree = TreeService.GetCurrentTree().Id;
            var persons = _personRepository.GetPersons().Result;
            var roles = RoleInTreeService.GetRoleInTree();
            var personOutsideTree = persons
                .Where(person => roles.Any(r => r.IdTree == idTree && r.IdTypeRoleInTree == 3 && r.IdPerson == person.Id))
                .Select(person => $"{person.Lastname} {person.Firstname} {person.Surname}")
                .ToList();
            return personOutsideTree;
        }

        // список имен людей, которые есть в древе
        public static List<string> GetPersonsInTree()
        {
            var idTree = TreeService.GetCurrentTree().Id;
            var persons = _personRepository.GetPersons().Result;
            var roles = RoleInTreeService.GetRoleInTree();
            var personOutsideTree = persons
                .Where(person => roles.Any(r => r.IdTree == idTree && r.IdTypeRoleInTree != 3 && r.IdPerson == person.Id))
                .Select(person => $"{person.Lastname} {person.Firstname} {person.Surname}")
                .ToList();
            return personOutsideTree;
        }

        // получение человека по ФИО
        public static Person GetPersonByFullName(string fullName)
        {
            string[] partsFullName = fullName.Split(' ');
            PersonFullNameDTO personDTO = new (partsFullName[0], partsFullName[1], partsFullName[2]); 
            var persons = _personRepository.GetPersons().Result;
            var person = persons
                .FirstOrDefault(p => p.Lastname == personDTO.Lastname && p.Firstname == personDTO.Firstname && p.Surname == personDTO.Surname);
            return person;
        }

        // получение человека по id
        public static Person GetPersonById(int id)
        {
            var persons = _personRepository.GetPersons().Result;
            var person = persons.FirstOrDefault(p => p.Id == id);
            return person;
        }

        // Возраст предка при рождении ребенка
        public static int GetAgeAncestor(string fullnameAncestor, string fullnameDescendant)
        {
            var personAncestor = GetPersonByFullName(fullnameAncestor).Birthday;
            var personDescendant = GetPersonByFullName(fullnameDescendant).Birthday;
            DateTime birthdayAncestor = DateTime.ParseExact(personAncestor, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime birthdayDescendant = DateTime.ParseExact(personDescendant, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            return (birthdayDescendant.Year - birthdayAncestor.Year);
        }
        
        // Получение корня древа
        public static Person GetRootPerson()
        {
            var currentTree = TreeService.GetCurrentTree();
            var persons = _personRepository.GetPersons().Result;
            return persons.FirstOrDefault(p => p.Id == currentTree.IdPerson);
        }

        // Список всех людей
        public static List<Person> GetAllPerson()
        {
            return _personRepository.GetPersons().Result;
        }
    }
}
