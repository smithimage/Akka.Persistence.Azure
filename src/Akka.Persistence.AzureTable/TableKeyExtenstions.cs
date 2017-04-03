using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Akka.Persistence.AzureTable
{
    public static class TableKeyExtenstions
    {
        private static readonly Regex DisallowedCharsInTableKeys = new Regex(@"[\\\\#%+/?\u0000-\u001F\u007F-\u009F]", RegexOptions.Compiled);

        public static string ReplaceDisallowedChars(this string key, string replaceWith = "-")
        {
            return DisallowedCharsInTableKeys.Replace(key, replaceWith);
        }
    }
}
