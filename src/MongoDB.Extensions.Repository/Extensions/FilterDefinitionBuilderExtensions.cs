﻿using MongoDB.Driver;
using MongoDB.Extensions.Repository.Models;
using MongoDB.Extensions.Repository.Interfaces;

namespace MongoDB.Extensions.Repository.Extensions
{
    public static class FilterDefinitionBuilderExtensions
    {
        public static FilterDefinition<TEntity> NotDeleted<TEntity>(this FilterDefinitionBuilder<TEntity> filter)
            where TEntity : SoftDeletableMongoEntity
            => filter.Not(filter.Deleted());

        public static FilterDefinition<TEntity> Deleted<TEntity>(this FilterDefinitionBuilder<TEntity> filter)
            where TEntity : SoftDeletableMongoEntity
            => filter.Exists(x => x.DateDeleted);

        public static FilterDefinition<TEntity> IdEq<TEntity>(this FilterDefinitionBuilder<TEntity> filter, string id)
            where TEntity : MongoEntity
            => filter.Eq(x => x.Id, id);

        public static FilterDefinition<TEntity> NotDeletedAndIdEq<TEntity>(this FilterDefinitionBuilder<TEntity> filter, string id)
            where TEntity : SoftDeletableMongoEntity
            => filter.And(filter.NotDeleted(), filter.IdEq(id));
    }
}
