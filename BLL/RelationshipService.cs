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
            int IdTypeRelationship = _typeRelationshipRepository.GetRelationships().Result.FirstOrDefault(t => t.Title == typeRelationship).Id;
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
                        .Where(r => r.IdPerson == personInTree.Id && r.IdTypeRelationship == IdTypeRelationship)
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
                    .Where(r => r.IdRelative == personInTree.Id && r.IdTypeRelationship == IdTypeRelationship)
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
                    .Where(r => r.IdRelative == personInTree.Id && r.IdTypeRelationship == IdTypeRelationship)
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
            var directRelationship = new Relationship(newPerson.Id, personInTree.Id, IdTypeRelationship);
            _relationshipRepository.CreateRelationship(directRelationship);
            // создание обратной связи
            if (IdTypeRelationship == 1)
            {
                var inverseRelationship = new Relationship(personInTree.Id, newPerson.Id, IdTypeRelationship);
                _relationshipRepository.CreateRelationship(inverseRelationship);
            }
            else if (IdTypeRelationship == 2)
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
    }
}
