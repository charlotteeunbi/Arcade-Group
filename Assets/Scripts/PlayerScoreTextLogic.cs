using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreTextLogic : MonoBehaviour
{
    public FluidController fluidController;
    public TextMeshProUGUI textComponent;

    // Update is called once per frame
    void Update()
    {
        textComponent.text = "Web Fluid: " + ((int)fluidController.fluidSlider.value).ToString();
    }
}
