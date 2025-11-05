using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SelfDestruct : MonoBehaviour
{
    public float lifeTime = 2f;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnDestroy()
    {
        Debug.Log(gameObject);
        Addressables.ReleaseInstance(gameObject);
        //자동으로 디스트로이 되면 참조카운트 안빠져서 ondestroy에서 releaseInstance로 참조카운트 내림
    }
}
