namespace Tranzact.SearchFight.Common.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Helpers for delimited string, with quotes mark character.
    /// </summary>
    public static class DelimitedString
    {
        public static string[] Split(string source)
        {
            return Regex.Matches(source, @"[\""].+?[\""]|[^ ]+")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray();
        }
    }
}
