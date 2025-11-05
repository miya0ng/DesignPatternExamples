using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
public class BasicReference : MonoBehaviour
{
    private UniTask uniTask;

    public AssetReference baseCube;

    public void SpawnThings()
    {
        baseCube.InstantiateAsync().ToUniTask().Forget();
    }
}
