using FamilyTree.DAL.Repositories;
using FamilyTree.Models;
using System.Globalization;

namespace FamilyTree.BLL
{
    internal class PersonService
    {
        private static readonly PersonRepository _personRepository = PersonRepository.GetInstance();
        
        // создание человека 
        public static void CreatePerson(Person person)
        {
            _personRepository.CreatePerson(person);   
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
            var persons = _personRepository.GetPersons().Result;
            var rolesInTree = RoleInTreeService.GetRoleInTree();
            var personOutsideTree = persons
                .Where(person => rolesInTree.Any(role => role.Id == person.IdRoleInTree && role.Title == "Отсутствует"))
                .ToList();
            var names = personOutsideTree
                .Select(person => $"{person.Lastname} {person.Firstname} {person.Surname}")
                .ToList();
            return names;
        }

        // список имен людей, которые есть в древе
        public static List<string> GetPersonsInTree()
        {
            var persons = _personRepository.GetPersons().Result;
            var rolesInTree = RoleInTreeService.GetRoleInTree();
            var personOutsideTree = persons
                .Where(person => rolesInTree.Any(role => role.Id == person.IdRoleInTree && role.Title != "Отсутствует"))
                .ToList();
            var names = personOutsideTree
                .Select(person => $"{person.Lastname} {person.Firstname} {person.Surname}")
                .ToList();
            return names;
        }

        // получение человека по ФИО
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

        // Создание нового древа
        public static void CreateNewTree(string fullnameNewRoot)
        {
            _personRepository.ClearTree();
            var person = GetPersonByFullName(fullnameNewRoot);
            _personRepository.CreateNewRoot(person.Id);
        }
        
        // Получение корня древа
        public static Person GetRootPerson()
        {
            var persons = _personRepository.GetPersons().Result;
            return persons.FirstOrDefault(p => p.IdRoleInTree == 1);
        }

        // Список всех людей
        public static List<Person> GetAllPerson()
        {
            return _personRepository.GetPersons().Result;
        }

        // обновление роли в дереве у человека
        public static void UpdateRoleInTree(int id, int idRoleInTree)
        {
            _personRepository.UpdateRoleInTree(id, idRoleInTree);
        }
    }
}
