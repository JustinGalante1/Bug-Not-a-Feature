﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    private Light l;
    private IntermittentLight flicker;
    private Renderer myRenderer;
    private Material mat;

    private bool hit;

    private void Start()
    {
        l = this.GetComponentInChildren<Light>();
        flicker = this.GetComponentInChildren<IntermittentLight>();
        myRenderer = this.GetComponent<Renderer>();
        mat = myRenderer.material;

        flicker.enabled = false;

        hit = false;
    }

    private void Update()
    {
        if (hit && flicker.enabled == false)
        {
            flicker.enabled = true;
            flicker.randomized = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hit == false)
        {
            hit = true;
        }
    }
}
