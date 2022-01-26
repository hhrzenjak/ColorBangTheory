using System;
using UnityEditor.UIElements;
using UnityEngine;

public class ChangeColorOnHit : MonoBehaviour
{
    public GameObject orangeCube;
    public GameObject greenCube;
    public GameObject purpleCube;

    private int hitPoints = 5;

    private String currentColor = "Yellow";
    private MaterialPropertyBlock propBLock;
    private Renderer _renderer;
    private bool isDarkened = false;
    private bool isHit = false;

    private float timer = 5.0f;
    private float countdownTime = 5.0f;

    private String secondaryColor = null;

    public ColorSelector colorSelectorScript;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        propBLock = new MaterialPropertyBlock();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
        if (!isHit && other.transform.CompareTag("Projectile"))
        {
            currentColor = colorSelectorScript.CurrentColorByName();
            if (transform.CompareTag("Red Cube"))
            {
                switch (currentColor)
                {
                    case "Yellow":
                        hitPoints -= 1;
                        if (hitPoints <= 0) ChangeCube(orangeCube);
                        break;
                    case "Blue":
                        hitPoints -= 1;
                        if (hitPoints <= 0) ChangeCube(purpleCube);
                        break;
                }
            }
            else if (transform.CompareTag("Blue Cube"))
            {
                switch (currentColor)
                {
                    case "Yellow":
                        hitPoints -= 1;
                        if (hitPoints <= 0) ChangeCube(greenCube);
                        break;
                    case "Red":
                        hitPoints -= 1;
                        if (hitPoints <= 0) ChangeCube(purpleCube);
                        break;
                }
            }
            else if (transform.CompareTag("Yellow Cube"))
            {
                switch (currentColor)
                {
                    case "Blue":
                        hitPoints -= 1;
                        if (hitPoints <= 0) ChangeCube(greenCube);
                        break;
                    case "Red":
                        hitPoints -= 1;
                        if (hitPoints <= 0) ChangeCube(orangeCube);
                        break;
                }
            }


            Destroy(other.gameObject);
            if (hitPoints <= 0) Destroy(gameObject);
        }
    }


    private void ChangeCube(GameObject secondaryCube)
    {
        GameObject newCube = Instantiate(secondaryCube, transform.position, Quaternion.identity);
        newCube.transform.localScale = transform.localScale;
    }
}