using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FluidController : MonoBehaviour
{
    public Slider fluidSlider;
    public PlayerController playerController;

    public float maxFluid = 100f;
    public float regenRate = 2f;
    public float fluidCost = 30f; 

    void Start()
    {
        fluidSlider.maxValue = maxFluid;
        fluidSlider.value = maxFluid;
    }

    void Update()
    {
        
        if (playerController.webHasBeenPlaced) {
            fluidSlider.value -= fluidCost;
            fluidSlider.value = Mathf.Clamp(fluidSlider.value, 0, maxFluid);
            playerController.webHasBeenPlaced = false;
        }
        else if (fluidSlider.value < maxFluid) {
            fluidSlider.value += regenRate * Time.deltaTime;
            fluidSlider.value = Mathf.Clamp(fluidSlider.value, 0, maxFluid);
        }
    }
}