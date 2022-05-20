﻿using System.Collections.Generic;

namespace Shiny.Stores.Infrastructure;


public interface IStoreConverter<TEntity> where TEntity : IStoreEntity
{
    TEntity FromStore(IDictionary<string, object> values);
    IEnumerable<(string Property, object value)> ToStore(TEntity entity);
}