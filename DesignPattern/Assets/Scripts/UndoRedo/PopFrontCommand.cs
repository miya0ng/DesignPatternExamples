using System.Collections.Generic;
using UnityEngine;

public class PopFrontCommand : ICommand
{
    private List<int> collection;
    private int number;
    private int pushInt;
    public PopFrontCommand(List<int> collection)
    {
        this.collection = collection;
    }

    public void Execute()
    {
        pushInt = collection[0];
        collection.RemoveAt(0);
    }

    public void Undo()
    {
        collection.Insert(0, pushInt);
    }
}
