﻿using catalog.domain.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.data.interfaces
{
    public interface ICatalogContext
    {
        bool IsOpen();

        IMongoCollection<Product> Products { get; }

    }
}
