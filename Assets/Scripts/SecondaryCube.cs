using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEngine;

public abstract class SecondaryCube : MonoBehaviour
{
    private MaterialPropertyBlock propBlock;
    private Renderer _renderer;
    private bool isDarkened = false;

    private float blinkTimer = 3.0f;
    private float countdownTime = 3.0f;

    private float explodeTimer = 3.0f;
    private bool isActivated = false;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        propBlock = new MaterialPropertyBlock();
        _renderer.GetPropertyBlock(propBlock);
        propBlock.SetColor("_Color", _renderer.material.color);
        _renderer.SetPropertyBlock(propBlock);

    }

    private void Update()
    {
        explodeTimer -= Time.deltaTime;
        if (explodeTimer < 0.0f && !isActivated)
        {
            ExplodeFunction();
            isActivated = true;
            _renderer.GetPropertyBlock(propBlock);
            Color color = propBlock.GetVector("_Color");
            if (isDarkened)
            {
                color *= 2.0f;
                isDarkened = false;
            }
            if (!isDarkened)
            {
                color *= 0.5f;
                isDarkened = true;
            }
            propBlock.SetColor("_Color", color);
            _renderer.SetPropertyBlock(propBlock);
        }
        else
        {
            var interval = 0.4f + blinkTimer / countdownTime * (1.0f - 0.4f); //in brackets max - min interval
            blinkTimer -= Time.deltaTime;
            _renderer.GetPropertyBlock(propBlock);
            Color color = propBlock.GetVector("_Color");
            if (Mathf.PingPong(Time.time, interval) > (interval / 2.0f))
            {
                if (isDarkened)
                {
                    color *= 2.0f;
                    isDarkened = false;
                }
            }
            else
            {
                if (!isDarkened)
                {
                    color *= 0.5f;
                    isDarkened = true;
                }
            }

            propBlock.SetColor("_Color", color);
            _renderer.SetPropertyBlock(propBlock);
        }

    }

    protected IEnumerator SelfDestruct(float delay)
    {
        yield return new WaitForSeconds(delay + 3f);
        Destroy(gameObject);
    }

    protected abstract void ExplodeFunction();

}
