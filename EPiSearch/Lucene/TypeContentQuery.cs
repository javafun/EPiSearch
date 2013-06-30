using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.Core;
using EPiServer.Search.Queries;
using EPiServer.Search.Queries.Lucene;
using Perks;

namespace EPiSearch.Lucene
{
    public class TypeContentQuery : IQueryExpression
    {
        private readonly Type _contentType;

        public TypeContentQuery(Type contentType)
        {
            Ensure.ArgumentNotNull(contentType, "contentType");
            Ensure.Argument(contentType.Is<IContentData>, "contentType",
                string.Format("Content type should implement {0} interface", typeof(IContentData).FullName)
            );

            _contentType = contentType;
        }

        public string GetQueryExpression()
        {
            var typeExpression = "\"" + ContentSearchHandler.GetItemTypeSection(_contentType) + "\"";

            return new FieldQuery(typeExpression, Field.ItemType).GetQueryExpression();
        }
    }
}
