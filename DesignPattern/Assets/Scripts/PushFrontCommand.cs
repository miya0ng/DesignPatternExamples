using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PushFrontCommand : ICommand
{
    private List<int> ints = new List<int>();
    private int num;
    public PushFrontCommand(List<int> collection, int number)
    {
        ints = collection;
        num = number;
    }
    public void Execute()
    {
        ints.Insert(0, num);
    }

    public void Undo()
    {
        ints.RemoveAt(0);
    }
}
