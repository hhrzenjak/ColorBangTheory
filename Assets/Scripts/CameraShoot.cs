using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class CameraShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public ColorSelector colorSelectorScript;
    
    private float speed = 8.0f;

    private float time = 0.0f;
    private float shootDelay = 0.1f;
    
    private Camera camera;

    private Vector3 shootOffset = new Vector3(0.2f, 0, 0.3f);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (time > shootDelay)
        {
            if (Input.GetMouseButton(0))
            {
                Ray mouseDirectionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                GameObject projectile = Instantiate(projectilePrefab, mouseDirectionRay.origin + shootOffset, Quaternion.Euler(90, 0, 0));
                projectile.GetComponent<Renderer>().material.SetColor("_Color", colorSelectorScript.CurrentColor());
                projectile.GetComponent<Rigidbody>().AddForce(mouseDirectionRay.direction * speed + new Vector3(0.0f, 0.2f, 0.0f));
            }

            time = 0.0f;
        }

        time += Time.deltaTime;

    }
}
