using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeuCMS.Services
{
    [DataContract]
    public class ContentQueryCriteria
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string NameSpace { get; set; }
        [DataMember]
        public List<MetadataCriteria> MetadataCriteria { get; set; }
    }

    [DataContract]
    public class MetadataCriteria
    {
        [DataMember]
        public string MetaDataName { get; set; }
        [DataMember]
        public string MetaDataValue { get; set; }
    }
}