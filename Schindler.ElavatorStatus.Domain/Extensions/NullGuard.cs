using System;
using System.Collections.Generic;
using System.Linq;

namespace Schindler.ElavatorStatus.Domain.Extensions
{
    public static class NullGuard
    {
        public static string IfNotNullOrEmpty(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException();
            }

            return str;
        }
        public static T IfNotNull<T>(this T obj) where T : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            return obj;
        }
        public static IEnumerable<T> IfNotNullOrEmpty<T>(this IEnumerable<T> obj) where T : class
        {
            if (obj == null || !obj.Any())
            {
                throw new ArgumentException();
            }

            return obj;
        }
    }
}
