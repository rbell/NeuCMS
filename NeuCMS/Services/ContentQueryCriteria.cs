using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using NeuCMS.Core.Entities;

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

        public Expression<Func<Atom, bool>> WhereExpression
        {
            get { return buildExpression(); }
        }

        private Expression<Func<Atom, bool>> buildExpression()
        {
            var atomParam = Expression.Parameter(typeof (Atom), "a");
            var boolParam = Expression.Parameter(typeof (bool), "result");
            var nameConstant = Expression.Constant(NameSpace);
            var nameMember = MemberExpression.Property(atomParam as Expression, "Name");
            var equalExp = BinaryExpression.Equal(nameMember, nameConstant);
            return Expression.Lambda<Func<Atom, bool>>(equalExp, new ParameterExpression[] {atomParam, boolParam});
        }

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