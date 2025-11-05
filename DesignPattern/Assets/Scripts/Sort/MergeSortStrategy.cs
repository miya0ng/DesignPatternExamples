using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MergeSortStrategy<T> : ISortContext<T>, IComparer<T>
{
    private T[] dividedCollection;
    private T[] parts;

    public int Compare(T x, T y)
    {
        throw new System.NotImplementedException();
    }

    public void Divide(T[] collection)
    {
        //if (collection.Length <= 1) return false;
        //dividedCollection = new T[collection.Length];

        //int middleIndex = collection.Length - 1 / 2;

        //for (int i = 0; i < collection.Length; i++)
        //{
        //    if (i < middleIndex)
        //        dividedCollection[i] = collection[i];

        //    if (i >= middleIndex)
        //        dividedCollection[i] = collection[i];
        //}
        
        //Divide(dividedCollection);
        //return true;
    }
    public void SetStrategy(ISortContext<T> stratge)
    {
        throw new System.NotImplementedException();
    }

    public void Sort(T[] collection)
    {
       //while (Divide(collection))
       // {

       // }
    }
}
