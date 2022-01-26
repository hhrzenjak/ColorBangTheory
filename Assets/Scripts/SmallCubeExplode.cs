using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SmallCubeExplode : MonoBehaviour
{
    public float force = 500f;
    public float explosionRadius = 3f;
    public float upwardsModifier = 3f;

    public Vector3 explosionPosition;
    
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
            rb.AddExplosionForce(force, explosionPosition, explosionRadius, upwardsModifier);
        }
    }
    
    //destroy after some time so there are not too many in the scene
    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(1.2f);
        transform.tag = "Untagged";
        float waitTime = Random.Range(6f, 12f);
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
