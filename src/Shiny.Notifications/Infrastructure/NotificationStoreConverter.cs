﻿using System.Collections.Generic;
using Shiny.Stores;

namespace Shiny.Notifications.Infrastructure;


public class NotificationStoreConverter : IStoreConverter<Notification>
{
    public Notification FromStore(IDictionary<string, object> values) => throw new System.NotImplementedException();
    public IEnumerable<(string Property, object value)> ToStore(Notification entity) => throw new System.NotImplementedException();
}