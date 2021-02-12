using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog.api.helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // OUT
            CreateMap<catalog.domain.model.Product, catalog.application.models.Product>();

        }
    }
}
