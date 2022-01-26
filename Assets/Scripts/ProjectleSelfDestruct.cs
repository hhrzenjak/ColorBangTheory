using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectleSelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    protected IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }

}
