using System;
using System.Data.Services.Common;

namespace NeuCMS.Core.Entities
{
    [DataServiceKey("Id")]
    public class ContentQueryResult
    {
        public int Id { get; set; }

        public string ContentKey { get; set; }

        public string Content { get; set; }

    }

    public class QueryKeyValue : IEquatable<QueryKeyValue>
    {
        public QueryKeyValue()
        {
        }

        public QueryKeyValue(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }

        public bool Equals(QueryKeyValue other)
        {
            return this.Key == other.Key && this.Value == other.Value;
        }

        public override int GetHashCode()
        {
            int keyHash = Key == null ? 0 : Key.GetHashCode();
            int valueHash = Value == null ? 0 : Value.GetHashCode();
            return keyHash ^ valueHash;
        }
    }
}

