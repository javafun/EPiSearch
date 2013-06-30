using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lucene.Net.Analysis;

namespace EPiSearch.Lucene.Contrib
{
    public class LetterOrDigitTokenizer : CharTokenizer
    {
        public LetterOrDigitTokenizer(TextReader reader) : base(reader) { }

        protected override bool IsTokenChar(char c)
        {
            return char.IsLetterOrDigit(c);
        }
    }
}
