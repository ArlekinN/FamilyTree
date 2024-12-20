﻿using FamilyTree.DAL.Repositories;
using FamilyTree.Models;

namespace FamilyTree.BLL
{
    internal class TypeRelationshipService
    {
        private static readonly TypeRelationshipRepository _typeRelationshipRepository = TypeRelationshipRepository.GetInstance();
        
        // список названий отношений
        public static List<string> GetTitleRelationship()
        {
            var listRelationship = _typeRelationshipRepository.GetRelationships().Result;
            var listTitleRelationship = listRelationship
                .Select(r => r.Title)
                .ToList();
            return listTitleRelationship;
        }

        // список отношений
        public static List<TypeRelationship> GetRelationships()
        {
            return _typeRelationshipRepository.GetRelationships().Result;
        }
    }
}
