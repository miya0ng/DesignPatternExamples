using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopBackCommand : ICommand
{
    private List<int> collection;
    private int number;
    private int pushInt;
    public PopBackCommand(List<int> collection)
    {
        this.collection = collection;
    }

    public void Execute()
    {
        pushInt = collection[collection.Count - 1];
        collection.RemoveAt(collection.Count - 1);
    }

    public void Undo()
    {
        collection.Add(pushInt);
    }
}