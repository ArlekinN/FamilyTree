using FamilyTree.DAL.Repositories;
using FamilyTree.DAL.Models;
using FamilyTree.BLL.DTO;
using System.Globalization;
using Serilog;

namespace FamilyTree.BLL.Services
{
    public class RelationshipService
    {
        private static RelationshipRepository RelationshipRepository { get; } = RelationshipRepository.GetInstance();
        
        public static void CreateRelationship(string fullnameNewPerson, string fullnamePersonInTree, string typeRelationship)
        {
            Log.Information("Relationship Service: Create Relationship");
            var idTree = TreeService.GetCurrentTree().Id;
            var newPerson = PersonService.GetPersonByFullName(fullnameNewPerson);
            var personInTree = PersonService.GetPersonByFullName(fullnamePersonInTree);
            var idTypeRelationship = TypeRelationshipService.GetRelationships().FirstOrDefault(t => t.Title == typeRelationship).Id;
            Log.Debug("Checking that spouses are of the same sex");
            if(newPerson.Gender == personInTree.Gender && typeRelationship == RolePeople.Spouse)
            {
                throw new Exception("Spouses cannot be of the same sex");
            }
            
            var relationships = RelationshipRepository.GetRelationships().Result;
            if (typeRelationship == RolePeople.Spouse)
            {
                Log.Debug("Check that there is already a spouse");
                var relationship1 = relationships
                        .Where(r => r.IdPerson == personInTree.Id && r.IdTypeRelationship == idTypeRelationship && r.IdTree == idTree)
                        .ToList();
                if (relationship1.Count != 0)
                {
                    throw new Exception("This person already has a spouse");
                }
            }
            
            if(typeRelationship == RolePeople.Parent)
            {
                Log.Debug("Check that there is already a mother");
                if (newPerson.Gender == RolePeople.Woman)
                {
                    var relationship2 = relationships
                    .Where(r => r.IdRelative == personInTree.Id && r.IdTypeRelationship == idTypeRelationship && r.IdTree == idTree)
                    .ToList();
                    foreach (var item in relationship2)
                    {
                        var parentPerson = PersonService.GetPersonById(item.IdPerson);
                        if (parentPerson.Gender == RolePeople.Woman)
                        {
                            throw new Exception("This man already has a mother");
                        }
                    }
                }

                Log.Debug("Check that there is already a father");
                if (newPerson.Gender == RolePeople.Man)
                {
                    var relationship2 = relationships
                    .Where(r => r.IdRelative == personInTree.Id && r.IdTypeRelationship == idTypeRelationship && r.IdTree == idTree)
                    .ToList();
                    foreach (var item in relationship2)
                    {
                        var parentPerson = PersonService.GetPersonById(item.IdPerson);
                        if (parentPerson.Gender == RolePeople.Man)
                        {
                            throw new Exception("This man already has a father");
                        }
                    }
                }

                Log.Debug("Check that the parent is not younger than the child");
                var birthdayChild = DateTime.ParseExact(personInTree.Birthday, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var birthdayParent = DateTime.ParseExact(newPerson.Birthday, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if (birthdayChild.Year - birthdayParent.Year < 0)
                {
                    throw new Exception("The parent cannot be younger than the child");
                }

            }

            if (typeRelationship == RolePeople.Child)
            {
                Log.Debug("Check that the child is not older than the parent");
                var birthdayParent = DateTime.ParseExact(personInTree.Birthday, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var birthdayChild = DateTime.ParseExact(newPerson.Birthday, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if(birthdayChild.Year - birthdayParent.Year < 0)
                {
                    throw new Exception("The child cannot be younger than the parent");
                }
            }

            Log.Debug("Create a given connection");
            var directRelationship = new Relationship(newPerson.Id, personInTree.Id, idTypeRelationship, idTree);
            RelationshipRepository.CreateRelationship(directRelationship);

            Log.Debug("Create a reverse connection");
            if (typeRelationship == RolePeople.Spouse)
            {
                var inverseRelationship = new Relationship(personInTree.Id, newPerson.Id, idTypeRelationship, idTree);
                RelationshipRepository.CreateRelationship(inverseRelationship);
                Log.Debug("the children of the existing spouse also become the children of the new spouse");
                var childsRelationship = relationships
                    .Where(r => r.IdPerson == personInTree.Id && r.IdTypeRelationship == 3)
                    .ToList();
                foreach (var child in childsRelationship)
                {
                    var newRelationship = new Relationship(newPerson.Id, child.IdRelative, 3, idTree);
                    RelationshipRepository.CreateRelationship(newRelationship);
                    newRelationship = new Relationship(child.IdRelative, newPerson.Id, 2, idTree);
                    RelationshipRepository.CreateRelationship(newRelationship);
                }
            }

            else if (typeRelationship == RolePeople.Child)
            {
                var inverseRelationship = new Relationship(personInTree.Id, newPerson.Id, 3, idTree);
                RelationshipRepository.CreateRelationship(inverseRelationship);
                Log.Debug("Create a bond for the spouse");
                var spouse = relationships.FirstOrDefault(r => r.IdPerson == personInTree.Id && r.IdTree == idTree && r.IdTypeRelationship == 1 );
                if (spouse is not null)
                {
                    var newRelationship = new Relationship(spouse.IdRelative, newPerson.Id, 3, idTree);
                    RelationshipRepository.CreateRelationship(newRelationship);
                    newRelationship = new Relationship(newPerson.Id, spouse.IdRelative, 2, idTree);
                    RelationshipRepository.CreateRelationship(newRelationship);
                }
            }
            else
            {
                var inverseRelationship = new Relationship(personInTree.Id, newPerson.Id, 2, idTree);
                RelationshipRepository.CreateRelationship(inverseRelationship);
            }
            if(typeRelationship == RolePeople.Parent)
            {
                TreeService.ChangeRootCurrentTree(newPerson.Id);
                RoleInTreeService.ChangeRolePerson(newPerson.Id, idTree, 1);
                RoleInTreeService.ChangeRolePerson(personInTree.Id, idTree, 2);
            }
            else
            {
                RoleInTreeService.ChangeRolePerson(newPerson.Id, idTree, 2);
            }  
        }

        public static List<string> GetFamily(string fullname, string typeRelationship)
        {
            Log.Information("Relationship Service: Get Family");
            var idTree = TreeService.GetCurrentTree().Id;
            var person = PersonService.GetPersonByFullName(fullname);
            var persons = PersonService.GetAllPerson();
            var relationships = RelationshipRepository.GetRelationships().Result;
            var idTypeRelationship = TypeRelationshipService.GetRelationships().FirstOrDefault(t => t.Title == typeRelationship).Id;
            var relationshipPerson = relationships
                .Where(r => r.IdRelative == person.Id && r.IdTypeRelationship == idTypeRelationship && r.IdTree == idTree)
                .ToList();
            var listFullNames = persons
                    .Where(p => relationshipPerson.Any(r => r.IdPerson == p.Id))
                    .Select(p => $"{p.Lastname} {p.Firstname} {p.Surname}")
                    .ToList();
            return listFullNames;
        }
        
        public static List<string> GetDescendantPerson(string fullname)
        {
            Log.Information("Relationship Service: Get Descendant Person");
            var idTree = TreeService.GetCurrentTree().Id;
            var person = PersonService.GetPersonByFullName(fullname);
            var persons = PersonService.GetAllPerson();
            var listIdDescend = RelationshipRepository.GetListDescendant(person.Id, idTree).Result;
            var fullNamesDescant = persons
                .Where(p => listIdDescend.Any(l => l == p.Id))
                .Select(p => $"{p.Lastname} {p.Firstname} {p.Surname}")
                .ToList();
            return fullNamesDescant;
        }

        public static List<string> GetPersonWithChild()
        {
            Log.Information("Relationship Service: Get Person With Child");
            var idTree = TreeService.GetCurrentTree().Id;
            var persons = PersonService.GetAllPerson();
            var relationships = RelationshipRepository.GetIdPersonWithChild(idTree).Result;
            var fullnames = persons
                .Where(p => relationships.Any(r => r == p.Id))
                .Select(p => $"{p.Lastname} {p.Firstname} {p.Surname}")
                .ToList();
            return fullnames;
        }

        public static List<RelationshipDTO> GetRelationships()
        {
            Log.Information("Relationship Service: Get Relationships");
            var relationships = RelationshipRepository.GetRelationships().Result;
            return relationships
                .Select(p => new RelationshipDTO
                {
                    IdPerson = p.IdPerson,
                    IdRelative = p.IdRelative,
                    IdTypeRelationship = p.IdTypeRelationship,
                    IdTree = p.IdTree
                })
                .ToList();
        }

        public static void DeleteRelationship(int id)
        {
            Log.Information("Relationship Service: Delete Relationship");
            RelationshipRepository.DeleteRelationship(id);
        }

        public static List<int> GetAncestors(string fullname)
        {
            Log.Information("Relationship Service: Get Ancestors");
            var person = PersonService.GetPersonByFullName(fullname);
            var idTree = TreeService.GetCurrentTree().Id;
            return RelationshipRepository.GetListAncestors(person.Id, idTree).Result;
        }

        public static string GetFullNameSpouse(string fullname)
        {
            Log.Information("Relationship Service: Get Full Name Spouse");
            var person = PersonService.GetPersonByFullName(fullname);
            var persons = PersonService.GetAllPerson();
            var idTree = TreeService.GetCurrentTree().Id;
            var relationships = RelationshipRepository.GetRelationships().Result;
            var relationshipSpouse = relationships.FirstOrDefault(r => r.IdPerson== person.Id && r.IdTree == idTree && r.IdTypeRelationship == 1);
            if(relationshipSpouse is not null)
            {
                var nameSpouse = persons.FirstOrDefault(p => p.Id == relationshipSpouse.IdRelative).GetFullname();
                return nameSpouse;
            }
            return "";  
        }
    }
}
