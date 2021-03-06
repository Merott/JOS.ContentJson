﻿using System.Collections.Generic;
using System.Reflection;
using EPiServer.Core;
using Jos.ContentJson.Extensions;
using Jos.ContentJson.Interfaces;

namespace Jos.ContentJson.Helpers
{
    public class ContentJsonHelper : ContentJsonHelperBase, IContentJsonHelper
    {
        public Dictionary<string, object> CreatePropertyDictionary(IEnumerable<PropertyInfo> jsonProperties, IContentData content)
        {
            var propertyDict = new Dictionary<string, object>();

            foreach (var property in jsonProperties)
            {
                var processedData = property.GetProcessedData(content);
                var jsonKey = property.GetJsonKey();
                propertyDict.Add(jsonKey, processedData);
            }

            return propertyDict;
        }
    }
}