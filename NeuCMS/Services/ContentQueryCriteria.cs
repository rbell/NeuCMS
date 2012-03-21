using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
        public List<string> Pages { get; set; }

        [DataMember]
        public List<DimensionCriteria> Dimensions { get; set; }

        [DataMember]
        public List<MetadataCriteria> MetadataCriteria { get; set; }

        public Expression<Func<ElementContent, bool>> WhereExpression
        {
            get { return buildExpression(); }
        }

        private Expression<Func<ElementContent, bool>> buildExpression()
        {
            // Build up an Expression of a Function that accepts an Atom and returns bool that
            // will be used as a "where" clause.

            // Define an parameter "a" that will be passed into function.
            var atomParam = Expression.Parameter(typeof(ElementContent), "a");

            Expression whereExp;

            // Start with a.NameSpace = NameSpace
            whereExp = propertyEqualEqualConst(atomParam, "NameSpace", NameSpace);

            // Add "&& a.Name = Name" to function if this.Name is specified.
            if (!string.IsNullOrWhiteSpace(Name))
            {
                var nameEqualExp = propertyEqualEqualConst(atomParam, "Name", Name);
                whereExp = BinaryExpression.And(whereExp, nameEqualExp);
            }

            // Add in criteria of Pages
            if (Pages != null)
            {
                foreach (var page in Pages)
                {
                    if (!string.IsNullOrWhiteSpace(page))
                    {
                        PropertyInfo propertyInfo = typeof(ElementContent).GetProperty("Pages");
                        MemberExpression m = Expression.MakeMemberAccess(atomParam, propertyInfo);
                        ConstantExpression c = Expression.Constant(page, typeof(string));
                        MethodInfo mi = typeof(List<string>).GetMethod("Contains", new Type[] { typeof(string) });
                        var e1 = Expression.Call(m, mi, c); 

                        whereExp = BinaryExpression.And(whereExp, e1);
                    }
                }
            }

            // Add in criteria for dimensions
            if (Dimensions != null)
            {
                foreach (var dimensionCriteria in Dimensions)
                {
                    // TODO: Add And Expression for metadataCriterion to whereExp
                    if (!string.IsNullOrWhiteSpace(dimensionCriteria.DimensionName) &&
                        !string.IsNullOrWhiteSpace(dimensionCriteria.DimensionValue))
                    {
                        PropertyInfo propertyInfo = typeof(ElementContent).GetProperty("Dimensions");
                        MemberExpression m = Expression.MakeMemberAccess(atomParam, propertyInfo);
                        var d = new DimensionValue()
                                    {
                                        DimensionName = dimensionCriteria.DimensionName,
                                        DimensionValue = dimensionCriteria.DimensionValue
                                    };
                        ConstantExpression c = Expression.Constant(d, typeof(DimensionValue));
                        MethodInfo mi = typeof(List<DimensionValue>).GetMethod("Contains", new Type[] { typeof(DimensionValue) });
                        var e1 = Expression.Call(m, mi, c);

                        whereExp = BinaryExpression.And(whereExp, e1);
                    }
                }
            }

            // TODO: Add criteria for metadata

            // Convert the Expression to a Lambda Expression
            return Expression.Lambda<Func<ElementContent, bool>>(whereExp, new ParameterExpression[] { atomParam });
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
    public class DimensionCriteria
    {
        [DataMember]
        public string DimensionName { get; set; }
        [DataMember]
        public string DimensionValue { get; set; }
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

