﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ESFA.DC.CollectionsManagement.Data;
using ESFA.DC.CollectionsManagement.Interfaces;
using ESFA.DC.CollectionsManagement.Models;

namespace ESFA.DC.CollectionsManagement.Services
{
    public class OrganisationService : IOrganisationService
    {
        private readonly CollectionsManagementContext _collectionsManagementContext;

        public OrganisationService(CollectionsManagementContext collectionsManagementContext)
        {
            _collectionsManagementContext = collectionsManagementContext;
        }
        public IEnumerable<CollectionType> GetAvailableCollectionTypes(long ukprn)
        {
            var items  = _collectionsManagementContext.OrganisationCollections
                .Where(x => x.Organisation.Ukprn == ukprn)
                .GroupBy(x=> x.Collection.CollectionType)
                .Select(y => new CollectionType()
                {
                    Description = y.Key.Description,
                    Type = y.Key.Type
                });

            return items;
        }

        public IEnumerable<Collection> GetAvailableCollections(long ukprn, string collectionType)
        {
            var items = _collectionsManagementContext.OrganisationCollections
                .Where(x => x.Organisation.Ukprn == ukprn && 
                            x.Collection.IsOpen &&
                            x.Collection.CollectionType.Type == collectionType)
                .Select(y => new Collection()
                {
                    CollectionTitle = y.Collection.Name,
                    IsOpen = y.Collection.IsOpen,
                    CollectionType = y.Collection.CollectionType.Type
                });

            return items;
        }

        public Organisation GetByUkprn(long ukprn)
        {
            throw new NotImplementedException();
        }
    }
}
