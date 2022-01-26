using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCubes : MonoBehaviour
{
    private float timer = 0.0f;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    public TextMeshProUGUI numberOfCubesDisplay;

    public List<Transform> spawnPoints;

    public ColorSelector colorSelectorScript;

    // Update is called once per frame
    void Update()
    {
        
        if (timer > 0.3f && transform.childCount <= 200)
        {
            int color = Random.Range(0, 3);


            if (color == 0)
            {
                instantiateCube(prefab1);
            }
            else if(color == 1)
            {
                instantiateCube(prefab2);
            }
            else if(color == 2)
            {
                instantiateCube(prefab3);
            }
            timer = 0.0f;
        }

        timer += Time.deltaTime;
        numberOfCubesDisplay.text = transform.childCount.ToString();
    }

    public void instantiateCube(GameObject prefab)
    {
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[randomIndex];
        
        Vector3 randomVector = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f)); 
        
        GameObject newCube = Instantiate(prefab, spawnPoint.position + randomVector, Quaternion.identity, transform);

        float scaleX = Random.Range(0.5f, 3.5f);
        float scaleY = Random.Range(0.5f, 3.5f);
        float scaleZ = Random.Range(0.5f, 3.5f);
        newCube.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        newCube.GetComponent<ChangeColorOnHit>().colorSelectorScript = colorSelectorScript;
    }
}
