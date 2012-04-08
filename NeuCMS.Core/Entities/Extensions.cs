using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuCMS.Core.Entities
{
    public static class Extensions
    {
        public static bool MatchesDimensions(this Content content, List<QueryKeyValue> values)
        {
            var q = (from d in content.Dimensions
                     select new QueryKeyValue() { Key = d.DimensionDefinition.DimensionName, Value = d.Value }).ToList();
            var b = q.Intersect(values).Any();
            return b;
        }

        public static string ToQueryString(this Dictionary<string,string> dictionary)
        {
            var sb = new StringBuilder();
            foreach (var item in dictionary)
            {
                sb.Append(item.Key);
                sb.Append(":");
                sb.Append(item.Value);
                sb.Append(";");
            }
            return sb.ToString();
        }


        public static string ToQueryString(this List<QueryKeyValue> lst)
        {
            var sb = new StringBuilder();
            foreach (var queryKeyValue in lst)
            {
                sb.Append(queryKeyValue.Key);
                sb.Append(":");
                sb.Append(queryKeyValue.Value);
                sb.Append(";");
            }
            return sb.ToString();
        }

        public static List<QueryKeyValue> ParseQueryKeyValues(this string strToParse)
        {
            if (strToParse == null)
            {
                return new List<QueryKeyValue>();
            }

            try
            {
                var lst = new List<QueryKeyValue>();
                var keyValuePairs = strToParse.Split(';');
                foreach (var keyValuePair in keyValuePairs)
                {
                    var pair = keyValuePair.Split((':'));
                    if (pair.Length == 2)
                    {
                        lst.Add(new QueryKeyValue(pair[0], pair[1]));
                    }
                }
                return lst;
            }
            catch (Exception)
            {
                return new List<QueryKeyValue>();
            }
        }
    }
}