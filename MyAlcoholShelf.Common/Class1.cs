using System;
using System.Collections.Generic;

namespace MyAlcoholShelf.Common
{
    public static class ISetHelpers
    {
        public static ISet<T> EnsureExists<T>(ISet<T> set)
        {
            return set ?? new HashSet<T>();
        }
    }
}
