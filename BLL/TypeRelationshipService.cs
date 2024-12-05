using FamilyTree.DAL.Repositories;

namespace FamilyTree.BLL
{
    internal class TypeRelationshipService
    {
        private static readonly TypeRelationshipRepository _typeRelationshipRepository = TypeRelationshipRepository.GetInstance();
        public static List<string> GetTitleRelationship()
        {
            var listRelationship = _typeRelationshipRepository.GetRelationships().Result;
            var listTitleRelationship = listRelationship
                .Select(r => r.Title)
                .ToList();
            return listTitleRelationship;
        }
    }
}
