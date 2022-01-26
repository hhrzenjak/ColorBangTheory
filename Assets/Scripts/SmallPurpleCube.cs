using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPurpleCube : MonoBehaviour
{
    private int randDir;
    private Vector3[] directions =
    {
        Vector3.up, -Vector3.up, Vector3.forward, -Vector3.forward, Vector3.right, -Vector3.right
    };

    void Start()
    {
        StartCoroutine(Explode());
        StartCoroutine(Return());
        StartCoroutine(SelfDestruct());
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.2f);
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        { 
            randDir = Random.Range(0, directions.Length);
            GetComponent<Rigidbody>().AddForce(directions[randDir] * 8.0f, ForceMode.Impulse);
            //GetComponent<Rigidbody>().AddForce(directions[randDir] * 50.0f, ForceMode.Acceleration);
        }
    }
    
    private IEnumerator Return()
    {
        yield return new WaitForSeconds(3.5f);
        GetComponent<Rigidbody>().AddForce(-directions[randDir] * (8.0f * 2.0f), ForceMode.Impulse);

    }
    
    
    //destroy after some time so there are not too many in the scene
    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(12);
        Destroy(gameObject);
    }
}
