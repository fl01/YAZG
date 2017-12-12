using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float destroyAfterInSeconds = 4;

    void Start()
    {
        Destroy(gameObject, destroyAfterInSeconds);
    }
}
