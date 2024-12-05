using FamilyTree.DAL.Repositories;
using FamilyTree.Models;

namespace FamilyTree.BLL
{
    internal class RelationshipService
    {
        private static readonly RelationshipRepository _relationshipRepository = RelationshipRepository.GetInstance();
        private static readonly TypeRelationshipRepository _typeRelationshipRepository = TypeRelationshipRepository.GetInstance();
        private static readonly PersonRepository _personRepository = PersonRepository.GetInstance();
        public static void CreateRelationship(string fullnameNewPerson, string fullnamePersonInTree, string typeRelationship)
        {
            var newPerson = PersonService.GetPersonByFullName(fullnameNewPerson);
            var personInTree = PersonService.GetPersonByFullName(fullnamePersonInTree);
            int idTypeRelationship = _typeRelationshipRepository.GetRelationships().Result.FirstOrDefault(t => t.Title == typeRelationship).Id;
            // проверка, что супруги одного пола
            if(newPerson.Gender == personInTree.Gender && typeRelationship == "супруг")
            {
                throw new Exception("Супруги не могут быть одного пола");
            }
            var relationships = _relationshipRepository.GetRelationships().Result;
            if (typeRelationship == "супруг")
            {
                // проверка, что супруг уже есть
                var relationship1 = relationships
                        .Where(r => r.IdPerson == personInTree.Id && r.IdTypeRelationship == idTypeRelationship)
                        .ToList();
                if (relationship1.Count != 0)
                {
                    throw new Exception("У этого человека уже есть супруг");
                }
            }
            if(typeRelationship == "родитель")
            {
                // проверка, что мать уже есть
                if (newPerson.Gender == "Женщина")
                {
                    var relationship2 = relationships
                    .Where(r => r.IdRelative == personInTree.Id && r.IdTypeRelationship == idTypeRelationship)
                    .ToList();
                    foreach (var item in relationship2)
                    {
                        var parentPerson = PersonService.GetPersonById(item.IdPerson);
                        if (parentPerson.Gender == "Женщина")
                        {
                            throw new Exception("У этого человека уже есть мать");
                        }
                    }
                }
                // проверка, что отец уже есть
                if (newPerson.Gender == "Мужчина")
                {
                    var relationship2 = relationships
                    .Where(r => r.IdRelative == personInTree.Id && r.IdTypeRelationship == idTypeRelationship)
                    .ToList();
                    foreach (var item in relationship2)
                    {
                        var parentPerson = PersonService.GetPersonById(item.IdPerson);
                        if (parentPerson.Gender == "Мужчина")
                        {
                            throw new Exception("У этого человека уже есть отец");
                        }
                    }
                }
            }
            // создания заданной связи 
            var directRelationship = new Relationship(newPerson.Id, personInTree.Id, idTypeRelationship);
            _relationshipRepository.CreateRelationship(directRelationship);
            // создание обратной связи
            if (idTypeRelationship == 1)
            {
                var inverseRelationship = new Relationship(personInTree.Id, newPerson.Id, idTypeRelationship);
                _relationshipRepository.CreateRelationship(inverseRelationship);
            }
            else if (idTypeRelationship == 2)
            {
                var inverseRelationship = new Relationship(personInTree.Id, newPerson.Id, 3);
                _relationshipRepository.CreateRelationship(inverseRelationship);
            }
            else
            {
                var inverseRelationship = new Relationship(personInTree.Id, newPerson.Id, 2);
                _relationshipRepository.CreateRelationship(inverseRelationship);
            }
            _personRepository.UpdateRoleInTree(newPerson.Id, 2);
        }

        public static List<string> GetFamily(string fullname, string typeRelationship)
        {
            var person = PersonService.GetPersonByFullName(fullname);
            var persons = _personRepository.GetPersons().Result;
            var relationships = _relationshipRepository.GetRelationships().Result;
            int idTypeRelationship = _typeRelationshipRepository.GetRelationships().Result.FirstOrDefault(t => t.Title == typeRelationship).Id;
            List<Relationship> relationshipPerson = null;
            if (typeRelationship == "родитель")
            {
                relationshipPerson = relationships
                .Where(r => r.IdRelative == person.Id && r.IdTypeRelationship == idTypeRelationship)
                .ToList();            
            }
            else 
            {
                relationshipPerson = relationships
                .Where(r => r.IdRelative == person.Id && r.IdTypeRelationship == idTypeRelationship)
                .ToList();
            }
            var listFullNames = persons
                    .Where(p => relationshipPerson.Any(r => r.IdPerson == p.Id))
                    .Select(p => $"{p.Lastname} {p.Firstname} {p.Surname}")
                    .ToList();
            return listFullNames;
        }
    }
}
