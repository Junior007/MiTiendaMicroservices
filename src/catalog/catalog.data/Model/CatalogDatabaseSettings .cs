﻿using catalog.data.interfaces;
using catalog.domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog.data.models
{
    public class CatalogDatabaseSettings: ICatalogDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
