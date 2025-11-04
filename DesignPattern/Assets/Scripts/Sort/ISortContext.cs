using System.Collections.Generic;
using System.Xml.Serialization;

public interface ISortContext<T>
{
    public void SetStrategy(ISortContext<T> stratge);

    public void Sort(T[] collection);

}