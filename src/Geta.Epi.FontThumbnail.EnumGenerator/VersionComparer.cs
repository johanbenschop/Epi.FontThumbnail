using System;
using System.Collections.Generic;
using System.Linq;

namespace Geta.Epi.FontThumbnail.EnumGenerator
{
    internal class VersionComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == y) return 0;

            var version = (First: GetVersion(x), Second: GetVersion(y));
            var limit = Math.Max(version.First.Length, version.Second.Length);

            for (var i = 0; i < limit; i++)
            {
                var first = version.First.ElementAtOrDefault(i);
                var second = version.Second.ElementAtOrDefault(i);
                if (first > second) return 1;
                if (second > first) return -1;
            }

            return 0;
        }

        private static int[] GetVersion(string version)
        {
            return (from part in version.Split('.')
                select int.Parse(part)).ToArray();
        }
    }
}
