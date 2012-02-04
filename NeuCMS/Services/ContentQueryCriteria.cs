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
            // Build up an Expression of a Function that accepts an Atom and returns bool that
            // will be used as a "where" clause.

            // Define an parameter "a" that will be passed into function.
            var atomParam = Expression.Parameter(typeof(Atom), "a");

            Expression whereExp;

            // Start with a.NameSpace = NameSpace
            whereExp = propertyEqualEqualConst(atomParam, "NameSpace", NameSpace);

            // Add "&& a.Name = Name" to function if this.Name is specified.
            if (!string.IsNullOrWhiteSpace(Name))
            {
                var nameEqualExp = propertyEqualEqualConst(atomParam, "Name", Name);
                whereExp = BinaryExpression.Add(whereExp, nameEqualExp);
            }

            // Add in criteria for metadata
            if (MetadataCriteria != null)
            {
                foreach (var metadataCriterion in MetadataCriteria)
                {
                    // TODO: Add And Expression for metadataCriterion to whereExp
                    if (!string.IsNullOrWhiteSpace(metadataCriterion.MetaDataName) &&
                        !string.IsNullOrWhiteSpace(metadataCriterion.MetaDataValue))
                    {
                        Expression<Func<Atom, bool>> metaExpression =
                            a =>
                            a.MetaData.Contains(new ContentMetadata()
                                                    {
                                                        Name = metadataCriterion.MetaDataName,
                                                        Value = metadataCriterion.MetaDataValue
                                                    });
                        whereExp = BinaryExpression.Add(whereExp, metaExpression);
                    }
                }

            }

            // Convert the Expression to a Lambda Expression
            return Expression.Lambda<Func<Atom, bool>>(whereExp, new ParameterExpression[] { atomParam });
        }

        private BinaryExpression propertyEqualEqualConst(ParameterExpression atomParam, string property, object constVal)
        {
            var nameConstant = Expression.Constant(constVal);
            var nameMember = MemberExpression.Property(atomParam as Expression, property);
            var equalExp = BinaryExpression.Equal(nameMember, nameConstant);
            return equalExp;
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

