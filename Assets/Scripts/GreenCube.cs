using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class GreenCube : SecondaryCube
{
    public int cubesPerAxis = 5;
    public GameObject smallCube;

    private Vector3 firstCubePosition;

    protected override void ExplodeFunction()
    {
        firstCubePosition = transform.position - transform.localScale / 2 + (transform.localScale / cubesPerAxis) / 2;
        for (int x = 0; x < cubesPerAxis; x++)
        {
            for (int y = 0; y < cubesPerAxis; y++)
            {
                for (int z = 0; z < cubesPerAxis; z++)
                {
                    CreateSmallCube(new Vector3(x, y, z));
                }
            }
        }
        
        Destroy(gameObject);

    }

    private void CreateSmallCube(Vector3 position)
    {
        GameObject newCube = Instantiate(smallCube);
        newCube.transform.localScale = transform.localScale / cubesPerAxis;

        newCube.transform.position = firstCubePosition + Vector3.Scale(position, newCube.transform.localScale);
        newCube.GetComponent<SmallCubeExplode>().explosionPosition = transform.position;
    }
}
