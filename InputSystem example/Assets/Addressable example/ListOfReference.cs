using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ListOfReference : MonoBehaviour
{
    public List<AssetReference> shapes;
    public List<GameObject> cachedShapes;
    private bool isReady = false;
    private int currentIndex = 0;

    private async UniTaskVoid Start()
    {
        await LoadAllShape();
    }

    private void OnDestroy()
    {
        foreach (var shape in shapes)
        {
            shape.ReleaseAsset();
        }
    }

    private async UniTask LoadAllShape()
    {
        var loadTasks = new List<UniTask<GameObject>>();

        foreach (var shape in shapes)
        {
            var task = shape.LoadAssetAsync<GameObject>().ToUniTask();
            loadTasks.Add(task);
        }

        var loadedAssets = await UniTask.WhenAll(loadTasks);

        cachedShapes = new List<GameObject>(loadedAssets);

        isReady = true;
        Debug.Log($"모든 에셋 로드 완료 총 {cachedShapes.Count}개");
    }

    public void SpawnThing()
    {
        if (!isReady || cachedShapes.Count == 0)
        {
            Debug.LogWarning("에셋 로드x");
            return;
        }

        GameObject spawnedObject = Instantiate(cachedShapes[currentIndex]);

        spawnedObject.transform.position = new Vector3(
            UnityEngine.Random.Range(-5f, 5f),
            0,
            UnityEngine.Random.Range(-5f, 5f)
        );

        Debug.Log($"{currentIndex}번 오브젝트");

        currentIndex = (currentIndex + 1) % cachedShapes.Count;
    }
}