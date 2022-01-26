using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelector : MonoBehaviour
{
    public int currentColorIndex = 0;
    public RectTransform revolver;
    private String[] possibleColorsNames = {"Yellow", "Red", "Blue"};
    private Color[] possibleColors = {Colors.Yellow, Colors.Red, Colors.Blue};
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            {
                currentColorIndex = (currentColorIndex + 1);
                if (currentColorIndex > possibleColorsNames.Length - 1) currentColorIndex = 0;
                revolver.Rotate(0,0,120);
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
                currentColorIndex = (currentColorIndex - 1); 
                if (currentColorIndex < 0) currentColorIndex = possibleColorsNames.Length - 1;
                revolver.Rotate(0,0,-120);
            }
            
            //gameObject.GetComponent<Image>().color = CurrentColor();
        }

        
    }

    public String CurrentColorByName()
    {
        return possibleColorsNames[currentColorIndex];
    }
    
    public Color CurrentColor()
    {
        return possibleColors[currentColorIndex];
    }
}
