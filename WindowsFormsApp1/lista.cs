using System;
using System.Collections.Generic;

namespace Lista
{
    public class ClassTemplateList<T> : List<T> where T : IComparable
    {
        public static ClassTemplateList<T> operator +(ClassTemplateList<T> mult, T t)
        {
            mult.Add(t);
            return mult;
        }

        public override string ToString()
        {
            Sort();
            string m = "";
            foreach (T t in this)
            {
                m += $"{t}";
            }
            return m;
        }
    }
}
