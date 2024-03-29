﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Services
{
    public class PropertyMapping<Tsource, TDestination> : IPropertyMappingMarker
    {

        public Dictionary<string,PropertyMappingValue> MappingDictionary { get; set; }

        public PropertyMapping(Dictionary<string,PropertyMappingValue> mappingDictionary)
        {
            MappingDictionary = mappingDictionary ?? throw new ArgumentNullException(nameof(mappingDictionary));
        }
    }
}
