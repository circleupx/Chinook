using Chinook.Core.Builders;
using System.Collections.Generic;

namespace Chinook.Core
{
    public class ResoureQuerySpecification
    {
        private Dictionary<string, dynamic> FilterDictionary { get; } = new Dictionary<string, dynamic>();
        private List<dynamic> Includes { get; } = new List<dynamic>();
        private dynamic OrderBy { get; set; }
        private dynamic OrderByDescending { get; set; }
        private dynamic GroupBy { get; set; }

        public dynamic GetFilter<T>(string key) 
        {
            var hasValue = FilterDictionary.TryGetValue(key, out dynamic filter);
            if (hasValue)
            {
                return filter;
            }
            else
            {
                return PredicateBuilder.New<T>();
            }
        }

        public void AddFilter(string key, dynamic value)
        {
            FilterDictionary.TryAdd(key, value);
        }
    }
}