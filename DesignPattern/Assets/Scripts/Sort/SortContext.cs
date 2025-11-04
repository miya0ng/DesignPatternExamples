using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SortContext<T> : ISortContext<T> where T : class
{
    private List<ISortContext<T>> sorts = new List<ISortContext<T>>();
    public void SetStrategy(ISortContext<T> stratge)
    {
        sorts.Add(stratge);
    }

    public void Sort(T[] collection)
    {
        throw new System.NotImplementedException();
    }
}
