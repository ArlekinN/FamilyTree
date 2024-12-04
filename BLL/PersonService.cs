using FamilyTree.DAL.Repositories;
using FamilyTree.Models;

namespace FamilyTree.BLL
{
    internal class PersonService
    {
        private static readonly PersonRepository _personRepository = PersonRepository.GetInstance();
        public static void CreatePerson(Person person)
        {
            _personRepository.CreatePerson(person);   
        }
    }
}
