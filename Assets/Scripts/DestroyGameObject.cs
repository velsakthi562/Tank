using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    [SerializeField]
    private float destroyGameObjectAfter;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyGO());
    }

    IEnumerator DestroyGO()
    {
        yield return new WaitForSeconds(destroyGameObjectAfter);
        Destroy(gameObject);
    }
}
