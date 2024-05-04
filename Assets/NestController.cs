using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NestController : MonoBehaviour
{
    public Animator camAnim;

    public Animator nestAnim;
    public Slider nestHealthSlider;

    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        nestHealthSlider.maxValue = maxHealth;
        nestHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Centipede"))
        {
            camAnim.Play("cameraShake");
            nestHealthSlider.value--;
            if (nestHealthSlider.value > (2.0f / 3.0f) * nestHealthSlider.maxValue)
            {
                nestAnim.Play("NestFullHealth");
            }
            else if (nestHealthSlider.value > (1.0f / 3.0f) * nestHealthSlider.maxValue)
            {
                nestAnim.Play("NestTwoThirdsHealth");
            }
            else
            {
                nestAnim.Play("NestOneThirdHealth");
            }


            /*switch (nestHealthSlider.value)
            {
                case 3:
                    nestAnim.Play("NestFullHealth");
                    break;
                case 2:
                    nestAnim.Play("NestTwoThirdsHealth");
                    break;
                case 1:
                    nestAnim.Play("NestOneThirdHealth");
                    break;
            }*/
            if (nestHealthSlider.value <= 0)
            {
                //TODO: go to death scene
            }
        }
    }
}
