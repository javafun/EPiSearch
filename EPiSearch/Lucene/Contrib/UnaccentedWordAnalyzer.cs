using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lucene.Net.Analysis;

namespace EPiSearch.Lucene.Contrib
{
    public class UnaccentedWordAnalyzer : Analyzer
    {
        /// <summary>
        /// </summary>
        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            TokenStream tokenStream = new LetterOrDigitTokenizer(reader);
            tokenStream = new LowerCaseFilter(tokenStream);
            return new ASCIIFoldingFilter(tokenStream);
        }
    }
}
