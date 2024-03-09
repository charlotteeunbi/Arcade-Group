using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebController : MonoBehaviour
{
    public Slider webHealthSlider;


    public float webLife = 20f;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        webHealthSlider.maxValue = webLife;
        webHealthSlider.value = webLife;
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= webLife) {
            Destroy(gameObject);
        }
        else {
            webHealthSlider.value = webLife - time;
        }
    }
}
