using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallOrangeCube : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Explode());
        StartCoroutine(SelfDestruct());
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.2f);
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 randomVector = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f));
            GetComponent<Rigidbody>().AddForce(Vector3.up + randomVector, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce((Vector3.up + randomVector) * 2.0f, ForceMode.Force);
        }
    }
    
    //destroy after some time so there are not too many in the scene
    private IEnumerator SelfDestruct()
    {
        float waitTime = Random.Range(15f, 25f);
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
