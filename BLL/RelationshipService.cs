using FamilyTree.DAL.Repositories;
using FamilyTree.Models;
using System.Globalization;

namespace FamilyTree.BLL
{
    internal class RelationshipService
    {
        private static readonly RelationshipRepository _relationshipRepository = RelationshipRepository.GetInstance();
        
        // Создание новых отношений
        public static void CreateRelationship(string fullnameNewPerson, string fullnamePersonInTree, string typeRelationship)
        {
            var newPerson = PersonService.GetPersonByFullName(fullnameNewPerson);
            var personInTree = PersonService.GetPersonByFullName(fullnamePersonInTree);
            int idTypeRelationship = TypeRelationshipService.GetRelationships().FirstOrDefault(t => t.Title == typeRelationship).Id;
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
                
                // проверка, что родитель не младше ребенка
                DateTime birthdayChild = DateTime.ParseExact(personInTree.Birthday, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime birthdayParent = DateTime.ParseExact(newPerson.Birthday, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if (birthdayChild.Year - birthdayParent.Year < 0)
                {
                    throw new Exception("Родитель не может быть младше ребенка");
                }

            }

            if (typeRelationship == "ребенок")
            {
                // проверка, что ребенок не старше родителя
                DateTime birthdayParent = DateTime.ParseExact(personInTree.Birthday, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime birthdayChild = DateTime.ParseExact(newPerson.Birthday, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if(birthdayChild.Year - birthdayParent.Year < 0)
                {
                    throw new Exception("Ребенок не может быть младше родителя");
                }

            }
            
            // создания заданной связи 
            var directRelationship = new Relationship(newPerson.Id, personInTree.Id, idTypeRelationship);
            _relationshipRepository.CreateRelationship(directRelationship);

            // создание обратной связи
            if (typeRelationship == "супруг")
            {
                var inverseRelationship = new Relationship(personInTree.Id, newPerson.Id, idTypeRelationship);
                _relationshipRepository.CreateRelationship(inverseRelationship);
                // дети существующего супруга, также становятся детьми нового супруга
                var childsRelationship = relationships
                    .Where(r => r.IdPerson == personInTree.Id && r.IdTypeRelationship == 3)
                    .ToList();
                foreach (var child in childsRelationship)
                {
                    var newRelationship = new Relationship(newPerson.Id, child.IdRelative, 3);
                    _relationshipRepository.CreateRelationship(newRelationship);
                    newRelationship = new Relationship(child.IdRelative, newPerson.Id, 2);
                    _relationshipRepository.CreateRelationship(newRelationship);
                }
            }
            else if (typeRelationship == "ребенок")
            {
                var inverseRelationship = new Relationship(personInTree.Id, newPerson.Id, 3);
                _relationshipRepository.CreateRelationship(inverseRelationship);
            }
            // родитель
            else
            {
                var inverseRelationship = new Relationship(personInTree.Id, newPerson.Id, 2);
                _relationshipRepository.CreateRelationship(inverseRelationship);
            }

            // смена root, если у текущего root появился родитель
            if(typeRelationship == "родитель")
            {
                PersonService.UpdateRoleInTree(newPerson.Id, 1);
                PersonService.UpdateRoleInTree(personInTree.Id, 2);
            }
            else
            {
                PersonService.UpdateRoleInTree(newPerson.Id, 2);
            }  
        }

        // список имен родственников человека (родители и дети)
        public static List<string> GetFamily(string fullname, string typeRelationship)
        {
            var person = PersonService.GetPersonByFullName(fullname);
            var persons = PersonService.GetAllPerson();
            var relationships = _relationshipRepository.GetRelationships().Result;
            int idTypeRelationship = TypeRelationshipService.GetRelationships().FirstOrDefault(t => t.Title == typeRelationship).Id;
            List<Relationship> relationshipPerson = null;
            relationshipPerson = relationships
                .Where(r => r.IdRelative == person.Id && r.IdTypeRelationship == idTypeRelationship)
                .ToList();
            var listFullNames = persons
                    .Where(p => relationshipPerson.Any(r => r.IdPerson == p.Id))
                    .Select(p => $"{p.Lastname} {p.Firstname} {p.Surname}")
                    .ToList();
            return listFullNames;
        }
        
        // список имен потомков человека
        public static List<string> GetDescendantPerson(string fullname)
        {
            var person = PersonService.GetPersonByFullName(fullname);
            var persons = PersonService.GetAllPerson();
            var listIdDescend = _relationshipRepository.GetListDescendant(person.Id).Result;
            var fullNamesDescant = persons
                .Where(p => listIdDescend.Any(l => l == p.Id))
                .Select(p => $"{p.Lastname} {p.Firstname} {p.Surname}")
                .ToList();
            return fullNamesDescant;
        }

        // список имен людей, у которых есть дети
        public static List<string> GetPersonWithChild()
        {
            var persons = PersonService.GetAllPerson();
            var relationships = _relationshipRepository.GetIdPersonWithChild().Result;
            var fullnames = persons
                .Where(p => relationships.Any(r => r == p.Id))
                .Select(p => $"{p.Lastname} {p.Firstname} {p.Surname}")
                .ToList();
            return fullnames;
        }

        // список всех родственных связей
        public static List<Relationship> GetRelationships()
        {
            return _relationshipRepository.GetRelationships().Result;
        }

        // удаление связей при создании нового древа
        public static void DeleteRelationship()
        {
            _relationshipRepository.DeleteRelationship();
        }
    }
}
