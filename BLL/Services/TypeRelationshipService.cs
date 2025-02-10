using FamilyTree.DAL.Repositories;
using FamilyTree.DAL.Models;
using Serilog;

namespace FamilyTree.BLL.Services
{
    public class TypeRelationshipService
    {
        private static TypeRelationshipRepository TypeRelationshipRepository { get; } = TypeRelationshipRepository.GetInstance();
        
        public static List<string> GetTitleRelationship()
        {
            Log.Information("Type Relationship Service: Get Title Relationship");
            var listRelationship = TypeRelationshipRepository.GetRelationships().Result;
            var listTitleRelationship = listRelationship
                .Select(r => r.Title)
                .ToList();
            return listTitleRelationship;
        }

        public static List<TypeRelationship> GetRelationships()
        {
            Log.Information("Type Relationship Service: Get Relationships");
            return TypeRelationshipRepository.GetRelationships().Result;
        }
    }
}
