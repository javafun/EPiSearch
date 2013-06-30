using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EPiSearch.Lucene.Contrib;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using Lucene.Net.Analysis;

namespace EPiSearch.Lucene
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class SearchCustomizer : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var indexingServiceSettingsType = Type.GetType("EPiServer.Search.IndexingService.IndexingServiceSettings, EPiServer.Search.IndexingService");

            // TODO: leave it for now for 100% type init
            var luceneVersion = (global::Lucene.Net.Util.Version) indexingServiceSettingsType
                .GetProperty("LuceneVersion", BindingFlags.Static | BindingFlags.NonPublic)
                .GetValue(null, null);

            var defaultAnalyzer = new UnaccentedWordAnalyzer();
            var textAnalyzer = new UnaccentedWordAnalyzer();

            InitSearchServiceAnalyzer(indexingServiceSettingsType, defaultAnalyzer, textAnalyzer);
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }

        private void InitSearchServiceAnalyzer(Type indexingServiceSettingsType, Analyzer defaultAnalyzer, Analyzer textAnalyzer)
        {
            var perFieldAnalyzerWrapper = new PerFieldAnalyzerWrapper(defaultAnalyzer);
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_ID", new KeywordAnalyzer());
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_CULTURE", new KeywordAnalyzer());
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_REFERENCEID", new KeywordAnalyzer());
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_AUTHORSTORAGE", new KeywordAnalyzer());
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_CATEGORIES", new WhitespaceAnalyzer());
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_ACL", new WhitespaceAnalyzer());
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_VIRTUALPATH", new WhitespaceAnalyzer());
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_TYPE", new WhitespaceAnalyzer());
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_CREATED", new WhitespaceAnalyzer());
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_MODIFIED", new WhitespaceAnalyzer());
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_PUBLICATIONEND", new WhitespaceAnalyzer());
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_PUBLICATIONSTART", new WhitespaceAnalyzer());
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_ITEMSTATUS", new WhitespaceAnalyzer());

            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_TITLE", textAnalyzer);
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_DISPLAYTEXT", textAnalyzer);
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_AUTHORS", textAnalyzer);
            perFieldAnalyzerWrapper.AddAnalyzer("EPISERVER_SEARCH_DEFAULT", textAnalyzer);

            indexingServiceSettingsType
                .GetField("_analyzer", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, perFieldAnalyzerWrapper);
        }
    }
}
