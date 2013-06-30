using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.BaseLibrary.Scheduling;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.ServiceLocation;

namespace EPiSearch
{
    [ScheduledPlugIn(DisplayName = "Rebuild search index", Description = "Forces EPiServer search service to rebuild all search indexes")]
    public class SearchReindexJob : JobBase
    {
        public override string Execute()
        {
            var contentSearchHandler = ServiceLocator.Current.GetInstance<ContentSearchHandler>();

            contentSearchHandler.ReIndex();

            return "Search index rebuild task has been started. Index must be updated in a minute...";
        }
    }
}
