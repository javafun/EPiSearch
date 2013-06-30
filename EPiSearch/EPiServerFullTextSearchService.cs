using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using EPiSearch.Lucene;
using EPiServer;
using EPiServer.Core;
using EPiServer.Search;
using EPiServer.Search.Queries;
using EPiServer.Search.Queries.Lucene;
using Lucene.Net.QueryParsers;
using Perks;

namespace EPiSearch
{
    public class EPiServerFullTextSearchService : ISearchService
    {
        private readonly SearchHandler _searchHandler;
        private readonly IContentLoader _contentLoader;
        private readonly IContentRepository _contentRepository;
        private readonly LanguageSelectorFactory _languageSelectorFactory;
        private readonly Settings _settings;

        public class Settings
        {
            public Settings()
            {
                SearchablePageTypes = new List<Type>();
                ItemPreviewProperties = new[] {"ListIntro", "Intro", "Description", "Content"};
                MaxResults = 100;
            }

            public ICollection<Type> SearchablePageTypes { get; set; }

            public ICollection<string> ItemPreviewProperties { get; set; }

            public int MaxResults { get; set; }
        }

        public EPiServerFullTextSearchService(SearchHandler searchHandler, IContentLoader contentLoader,
            IContentRepository contentRepository, LanguageSelectorFactory languageSelectorFactory,
            Settings settings)
        {
            Ensure.ArgumentNotNull(searchHandler, "searchHandler");
            Ensure.ArgumentNotNull(contentLoader, "contentLoader");
            Ensure.ArgumentNotNull(contentRepository, "contentRepository");
            Ensure.ArgumentNotNull(languageSelectorFactory, "languageSelectorFactory");

            _searchHandler = searchHandler;
            _contentLoader = contentLoader;
            _contentRepository = contentRepository;
            _languageSelectorFactory = languageSelectorFactory;
            _settings = settings ?? new Settings();
        }

        public SearchResults Search(string query, int skip, int take)
        {
            query = PrepareQuery(query);

            if (query.IsNullOrEmpty())
            {
                return new SearchResults();
            }

            var epiQuery = CreateQuery(query);

            var searchHits = _searchHandler.GetSearchResults(epiQuery, 1, _settings.MaxResults);
            var filteredResults = FilterResults(searchHits.IndexResponseItems).ToList();

            var result = new SearchResults
                {
                    Results = filteredResults.Skip(skip).Take(take).Select(ToSearchItem).ToList()
                };
            result.TotalCount = filteredResults.Count;

            return result;
        }

        private string PrepareQuery(string query)
        {
            query = new AsciiFolder().FoldToAscii(query);

            query = query.Trim().Replace("*", "");
            query = QueryParser.Escape(query);

            return query;
        }

        private IEnumerable<PageSearchItem> FilterResults(IEnumerable<IndexResponseItem> results)
        {
            foreach (var result in results)
            {
                var page = GetContent<PageData>(result);

                if (page != null && page.HasTemplate() && page.IsPublished())
                {
                    yield return new PageSearchItem {Info = result, Item = page};
                }
            }
        }

        public SearchItem ToSearchItem(PageSearchItem res)
        {
            var item = new SearchItem
                {
                    Title = res.Info.Title,
                    Content = GetItemContent(res).Replace('\n', ' ').CutTo(190, with: "..."),
                    Url = res.Item.GetFriendlyUrl() ??
                          res.Info.Uri.IfNotNull(x => x.ToString()) ??
                          res.Info.DataUri.IfNotNull(x => x.ToString())
                };

            return item;
        }

        private string GetItemContent(PageSearchItem res)
        {
            foreach (var forPreview in _settings.ItemPreviewProperties)
            {
                var itemProp = res.Item.GetType().GetProperty(forPreview);

                if (itemProp != null)
                {
                    var propValue = itemProp.GetValue(res.Item);

                    if (propValue is string && ((string) propValue).IsNotNullOrEmpty())
                    {
                        return (string) propValue;
                    }
                    if (propValue is IHtmlString)
                    {
                        var propHtml = ((IHtmlString) propValue).ToHtmlString();

                        if (propHtml.IsNotNullOrEmpty())
                        {
                            return propHtml.TrimHtml();
                        }
                    }
                }
            }

            return res.Info.DisplayText;
        }

        private IQueryExpression CreateQuery(string searchText)
        {
            var query = new GroupQuery(LuceneOperator.AND);

            var wildcardSearchText = searchText.Replace(" ", "* ") + "*";
            query.QueryExpressions.Add(new FieldQuery(wildcardSearchText));

            var contentQuery = new GroupQuery(LuceneOperator.AND);

            if (_settings.SearchablePageTypes.Any())
            {
                var contentTypesQuery = new GroupQuery(LuceneOperator.OR);

                foreach (var pageType in _settings.SearchablePageTypes)
                {
                    contentTypesQuery.QueryExpressions.Add(new TypeContentQuery(pageType));
                }

                contentQuery.QueryExpressions.Add(contentTypesQuery);
            }
            else
            {
                contentQuery.QueryExpressions.Add(new ContentQuery());
            }

            var contentRootQuery = new VirtualPathQuery();
            contentRootQuery.AddContentNodes(ContentReference.StartPage, _contentLoader);
            contentQuery.QueryExpressions.Add(new FieldQuery(CultureInfo.CurrentUICulture.Name, Field.Culture));
            contentQuery.QueryExpressions.Add(contentRootQuery);

            query.QueryExpressions.Add(contentQuery);

            return query;
        }

        // Temporary decompiled (due to StructureMap epi ioc)
        public virtual T GetContent<T>(IndexItemBase indexItem) where T : IContent
        {
            if (indexItem == null || string.IsNullOrEmpty(indexItem.Id))
                return default(T);
            Guid result;
            if (Guid.TryParse(indexItem.Id.Split('|').FirstOrDefault(), out result))
            {
                var selector = GetLanguageSelector(indexItem.Culture);
                try
                {
                    return _contentRepository.Get<T>(result, selector);
                }
                catch (ContentNotFoundException ex)
                {
                    // TODO: use our log for now
                    // ContentSearchHandler._log.Warn((object)string.Format((IFormatProvider)CultureInfo.InvariantCulture, "Search index returned an item with GUID {0:B}, that no longer exists in the content repository.", new object[1]{(object) result}), (Exception)ex);
                }
            }
            return default(T);
        }
        private ILanguageSelector GetLanguageSelector(string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return _languageSelectorFactory.AutoDetect(true);
            else
                return new LanguageSelector(languageCode);
        }
    }

    public class PageSearchItem
    {
        public IndexResponseItem Info { get; set; }

        public IContent Item { get; set; }
    }
}
