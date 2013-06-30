using System;
using System.Collections.Generic;
using System.Linq;

namespace EPiSearch.Lucene
{
    public class AsciiFolder
    {
        public string FoldToAscii(string text)
        {
            var output = new char[text.Length * 2];
            var outputPos = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if ((int)ch < 128)
                {
                    output[outputPos++] = ch;
                }
                else
                {
                    switch (ch)
                    {
                        case 'ﬀ':
                            output[outputPos++] = 'f';
                            output[outputPos++] = 'f';
                            continue;
                        case 'ﬁ':
                            output[outputPos++] = 'f';
                            output[outputPos++] = 'i';
                            continue;
                        case 'ﬂ':
                            output[outputPos++] = 'f';
                            output[outputPos++] = 'l';
                            continue;
                        case 'ﬃ':
                            output[outputPos++] = 'f';
                            output[outputPos++] = 'f';
                            output[outputPos++] = 'i';
                            continue;
                        case 'ﬄ':
                            output[outputPos++] = 'f';
                            output[outputPos++] = 'f';
                            output[outputPos++] = 'l';
                            continue;
                        case 'ﬆ':
                            output[outputPos++] = 's';
                            output[outputPos++] = 't';
                            continue;
                        case '！':
                            output[outputPos++] = '!';
                            continue;
                        case '＂':
                        case '❝':
                        case '❞':
                        case '❮':
                        case '❯':
                        case '″':
                        case '‶':
                        case '«':
                        case '»':
                        case '“':
                        case '”':
                        case '„':
                            output[outputPos++] = '"';
                            continue;
                        case '＃':
                            output[outputPos++] = '#';
                            continue;
                        case '＄':
                            output[outputPos++] = '$';
                            continue;
                        case '％':
                        case '⁒':
                            output[outputPos++] = '%';
                            continue;
                        case '＆':
                            output[outputPos++] = '&';
                            continue;
                        case '＇':
                        case '❛':
                        case '❜':
                        case '′':
                        case '‵':
                        case '‹':
                        case '›':
                        case '‘':
                        case '’':
                        case '‚':
                        case '‛':
                            output[outputPos++] = '\'';
                            continue;
                        case '（':
                        case '❨':
                        case '❪':
                        case '⁽':
                        case '₍':
                            output[outputPos++] = '(';
                            continue;
                        case '）':
                        case '❩':
                        case '❫':
                        case '⁾':
                        case '₎':
                            output[outputPos++] = ')';
                            continue;
                        case '＊':
                        case '⁎':
                            output[outputPos++] = '*';
                            continue;
                        case '＋':
                        case '⁺':
                        case '₊':
                            output[outputPos++] = '+';
                            continue;
                        case '，':
                            output[outputPos++] = ',';
                            continue;
                        case '－':
                        case '⁻':
                        case '₋':
                        case '‐':
                        case '‑':
                        case '‒':
                        case '–':
                        case '—':
                            output[outputPos++] = '-';
                            continue;
                        case '．':
                            output[outputPos++] = '.';
                            continue;
                        case '／':
                        case '⁄':
                            output[outputPos++] = '/';
                            continue;
                        case '０':
                        case '\x2070':
                        case '\x2080':
                        case '\x24EA':
                        case '\x24FF':
                            output[outputPos++] = '0';
                            continue;
                        case '１':
                        case '\x2776':
                        case '\x2780':
                        case '\x278A':
                        case '\x2081':
                        case '\x2460':
                        case '\x24F5':
                        case '\x00B9':
                            output[outputPos++] = '1';
                            continue;
                        case '２':
                        case '\x2777':
                        case '\x2781':
                        case '\x278B':
                        case '\x2082':
                        case '\x2461':
                        case '\x24F6':
                        case '\x00B2':
                            output[outputPos++] = '2';
                            continue;
                        case '３':
                        case '\x2778':
                        case '\x2782':
                        case '\x278C':
                        case '\x2083':
                        case '\x2462':
                        case '\x24F7':
                        case '\x00B3':
                            output[outputPos++] = '3';
                            continue;
                        case '４':
                        case '\x2779':
                        case '\x2783':
                        case '\x278D':
                        case '\x2074':
                        case '\x2084':
                        case '\x2463':
                        case '\x24F8':
                            output[outputPos++] = '4';
                            continue;
                        case '５':
                        case '\x277A':
                        case '\x2784':
                        case '\x278E':
                        case '\x2075':
                        case '\x2085':
                        case '\x2464':
                        case '\x24F9':
                            output[outputPos++] = '5';
                            continue;
                        case '６':
                        case '\x277B':
                        case '\x2785':
                        case '\x278F':
                        case '\x2076':
                        case '\x2086':
                        case '\x2465':
                        case '\x24FA':
                            output[outputPos++] = '6';
                            continue;
                        case '７':
                        case '\x277C':
                        case '\x2786':
                        case '\x2790':
                        case '\x2077':
                        case '\x2087':
                        case '\x2466':
                        case '\x24FB':
                            output[outputPos++] = '7';
                            continue;
                        case '８':
                        case '\x277D':
                        case '\x2787':
                        case '\x2791':
                        case '\x2078':
                        case '\x2088':
                        case '\x2467':
                        case '\x24FC':
                            output[outputPos++] = '8';
                            continue;
                        case '９':
                        case '\x277E':
                        case '\x2788':
                        case '\x2792':
                        case '\x2079':
                        case '\x2089':
                        case '\x2468':
                        case '\x24FD':
                            output[outputPos++] = '9';
                            continue;
                        case '：':
                            output[outputPos++] = ':';
                            continue;
                        case '；':
                        case '⁏':
                            output[outputPos++] = ';';
                            continue;
                        case '＜':
                        case '❬':
                        case '❰':
                            output[outputPos++] = '<';
                            continue;
                        case '＝':
                        case '⁼':
                        case '₌':
                            output[outputPos++] = '=';
                            continue;
                        case '＞':
                        case '❭':
                        case '❱':
                            output[outputPos++] = '>';
                            continue;
                        case '？':
                            output[outputPos++] = '?';
                            continue;
                        case '＠':
                            output[outputPos++] = '@';
                            continue;
                        case 'Ａ':
                        case 'Ⓐ':
                        case 'À':
                        case 'Á':
                        case 'Â':
                        case 'Ã':
                        case 'Ä':
                        case 'Å':
                        case 'Ā':
                        case 'Ă':
                        case 'Ą':
                        case 'Ə':
                        case 'Ǎ':
                        case 'Ǟ':
                        case 'Ǡ':
                        case 'Ǻ':
                        case 'Ȁ':
                        case 'Ȃ':
                        case 'Ȧ':
                        case 'Ⱥ':
                        case 'ᴀ':
                        case 'Ḁ':
                        case 'Ạ':
                        case 'Ả':
                        case 'Ấ':
                        case 'Ầ':
                        case 'Ẩ':
                        case 'Ẫ':
                        case 'Ậ':
                        case 'Ắ':
                        case 'Ằ':
                        case 'Ẳ':
                        case 'Ẵ':
                        case 'Ặ':
                            output[outputPos++] = 'A';
                            continue;
                        case 'Ｂ':
                        case 'Ⓑ':
                        case 'Ɓ':
                        case 'Ƃ':
                        case 'Ƀ':
                        case 'ʙ':
                        case 'ᴃ':
                        case 'Ḃ':
                        case 'Ḅ':
                        case 'Ḇ':
                            output[outputPos++] = 'B';
                            continue;
                        case 'Ｃ':
                        case 'Ⓒ':
                        case 'Ç':
                        case 'Ć':
                        case 'Ĉ':
                        case 'Ċ':
                        case 'Č':
                        case 'Ƈ':
                        case 'Ȼ':
                        case 'ʗ':
                        case 'ᴄ':
                        case 'Ḉ':
                            output[outputPos++] = 'C';
                            continue;
                        case 'Ｄ':
                        case 'Ꝺ':
                        case 'Ⓓ':
                        case 'Ð':
                        case 'Ď':
                        case 'Đ':
                        case 'Ɖ':
                        case 'Ɗ':
                        case 'Ƌ':
                        case 'ᴅ':
                        case 'ᴆ':
                        case 'Ḋ':
                        case 'Ḍ':
                        case 'Ḏ':
                        case 'Ḑ':
                        case 'Ḓ':
                            output[outputPos++] = 'D';
                            continue;
                        case 'Ｅ':
                        case 'ⱻ':
                        case 'Ⓔ':
                        case 'È':
                        case 'É':
                        case 'Ê':
                        case 'Ë':
                        case 'Ē':
                        case 'Ĕ':
                        case 'Ė':
                        case 'Ę':
                        case 'Ě':
                        case 'Ǝ':
                        case 'Ɛ':
                        case 'Ȅ':
                        case 'Ȇ':
                        case 'Ȩ':
                        case 'Ɇ':
                        case 'ᴇ':
                        case 'Ḕ':
                        case 'Ḗ':
                        case 'Ḙ':
                        case 'Ḛ':
                        case 'Ḝ':
                        case 'Ẹ':
                        case 'Ẻ':
                        case 'Ẽ':
                        case 'Ế':
                        case 'Ề':
                        case 'Ể':
                        case 'Ễ':
                        case 'Ệ':
                            output[outputPos++] = 'E';
                            continue;
                        case 'Ｆ':
                        case 'ꜰ':
                        case 'Ꝼ':
                        case 'ꟻ':
                        case 'Ⓕ':
                        case 'Ƒ':
                        case 'Ḟ':
                            output[outputPos++] = 'F';
                            continue;
                        case 'Ｇ':
                        case 'Ᵹ':
                        case 'Ꝿ':
                        case 'Ⓖ':
                        case 'Ĝ':
                        case 'Ğ':
                        case 'Ġ':
                        case 'Ģ':
                        case 'Ɠ':
                        case 'Ǥ':
                        case 'ǥ':
                        case 'Ǧ':
                        case 'ǧ':
                        case 'Ǵ':
                        case 'ɢ':
                        case 'ʛ':
                        case 'Ḡ':
                            output[outputPos++] = 'G';
                            continue;
                        case 'Ｈ':
                        case 'Ⱨ':
                        case 'Ⱶ':
                        case 'Ⓗ':
                        case 'Ĥ':
                        case 'Ħ':
                        case 'Ȟ':
                        case 'ʜ':
                        case 'Ḣ':
                        case 'Ḥ':
                        case 'Ḧ':
                        case 'Ḩ':
                        case 'Ḫ':
                            output[outputPos++] = 'H';
                            continue;
                        case 'Ｉ':
                        case 'ꟾ':
                        case 'Ⓘ':
                        case 'Ì':
                        case 'Í':
                        case 'Î':
                        case 'Ï':
                        case 'Ĩ':
                        case 'Ī':
                        case 'Ĭ':
                        case 'Į':
                        case 'İ':
                        case 'Ɩ':
                        case 'Ɨ':
                        case 'Ǐ':
                        case 'Ȉ':
                        case 'Ȋ':
                        case 'ɪ':
                        case 'ᵻ':
                        case 'Ḭ':
                        case 'Ḯ':
                        case 'Ỉ':
                        case 'Ị':
                            output[outputPos++] = 'I';
                            continue;
                        case 'Ｊ':
                        case 'Ⓙ':
                        case 'Ĵ':
                        case 'Ɉ':
                        case 'ᴊ':
                            output[outputPos++] = 'J';
                            continue;
                        case 'Ｋ':
                        case 'Ꝁ':
                        case 'Ꝃ':
                        case 'Ꝅ':
                        case 'Ⱪ':
                        case 'Ⓚ':
                        case 'Ķ':
                        case 'Ƙ':
                        case 'Ǩ':
                        case 'ᴋ':
                        case 'Ḱ':
                        case 'Ḳ':
                        case 'Ḵ':
                            output[outputPos++] = 'K';
                            continue;
                        case 'Ｌ':
                        case 'Ꝇ':
                        case 'Ꝉ':
                        case 'Ꞁ':
                        case 'Ⱡ':
                        case 'Ɫ':
                        case 'Ⓛ':
                        case 'Ĺ':
                        case 'Ļ':
                        case 'Ľ':
                        case 'Ŀ':
                        case 'Ł':
                        case 'Ƚ':
                        case 'ʟ':
                        case 'ᴌ':
                        case 'Ḷ':
                        case 'Ḹ':
                        case 'Ḻ':
                        case 'Ḽ':
                            output[outputPos++] = 'L';
                            continue;
                        case 'Ｍ':
                        case 'ꟽ':
                        case 'ꟿ':
                        case 'Ɱ':
                        case 'Ⓜ':
                        case 'Ɯ':
                        case 'ᴍ':
                        case 'Ḿ':
                        case 'Ṁ':
                        case 'Ṃ':
                            output[outputPos++] = 'M';
                            continue;
                        case 'Ｎ':
                        case 'Ⓝ':
                        case 'Ñ':
                        case 'Ń':
                        case 'Ņ':
                        case 'Ň':
                        case 'Ŋ':
                        case 'Ɲ':
                        case 'Ǹ':
                        case 'Ƞ':
                        case 'ɴ':
                        case 'ᴎ':
                        case 'Ṅ':
                        case 'Ṇ':
                        case 'Ṉ':
                        case 'Ṋ':
                            output[outputPos++] = 'N';
                            continue;
                        case 'Ｏ':
                        case 'Ꝋ':
                        case 'Ꝍ':
                        case 'Ⓞ':
                        case 'Ò':
                        case 'Ó':
                        case 'Ô':
                        case 'Õ':
                        case 'Ö':
                        case 'Ø':
                        case 'Ō':
                        case 'Ŏ':
                        case 'Ő':
                        case 'Ɔ':
                        case 'Ɵ':
                        case 'Ơ':
                        case 'Ǒ':
                        case 'Ǫ':
                        case 'Ǭ':
                        case 'Ǿ':
                        case 'Ȍ':
                        case 'Ȏ':
                        case 'Ȫ':
                        case 'Ȭ':
                        case 'Ȯ':
                        case 'Ȱ':
                        case 'ᴏ':
                        case 'ᴐ':
                        case 'Ṍ':
                        case 'Ṏ':
                        case 'Ṑ':
                        case 'Ṓ':
                        case 'Ọ':
                        case 'Ỏ':
                        case 'Ố':
                        case 'Ồ':
                        case 'Ổ':
                        case 'Ỗ':
                        case 'Ộ':
                        case 'Ớ':
                        case 'Ờ':
                        case 'Ở':
                        case 'Ỡ':
                        case 'Ợ':
                            output[outputPos++] = 'O';
                            continue;
                        case 'Ｐ':
                        case 'Ꝑ':
                        case 'Ꝓ':
                        case 'Ꝕ':
                        case 'Ᵽ':
                        case 'Ⓟ':
                        case 'Ƥ':
                        case 'ᴘ':
                        case 'Ṕ':
                        case 'Ṗ':
                            output[outputPos++] = 'P';
                            continue;
                        case 'Ｑ':
                        case 'Ꝗ':
                        case 'Ꝙ':
                        case 'Ⓠ':
                        case 'Ɋ':
                            output[outputPos++] = 'Q';
                            continue;
                        case 'Ｒ':
                        case 'Ꝛ':
                        case 'Ꞃ':
                        case 'Ɽ':
                        case 'Ⓡ':
                        case 'Ŕ':
                        case 'Ŗ':
                        case 'Ř':
                        case 'Ȑ':
                        case 'Ȓ':
                        case 'Ɍ':
                        case 'ʀ':
                        case 'ʁ':
                        case 'ᴙ':
                        case 'ᴚ':
                        case 'Ṙ':
                        case 'Ṛ':
                        case 'Ṝ':
                        case 'Ṟ':
                            output[outputPos++] = 'R';
                            continue;
                        case 'Ｓ':
                        case 'ꜱ':
                        case 'ꞅ':
                        case 'Ⓢ':
                        case 'Ś':
                        case 'Ŝ':
                        case 'Ş':
                        case 'Š':
                        case 'Ș':
                        case 'Ṡ':
                        case 'Ṣ':
                        case 'Ṥ':
                        case 'Ṧ':
                        case 'Ṩ':
                            output[outputPos++] = 'S';
                            continue;
                        case 'Ｔ':
                        case 'Ꞇ':
                        case 'Ⓣ':
                        case 'Ţ':
                        case 'Ť':
                        case 'Ŧ':
                        case 'Ƭ':
                        case 'Ʈ':
                        case 'Ț':
                        case 'Ⱦ':
                        case 'ᴛ':
                        case 'Ṫ':
                        case 'Ṭ':
                        case 'Ṯ':
                        case 'Ṱ':
                            output[outputPos++] = 'T';
                            continue;
                        case 'Ｕ':
                        case 'Ⓤ':
                        case 'Ù':
                        case 'Ú':
                        case 'Û':
                        case 'Ü':
                        case 'Ũ':
                        case 'Ū':
                        case 'Ŭ':
                        case 'Ů':
                        case 'Ű':
                        case 'Ų':
                        case 'Ư':
                        case 'Ǔ':
                        case 'Ǖ':
                        case 'Ǘ':
                        case 'Ǚ':
                        case 'Ǜ':
                        case 'Ȕ':
                        case 'Ȗ':
                        case 'Ʉ':
                        case 'ᴜ':
                        case 'ᵾ':
                        case 'Ṳ':
                        case 'Ṵ':
                        case 'Ṷ':
                        case 'Ṹ':
                        case 'Ṻ':
                        case 'Ụ':
                        case 'Ủ':
                        case 'Ứ':
                        case 'Ừ':
                        case 'Ử':
                        case 'Ữ':
                        case 'Ự':
                            output[outputPos++] = 'U';
                            continue;
                        case 'Ｖ':
                        case 'Ꝟ':
                        case 'Ꝩ':
                        case 'Ⓥ':
                        case 'Ʋ':
                        case 'Ʌ':
                        case 'ᴠ':
                        case 'Ṽ':
                        case 'Ṿ':
                        case 'Ỽ':
                            output[outputPos++] = 'V';
                            continue;
                        case 'Ｗ':
                        case 'Ⱳ':
                        case 'Ⓦ':
                        case 'Ŵ':
                        case 'Ƿ':
                        case 'ᴡ':
                        case 'Ẁ':
                        case 'Ẃ':
                        case 'Ẅ':
                        case 'Ẇ':
                        case 'Ẉ':
                            output[outputPos++] = 'W';
                            continue;
                        case 'Ｘ':
                        case 'Ⓧ':
                        case 'Ẋ':
                        case 'Ẍ':
                            output[outputPos++] = 'X';
                            continue;
                        case 'Ｙ':
                        case 'Ⓨ':
                        case 'Ý':
                        case 'Ŷ':
                        case 'Ÿ':
                        case 'Ƴ':
                        case 'Ȳ':
                        case 'Ɏ':
                        case 'ʏ':
                        case 'Ẏ':
                        case 'Ỳ':
                        case 'Ỵ':
                        case 'Ỷ':
                        case 'Ỹ':
                        case 'Ỿ':
                            output[outputPos++] = 'Y';
                            continue;
                        case 'Ｚ':
                        case 'Ꝣ':
                        case 'Ⱬ':
                        case 'Ⓩ':
                        case 'Ź':
                        case 'Ż':
                        case 'Ž':
                        case 'Ƶ':
                        case 'Ȝ':
                        case 'Ȥ':
                        case 'ᴢ':
                        case 'Ẑ':
                        case 'Ẓ':
                        case 'Ẕ':
                            output[outputPos++] = 'Z';
                            continue;
                        case '［':
                        case '❲':
                        case '⁅':
                            output[outputPos++] = '[';
                            continue;
                        case '＼':
                            output[outputPos++] = '\\';
                            continue;
                        case '］':
                        case '❳':
                        case '⁆':
                            output[outputPos++] = ']';
                            continue;
                        case '＾':
                        case '‸':
                            output[outputPos++] = '^';
                            continue;
                        case '＿':
                            output[outputPos++] = '_';
                            continue;
                        case 'ａ':
                        case 'ⱥ':
                        case 'Ɐ':
                        case '\x2090':
                        case '\x2094':
                        case 'ⓐ':
                        case 'à':
                        case 'á':
                        case 'â':
                        case 'ã':
                        case 'ä':
                        case 'å':
                        case 'ā':
                        case 'ă':
                        case 'ą':
                        case 'ǎ':
                        case 'ǟ':
                        case 'ǡ':
                        case 'ǻ':
                        case 'ȁ':
                        case 'ȃ':
                        case 'ȧ':
                        case 'ɐ':
                        case 'ə':
                        case 'ɚ':
                        case 'ᶏ':
                        case 'ᶕ':
                        case 'ḁ':
                        case 'ẚ':
                        case 'ạ':
                        case 'ả':
                        case 'ấ':
                        case 'ầ':
                        case 'ẩ':
                        case 'ẫ':
                        case 'ậ':
                        case 'ắ':
                        case 'ằ':
                        case 'ẳ':
                        case 'ẵ':
                        case 'ặ':
                            output[outputPos++] = 'a';
                            continue;
                        case 'ｂ':
                        case 'ⓑ':
                        case 'ƀ':
                        case 'ƃ':
                        case 'ɓ':
                        case 'ᵬ':
                        case 'ᶀ':
                        case 'ḃ':
                        case 'ḅ':
                        case 'ḇ':
                            output[outputPos++] = 'b';
                            continue;
                        case 'ｃ':
                        case 'Ꜿ':
                        case 'ꜿ':
                        case 'ↄ':
                        case 'ⓒ':
                        case 'ç':
                        case 'ć':
                        case 'ĉ':
                        case 'ċ':
                        case 'č':
                        case 'ƈ':
                        case 'ȼ':
                        case 'ɕ':
                        case 'ḉ':
                            output[outputPos++] = 'c';
                            continue;
                        case 'ｄ':
                        case 'ꝺ':
                        case 'ⓓ':
                        case 'ð':
                        case 'ď':
                        case 'đ':
                        case 'ƌ':
                        case 'ȡ':
                        case 'ɖ':
                        case 'ɗ':
                        case 'ᵭ':
                        case 'ᶁ':
                        case 'ᶑ':
                        case 'ḋ':
                        case 'ḍ':
                        case 'ḏ':
                        case 'ḑ':
                        case 'ḓ':
                            output[outputPos++] = 'd';
                            continue;
                        case 'ｅ':
                        case 'ⱸ':
                        case '\x2091':
                        case 'ⓔ':
                        case 'è':
                        case 'é':
                        case 'ê':
                        case 'ë':
                        case 'ē':
                        case 'ĕ':
                        case 'ė':
                        case 'ę':
                        case 'ě':
                        case 'ǝ':
                        case 'ȅ':
                        case 'ȇ':
                        case 'ȩ':
                        case 'ɇ':
                        case 'ɘ':
                        case 'ɛ':
                        case 'ɜ':
                        case 'ɝ':
                        case 'ɞ':
                        case 'ʚ':
                        case 'ᴈ':
                        case 'ᶒ':
                        case 'ᶓ':
                        case 'ᶔ':
                        case 'ḕ':
                        case 'ḗ':
                        case 'ḙ':
                        case 'ḛ':
                        case 'ḝ':
                        case 'ẹ':
                        case 'ẻ':
                        case 'ẽ':
                        case 'ế':
                        case 'ề':
                        case 'ể':
                        case 'ễ':
                        case 'ệ':
                            output[outputPos++] = 'e';
                            continue;
                        case 'ｆ':
                        case 'ꝼ':
                        case 'ⓕ':
                        case 'ƒ':
                        case 'ᵮ':
                        case 'ᶂ':
                        case 'ḟ':
                        case 'ẛ':
                            output[outputPos++] = 'f';
                            continue;
                        case 'ｇ':
                        case 'ꝿ':
                        case 'ⓖ':
                        case 'ĝ':
                        case 'ğ':
                        case 'ġ':
                        case 'ģ':
                        case 'ǵ':
                        case 'ɠ':
                        case 'ɡ':
                        case 'ᵷ':
                        case 'ᵹ':
                        case 'ᶃ':
                        case 'ḡ':
                            output[outputPos++] = 'g';
                            continue;
                        case 'ｈ':
                        case 'ⱨ':
                        case 'ⱶ':
                        case 'ⓗ':
                        case 'ĥ':
                        case 'ħ':
                        case 'ȟ':
                        case 'ɥ':
                        case 'ɦ':
                        case 'ʮ':
                        case 'ʯ':
                        case 'ḣ':
                        case 'ḥ':
                        case 'ḧ':
                        case 'ḩ':
                        case 'ḫ':
                        case 'ẖ':
                            output[outputPos++] = 'h';
                            continue;
                        case 'ｉ':
                        case 'ⁱ':
                        case 'ⓘ':
                        case 'ì':
                        case 'í':
                        case 'î':
                        case 'ï':
                        case 'ĩ':
                        case 'ī':
                        case 'ĭ':
                        case 'į':
                        case 'ı':
                        case 'ǐ':
                        case 'ȉ':
                        case 'ȋ':
                        case 'ɨ':
                        case 'ᴉ':
                        case 'ᵢ':
                        case 'ᵼ':
                        case 'ᶖ':
                        case 'ḭ':
                        case 'ḯ':
                        case 'ỉ':
                        case 'ị':
                            output[outputPos++] = 'i';
                            continue;
                        case 'ｊ':
                        case 'ⱼ':
                        case 'ⓙ':
                        case 'ĵ':
                        case 'ǰ':
                        case 'ȷ':
                        case 'ɉ':
                        case 'ɟ':
                        case 'ʄ':
                        case 'ʝ':
                            output[outputPos++] = 'j';
                            continue;
                        case 'ｋ':
                        case 'ꝁ':
                        case 'ꝃ':
                        case 'ꝅ':
                        case 'ⱪ':
                        case 'ⓚ':
                        case 'ķ':
                        case 'ƙ':
                        case 'ǩ':
                        case 'ʞ':
                        case 'ᶄ':
                        case 'ḱ':
                        case 'ḳ':
                        case 'ḵ':
                            output[outputPos++] = 'k';
                            continue;
                        case 'ｌ':
                        case 'ꝇ':
                        case 'ꝉ':
                        case 'ꞁ':
                        case 'ⱡ':
                        case 'ⓛ':
                        case 'ĺ':
                        case 'ļ':
                        case 'ľ':
                        case 'ŀ':
                        case 'ł':
                        case 'ƚ':
                        case 'ȴ':
                        case 'ɫ':
                        case 'ɬ':
                        case 'ɭ':
                        case 'ᶅ':
                        case 'ḷ':
                        case 'ḹ':
                        case 'ḻ':
                        case 'ḽ':
                            output[outputPos++] = 'l';
                            continue;
                        case 'ｍ':
                        case 'ⓜ':
                        case 'ɯ':
                        case 'ɰ':
                        case 'ɱ':
                        case 'ᵯ':
                        case 'ᶆ':
                        case 'ḿ':
                        case 'ṁ':
                        case 'ṃ':
                            output[outputPos++] = 'm';
                            continue;
                        case 'ｎ':
                        case 'ⁿ':
                        case 'ⓝ':
                        case 'ñ':
                        case 'ń':
                        case 'ņ':
                        case 'ň':
                        case 'ŉ':
                        case 'ŋ':
                        case 'ƞ':
                        case 'ǹ':
                        case 'ȵ':
                        case 'ɲ':
                        case 'ɳ':
                        case 'ᵰ':
                        case 'ᶇ':
                        case 'ṅ':
                        case 'ṇ':
                        case 'ṉ':
                        case 'ṋ':
                            output[outputPos++] = 'n';
                            continue;
                        case 'ｏ':
                        case 'ꝋ':
                        case 'ꝍ':
                        case 'ⱺ':
                        case '\x2092':
                        case 'ⓞ':
                        case 'ò':
                        case 'ó':
                        case 'ô':
                        case 'õ':
                        case 'ö':
                        case 'ø':
                        case 'ō':
                        case 'ŏ':
                        case 'ő':
                        case 'ơ':
                        case 'ǒ':
                        case 'ǫ':
                        case 'ǭ':
                        case 'ǿ':
                        case 'ȍ':
                        case 'ȏ':
                        case 'ȫ':
                        case 'ȭ':
                        case 'ȯ':
                        case 'ȱ':
                        case 'ɔ':
                        case 'ɵ':
                        case 'ᴖ':
                        case 'ᴗ':
                        case 'ᶗ':
                        case 'ṍ':
                        case 'ṏ':
                        case 'ṑ':
                        case 'ṓ':
                        case 'ọ':
                        case 'ỏ':
                        case 'ố':
                        case 'ồ':
                        case 'ổ':
                        case 'ỗ':
                        case 'ộ':
                        case 'ớ':
                        case 'ờ':
                        case 'ở':
                        case 'ỡ':
                        case 'ợ':
                            output[outputPos++] = 'o';
                            continue;
                        case 'ｐ':
                        case 'ꝑ':
                        case 'ꝓ':
                        case 'ꝕ':
                        case 'ꟼ':
                        case 'ⓟ':
                        case 'ƥ':
                        case 'ᵱ':
                        case 'ᵽ':
                        case 'ᶈ':
                        case 'ṕ':
                        case 'ṗ':
                            output[outputPos++] = 'p';
                            continue;
                        case 'ｑ':
                        case 'ꝗ':
                        case 'ꝙ':
                        case 'ⓠ':
                        case 'ĸ':
                        case 'ɋ':
                        case 'ʠ':
                            output[outputPos++] = 'q';
                            continue;
                        case 'ｒ':
                        case 'ꝛ':
                        case 'ꞃ':
                        case 'ⓡ':
                        case 'ŕ':
                        case 'ŗ':
                        case 'ř':
                        case 'ȑ':
                        case 'ȓ':
                        case 'ɍ':
                        case 'ɼ':
                        case 'ɽ':
                        case 'ɾ':
                        case 'ɿ':
                        case 'ᵣ':
                        case 'ᵲ':
                        case 'ᵳ':
                        case 'ᶉ':
                        case 'ṙ':
                        case 'ṛ':
                        case 'ṝ':
                        case 'ṟ':
                            output[outputPos++] = 'r';
                            continue;
                        case 'ｓ':
                        case 'Ꞅ':
                        case 'ⓢ':
                        case 'ś':
                        case 'ŝ':
                        case 'ş':
                        case 'š':
                        case 'ſ':
                        case 'ș':
                        case 'ȿ':
                        case 'ʂ':
                        case 'ᵴ':
                        case 'ᶊ':
                        case 'ṡ':
                        case 'ṣ':
                        case 'ṥ':
                        case 'ṧ':
                        case 'ṩ':
                        case 'ẜ':
                        case 'ẝ':
                            output[outputPos++] = 's';
                            continue;
                        case 'ｔ':
                        case 'ⱦ':
                        case 'ⓣ':
                        case 'ţ':
                        case 'ť':
                        case 'ŧ':
                        case 'ƫ':
                        case 'ƭ':
                        case 'ț':
                        case 'ȶ':
                        case 'ʇ':
                        case 'ʈ':
                        case 'ᵵ':
                        case 'ṫ':
                        case 'ṭ':
                        case 'ṯ':
                        case 'ṱ':
                        case 'ẗ':
                            output[outputPos++] = 't';
                            continue;
                        case 'ｕ':
                        case 'ⓤ':
                        case 'ù':
                        case 'ú':
                        case 'û':
                        case 'ü':
                        case 'ũ':
                        case 'ū':
                        case 'ŭ':
                        case 'ů':
                        case 'ű':
                        case 'ų':
                        case 'ư':
                        case 'ǔ':
                        case 'ǖ':
                        case 'ǘ':
                        case 'ǚ':
                        case 'ǜ':
                        case 'ȕ':
                        case 'ȗ':
                        case 'ʉ':
                        case 'ᵤ':
                        case 'ᶙ':
                        case 'ṳ':
                        case 'ṵ':
                        case 'ṷ':
                        case 'ṹ':
                        case 'ṻ':
                        case 'ụ':
                        case 'ủ':
                        case 'ứ':
                        case 'ừ':
                        case 'ử':
                        case 'ữ':
                        case 'ự':
                            output[outputPos++] = 'u';
                            continue;
                        case 'ｖ':
                        case 'ꝟ':
                        case 'ⱱ':
                        case 'ⱴ':
                        case 'ⓥ':
                        case 'ʋ':
                        case 'ʌ':
                        case 'ᵥ':
                        case 'ᶌ':
                        case 'ṽ':
                        case 'ṿ':
                            output[outputPos++] = 'v';
                            continue;
                        case 'ｗ':
                        case 'ⱳ':
                        case 'ⓦ':
                        case 'ŵ':
                        case 'ƿ':
                        case 'ʍ':
                        case 'ẁ':
                        case 'ẃ':
                        case 'ẅ':
                        case 'ẇ':
                        case 'ẉ':
                        case 'ẘ':
                            output[outputPos++] = 'w';
                            continue;
                        case 'ｘ':
                        case '\x2093':
                        case 'ⓧ':
                        case 'ᶍ':
                        case 'ẋ':
                        case 'ẍ':
                            output[outputPos++] = 'x';
                            continue;
                        case 'ｙ':
                        case 'ⓨ':
                        case 'ý':
                        case 'ÿ':
                        case 'ŷ':
                        case 'ƴ':
                        case 'ȳ':
                        case 'ɏ':
                        case 'ʎ':
                        case 'ẏ':
                        case 'ẙ':
                        case 'ỳ':
                        case 'ỵ':
                        case 'ỷ':
                        case 'ỹ':
                        case 'ỿ':
                            output[outputPos++] = 'y';
                            continue;
                        case 'ｚ':
                        case 'ꝣ':
                        case 'ⱬ':
                        case 'ⓩ':
                        case 'ź':
                        case 'ż':
                        case 'ž':
                        case 'ƶ':
                        case 'ȝ':
                        case 'ȥ':
                        case 'ɀ':
                        case 'ʐ':
                        case 'ʑ':
                        case 'ᵶ':
                        case 'ᶎ':
                        case 'ẑ':
                        case 'ẓ':
                        case 'ẕ':
                            output[outputPos++] = 'z';
                            continue;
                        case '｛':
                        case '❴':
                            output[outputPos++] = '{';
                            continue;
                        case '｝':
                        case '❵':
                            output[outputPos++] = '}';
                            continue;
                        case '～':
                        case '⁓':
                            output[outputPos++] = '~';
                            continue;
                        case 'Ꜩ':
                            output[outputPos++] = 'T';
                            output[outputPos++] = 'Z';
                            continue;
                        case 'ꜩ':
                            output[outputPos++] = 't';
                            output[outputPos++] = 'z';
                            continue;
                        case 'Ꜳ':
                            output[outputPos++] = 'A';
                            output[outputPos++] = 'A';
                            continue;
                        case 'ꜳ':
                            output[outputPos++] = 'a';
                            output[outputPos++] = 'a';
                            continue;
                        case 'Ꜵ':
                            output[outputPos++] = 'A';
                            output[outputPos++] = 'O';
                            continue;
                        case 'ꜵ':
                            output[outputPos++] = 'a';
                            output[outputPos++] = 'o';
                            continue;
                        case 'Ꜷ':
                            output[outputPos++] = 'A';
                            output[outputPos++] = 'U';
                            continue;
                        case 'ꜷ':
                            output[outputPos++] = 'a';
                            output[outputPos++] = 'u';
                            continue;
                        case 'Ꜹ':
                        case 'Ꜻ':
                            output[outputPos++] = 'A';
                            output[outputPos++] = 'V';
                            continue;
                        case 'ꜹ':
                        case 'ꜻ':
                            output[outputPos++] = 'a';
                            output[outputPos++] = 'v';
                            continue;
                        case 'Ꜽ':
                            output[outputPos++] = 'A';
                            output[outputPos++] = 'Y';
                            continue;
                        case 'ꜽ':
                            output[outputPos++] = 'a';
                            output[outputPos++] = 'y';
                            continue;
                        case 'Ꝏ':
                            output[outputPos++] = 'O';
                            output[outputPos++] = 'O';
                            continue;
                        case 'ꝏ':
                            output[outputPos++] = 'o';
                            output[outputPos++] = 'o';
                            continue;
                        case 'Ꝡ':
                            output[outputPos++] = 'V';
                            output[outputPos++] = 'Y';
                            continue;
                        case 'ꝡ':
                            output[outputPos++] = 'v';
                            output[outputPos++] = 'y';
                            continue;
                        case 'Ꝧ':
                        case 'Þ':
                            output[outputPos++] = 'T';
                            output[outputPos++] = 'H';
                            continue;
                        case 'ꝧ':
                        case 'þ':
                        case 'ᵺ':
                            output[outputPos++] = 't';
                            output[outputPos++] = 'h';
                            continue;
                        case '\x277F':
                        case '\x2789':
                        case '\x2793':
                        case '\x2469':
                        case '\x24FE':
                            output[outputPos++] = '1';
                            output[outputPos++] = '0';
                            continue;
                        case '⸨':
                            output[outputPos++] = '(';
                            output[outputPos++] = '(';
                            continue;
                        case '⸩':
                            output[outputPos++] = ')';
                            output[outputPos++] = ')';
                            continue;
                        case '‼':
                            output[outputPos++] = '!';
                            output[outputPos++] = '!';
                            continue;
                        case '⁇':
                            output[outputPos++] = '?';
                            output[outputPos++] = '?';
                            continue;
                        case '⁈':
                            output[outputPos++] = '?';
                            output[outputPos++] = '!';
                            continue;
                        case '⁉':
                            output[outputPos++] = '!';
                            output[outputPos++] = '?';
                            continue;
                        case '\x246A':
                        case '\x24EB':
                            output[outputPos++] = '1';
                            output[outputPos++] = '1';
                            continue;
                        case '\x246B':
                        case '\x24EC':
                            output[outputPos++] = '1';
                            output[outputPos++] = '2';
                            continue;
                        case '\x246C':
                        case '\x24ED':
                            output[outputPos++] = '1';
                            output[outputPos++] = '3';
                            continue;
                        case '\x246D':
                        case '\x24EE':
                            output[outputPos++] = '1';
                            output[outputPos++] = '4';
                            continue;
                        case '\x246E':
                        case '\x24EF':
                            output[outputPos++] = '1';
                            output[outputPos++] = '5';
                            continue;
                        case '\x246F':
                        case '\x24F0':
                            output[outputPos++] = '1';
                            output[outputPos++] = '6';
                            continue;
                        case '\x2470':
                        case '\x24F1':
                            output[outputPos++] = '1';
                            output[outputPos++] = '7';
                            continue;
                        case '\x2471':
                        case '\x24F2':
                            output[outputPos++] = '1';
                            output[outputPos++] = '8';
                            continue;
                        case '\x2472':
                        case '\x24F3':
                            output[outputPos++] = '1';
                            output[outputPos++] = '9';
                            continue;
                        case '\x2473':
                        case '\x24F4':
                            output[outputPos++] = '2';
                            output[outputPos++] = '0';
                            continue;
                        case '\x2474':
                            output[outputPos++] = '(';
                            output[outputPos++] = '1';
                            output[outputPos++] = ')';
                            continue;
                        case '\x2475':
                            output[outputPos++] = '(';
                            output[outputPos++] = '2';
                            output[outputPos++] = ')';
                            continue;
                        case '\x2476':
                            output[outputPos++] = '(';
                            output[outputPos++] = '3';
                            output[outputPos++] = ')';
                            continue;
                        case '\x2477':
                            output[outputPos++] = '(';
                            output[outputPos++] = '4';
                            output[outputPos++] = ')';
                            continue;
                        case '\x2478':
                            output[outputPos++] = '(';
                            output[outputPos++] = '5';
                            output[outputPos++] = ')';
                            continue;
                        case '\x2479':
                            output[outputPos++] = '(';
                            output[outputPos++] = '6';
                            output[outputPos++] = ')';
                            continue;
                        case '\x247A':
                            output[outputPos++] = '(';
                            output[outputPos++] = '7';
                            output[outputPos++] = ')';
                            continue;
                        case '\x247B':
                            output[outputPos++] = '(';
                            output[outputPos++] = '8';
                            output[outputPos++] = ')';
                            continue;
                        case '\x247C':
                            output[outputPos++] = '(';
                            output[outputPos++] = '9';
                            output[outputPos++] = ')';
                            continue;
                        case '\x247D':
                            output[outputPos++] = '(';
                            output[outputPos++] = '1';
                            output[outputPos++] = '0';
                            output[outputPos++] = ')';
                            continue;
                        case '\x247E':
                            output[outputPos++] = '(';
                            output[outputPos++] = '1';
                            output[outputPos++] = '1';
                            output[outputPos++] = ')';
                            continue;
                        case '\x247F':
                            output[outputPos++] = '(';
                            output[outputPos++] = '1';
                            output[outputPos++] = '2';
                            output[outputPos++] = ')';
                            continue;
                        case '\x2480':
                            output[outputPos++] = '(';
                            output[outputPos++] = '1';
                            output[outputPos++] = '3';
                            output[outputPos++] = ')';
                            continue;
                        case '\x2481':
                            output[outputPos++] = '(';
                            output[outputPos++] = '1';
                            output[outputPos++] = '4';
                            output[outputPos++] = ')';
                            continue;
                        case '\x2482':
                            output[outputPos++] = '(';
                            output[outputPos++] = '1';
                            output[outputPos++] = '5';
                            output[outputPos++] = ')';
                            continue;
                        case '\x2483':
                            output[outputPos++] = '(';
                            output[outputPos++] = '1';
                            output[outputPos++] = '6';
                            output[outputPos++] = ')';
                            continue;
                        case '\x2484':
                            output[outputPos++] = '(';
                            output[outputPos++] = '1';
                            output[outputPos++] = '7';
                            output[outputPos++] = ')';
                            continue;
                        case '\x2485':
                            output[outputPos++] = '(';
                            output[outputPos++] = '1';
                            output[outputPos++] = '8';
                            output[outputPos++] = ')';
                            continue;
                        case '\x2486':
                            output[outputPos++] = '(';
                            output[outputPos++] = '1';
                            output[outputPos++] = '9';
                            output[outputPos++] = ')';
                            continue;
                        case '\x2487':
                            output[outputPos++] = '(';
                            output[outputPos++] = '2';
                            output[outputPos++] = '0';
                            output[outputPos++] = ')';
                            continue;
                        case '\x2488':
                            output[outputPos++] = '1';
                            output[outputPos++] = '.';
                            continue;
                        case '\x2489':
                            output[outputPos++] = '2';
                            output[outputPos++] = '.';
                            continue;
                        case '\x248A':
                            output[outputPos++] = '3';
                            output[outputPos++] = '.';
                            continue;
                        case '\x248B':
                            output[outputPos++] = '4';
                            output[outputPos++] = '.';
                            continue;
                        case '\x248C':
                            output[outputPos++] = '5';
                            output[outputPos++] = '.';
                            continue;
                        case '\x248D':
                            output[outputPos++] = '6';
                            output[outputPos++] = '.';
                            continue;
                        case '\x248E':
                            output[outputPos++] = '7';
                            output[outputPos++] = '.';
                            continue;
                        case '\x248F':
                            output[outputPos++] = '8';
                            output[outputPos++] = '.';
                            continue;
                        case '\x2490':
                            output[outputPos++] = '9';
                            output[outputPos++] = '.';
                            continue;
                        case '\x2491':
                            output[outputPos++] = '1';
                            output[outputPos++] = '0';
                            output[outputPos++] = '.';
                            continue;
                        case '\x2492':
                            output[outputPos++] = '1';
                            output[outputPos++] = '1';
                            output[outputPos++] = '.';
                            continue;
                        case '\x2493':
                            output[outputPos++] = '1';
                            output[outputPos++] = '2';
                            output[outputPos++] = '.';
                            continue;
                        case '\x2494':
                            output[outputPos++] = '1';
                            output[outputPos++] = '3';
                            output[outputPos++] = '.';
                            continue;
                        case '\x2495':
                            output[outputPos++] = '1';
                            output[outputPos++] = '4';
                            output[outputPos++] = '.';
                            continue;
                        case '\x2496':
                            output[outputPos++] = '1';
                            output[outputPos++] = '5';
                            output[outputPos++] = '.';
                            continue;
                        case '\x2497':
                            output[outputPos++] = '1';
                            output[outputPos++] = '6';
                            output[outputPos++] = '.';
                            continue;
                        case '\x2498':
                            output[outputPos++] = '1';
                            output[outputPos++] = '7';
                            output[outputPos++] = '.';
                            continue;
                        case '\x2499':
                            output[outputPos++] = '1';
                            output[outputPos++] = '8';
                            output[outputPos++] = '.';
                            continue;
                        case '\x249A':
                            output[outputPos++] = '1';
                            output[outputPos++] = '9';
                            output[outputPos++] = '.';
                            continue;
                        case '\x249B':
                            output[outputPos++] = '2';
                            output[outputPos++] = '0';
                            output[outputPos++] = '.';
                            continue;
                        case '⒜':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'a';
                            output[outputPos++] = ')';
                            continue;
                        case '⒝':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'b';
                            output[outputPos++] = ')';
                            continue;
                        case '⒞':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'c';
                            output[outputPos++] = ')';
                            continue;
                        case '⒟':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'd';
                            output[outputPos++] = ')';
                            continue;
                        case '⒠':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'e';
                            output[outputPos++] = ')';
                            continue;
                        case '⒡':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'f';
                            output[outputPos++] = ')';
                            continue;
                        case '⒢':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'g';
                            output[outputPos++] = ')';
                            continue;
                        case '⒣':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'h';
                            output[outputPos++] = ')';
                            continue;
                        case '⒤':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'i';
                            output[outputPos++] = ')';
                            continue;
                        case '⒥':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'j';
                            output[outputPos++] = ')';
                            continue;
                        case '⒦':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'k';
                            output[outputPos++] = ')';
                            continue;
                        case '⒧':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'l';
                            output[outputPos++] = ')';
                            continue;
                        case '⒨':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'm';
                            output[outputPos++] = ')';
                            continue;
                        case '⒩':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'n';
                            output[outputPos++] = ')';
                            continue;
                        case '⒪':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'o';
                            output[outputPos++] = ')';
                            continue;
                        case '⒫':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'p';
                            output[outputPos++] = ')';
                            continue;
                        case '⒬':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'q';
                            output[outputPos++] = ')';
                            continue;
                        case '⒭':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'r';
                            output[outputPos++] = ')';
                            continue;
                        case '⒮':
                            output[outputPos++] = '(';
                            output[outputPos++] = 's';
                            output[outputPos++] = ')';
                            continue;
                        case '⒯':
                            output[outputPos++] = '(';
                            output[outputPos++] = 't';
                            output[outputPos++] = ')';
                            continue;
                        case '⒰':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'u';
                            output[outputPos++] = ')';
                            continue;
                        case '⒱':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'v';
                            output[outputPos++] = ')';
                            continue;
                        case '⒲':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'w';
                            output[outputPos++] = ')';
                            continue;
                        case '⒳':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'x';
                            output[outputPos++] = ')';
                            continue;
                        case '⒴':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'y';
                            output[outputPos++] = ')';
                            continue;
                        case '⒵':
                            output[outputPos++] = '(';
                            output[outputPos++] = 'z';
                            output[outputPos++] = ')';
                            continue;
                        case 'Æ':
                        case 'Ǣ':
                        case 'Ǽ':
                        case 'ᴁ':
                            output[outputPos++] = 'A';
                            output[outputPos++] = 'E';
                            continue;
                        case 'ß':
                            output[outputPos++] = 's';
                            output[outputPos++] = 's';
                            continue;
                        case 'æ':
                        case 'ǣ':
                        case 'ǽ':
                        case 'ᴂ':
                            output[outputPos++] = 'a';
                            output[outputPos++] = 'e';
                            continue;
                        case 'Ĳ':
                            output[outputPos++] = 'I';
                            output[outputPos++] = 'J';
                            continue;
                        case 'ĳ':
                            output[outputPos++] = 'i';
                            output[outputPos++] = 'j';
                            continue;
                        case 'Œ':
                        case 'ɶ':
                            output[outputPos++] = 'O';
                            output[outputPos++] = 'E';
                            continue;
                        case 'œ':
                        case 'ᴔ':
                            output[outputPos++] = 'o';
                            output[outputPos++] = 'e';
                            continue;
                        case 'ƕ':
                            output[outputPos++] = 'h';
                            output[outputPos++] = 'v';
                            continue;
                        case 'Ǆ':
                        case 'Ǳ':
                            output[outputPos++] = 'D';
                            output[outputPos++] = 'Z';
                            continue;
                        case 'ǅ':
                        case 'ǲ':
                            output[outputPos++] = 'D';
                            output[outputPos++] = 'z';
                            continue;
                        case 'ǆ':
                        case 'ǳ':
                        case 'ʣ':
                        case 'ʥ':
                            output[outputPos++] = 'd';
                            output[outputPos++] = 'z';
                            continue;
                        case 'Ǉ':
                            output[outputPos++] = 'L';
                            output[outputPos++] = 'J';
                            continue;
                        case 'ǈ':
                            output[outputPos++] = 'L';
                            output[outputPos++] = 'j';
                            continue;
                        case 'ǉ':
                            output[outputPos++] = 'l';
                            output[outputPos++] = 'j';
                            continue;
                        case 'Ǌ':
                            output[outputPos++] = 'N';
                            output[outputPos++] = 'J';
                            continue;
                        case 'ǋ':
                            output[outputPos++] = 'N';
                            output[outputPos++] = 'j';
                            continue;
                        case 'ǌ':
                            output[outputPos++] = 'n';
                            output[outputPos++] = 'j';
                            continue;
                        case 'Ƕ':
                            output[outputPos++] = 'H';
                            output[outputPos++] = 'V';
                            continue;
                        case 'Ȣ':
                        case 'ᴕ':
                            output[outputPos++] = 'O';
                            output[outputPos++] = 'U';
                            continue;
                        case 'ȣ':
                            output[outputPos++] = 'o';
                            output[outputPos++] = 'u';
                            continue;
                        case 'ȸ':
                            output[outputPos++] = 'd';
                            output[outputPos++] = 'b';
                            continue;
                        case 'ȹ':
                            output[outputPos++] = 'q';
                            output[outputPos++] = 'p';
                            continue;
                        case 'ʦ':
                            output[outputPos++] = 't';
                            output[outputPos++] = 's';
                            continue;
                        case 'ʨ':
                            output[outputPos++] = 't';
                            output[outputPos++] = 'c';
                            continue;
                        case 'ʪ':
                            output[outputPos++] = 'l';
                            output[outputPos++] = 's';
                            continue;
                        case 'ʫ':
                            output[outputPos++] = 'l';
                            output[outputPos++] = 'z';
                            continue;
                        case 'ᵫ':
                            output[outputPos++] = 'u';
                            output[outputPos++] = 'e';
                            continue;
                        case 'ẞ':
                            output[outputPos++] = 'S';
                            output[outputPos++] = 'S';
                            continue;
                        case 'Ỻ':
                            output[outputPos++] = 'L';
                            output[outputPos++] = 'L';
                            continue;
                        case 'ỻ':
                            output[outputPos++] = 'l';
                            output[outputPos++] = 'l';
                            continue;
                        default:
                            output[outputPos++] = ch;
                            continue;
                    }
                }
            }

            return new string(output, 0, outputPos);
        }
    }
}
