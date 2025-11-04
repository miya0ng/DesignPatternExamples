using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PushBackCommand : ICommand
{
    private List<int> collection;
    private int number;
    public PushBackCommand(List<int> collection, int num)
    {
        this.collection = collection;
        number = num;
    }
    public void Execute()
    {
        collection.Add(number);
    }

    public void Undo()
    {
        collection.RemoveAt(collection.Count - 1);
    }
}

