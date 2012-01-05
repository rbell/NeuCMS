using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeuCMS.Services
{
    [DataContract]
    public class ContentQueryResults : IList<ContentQueryResult>
    {
        public ContentQueryResults()
        {
            Results = new List<ContentQueryResult>();
        }

        [DataMember]
        public List<ContentQueryResult> Results { get; set; }

        public IEnumerator<ContentQueryResult> GetEnumerator()
        {
            return Results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ContentQueryResult item)
        {
            Results.Add(item);
        }

        public void Clear()
        {
            Results.Clear();
        }

        public bool Contains(ContentQueryResult item)
        {
            return Results.Contains(item);
        }

        public void CopyTo(ContentQueryResult[] array, int arrayIndex)
        {
            Results.CopyTo(array,arrayIndex);
        }

        public bool Remove(ContentQueryResult item)
        {
            return Results.Remove(item);
        }

        public int Count
        {
            get { return Results.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((IList<ContentQueryResult>)Results).IsReadOnly; }
        }

        public int IndexOf(ContentQueryResult item)
        {
            return Results.IndexOf(item);
        }

        public void Insert(int index, ContentQueryResult item)
        {
            Results.Insert(index,item);
        }

        public void RemoveAt(int index)
        {
            Results.RemoveAt(index);
        }

        public ContentQueryResult this[int index]
        {
            get { return Results[index]; }
            set { Results[index] = value; }
        }
    }

    [DataContract]
    public class ContentQueryResult
    {
        [DataMember]
        public string ContentKey { get; set; }

        [DataMember]
        public string Content { get; set; }
    }
}