using System.Collections.Generic;
using UnityEngine;

public class IntListManager : MonoBehaviour
{
    [Header("테스트 설정")]
    [SerializeField] private int numberToAdd = 10;

    private List<int> intList = new List<int>();
    private CommandInvoker invoker = new CommandInvoker();

    private void Start()
    {
        Debug.Log("=== 커맨드 패턴 Undo/Redo 연습 시작 ===");
        PrintList();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.W))
        {
            ExecutePushBack();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.S))
        {
            ExecutePopBack();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.D))
        {
            PrintList();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Z))
        {
            ExecuteUndo();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.X))
        {
            ExecuteRedo();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ExecutePushFront();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            ExecutePopFront();
        }
    }

    private void ExecutePushBack()
    {
        ICommand command = new PushBackCommand(intList, numberToAdd);
        invoker.ExecuteCommand(command);
        numberToAdd += 10;
    }
    private void ExecutePushFront()
    {
        ICommand command = new PushFrontCommand(intList, numberToAdd);
        invoker.ExecuteCommand(command);
        numberToAdd += 10;
    }

    private void ExecutePopBack()
    {
        ICommand command = new PopBackCommand(intList);
        invoker.ExecuteCommand(command);
    }
    private void ExecutePopFront()
    {
        ICommand command = new PopFrontCommand(intList);
        invoker.ExecuteCommand(command);
    }

    private void ExecuteUndo()
    {
        if (invoker.CanUndo())
        {
            invoker.Undo();
            Debug.Log("<color=cyan> Undo</color>");
            PrintList();
        }
        else
        {
            Debug.LogWarning("Undo할 명령이 없습니다!");
        }
    }

    private void ExecuteRedo()
    {
        if (invoker.CanRedo())
        {
            invoker.Redo();
            Debug.Log("<color=magenta> Redo</color>");
            PrintList();
        }
        else
        {
            Debug.LogWarning("Redo할 명령이 없습니다!");
        }
    }

    private void PrintList()
    {
        Debug.Log($"현재 리스트: [{string.Join(", ", intList)}] (개수: {intList.Count})");
    }
}
