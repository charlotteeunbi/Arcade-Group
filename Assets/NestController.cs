using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NestController : MonoBehaviour
{
    public Animator camAnim;

    public Animator nestAnim;
    public Slider nestHealthSlider;

    public int maxHealth;
    public Color green;
    public Color yellow;
    public Color red;
    public Image image;
    public AudioSource hurtnest;
    


    // Start is called before the first frame update
    void Start()
    {
        nestHealthSlider.maxValue = maxHealth;
        nestHealthSlider.value = maxHealth;
        image.color = green;
    }

    // Update is called once per frame
    void Update()
    {
        if (nestHealthSlider.value == 0) {
            StartCoroutine(deathTime());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Centipede"))
        {
            camAnim.Play("cameraShake");
            hurtnest.Play();
            nestHealthSlider.value--;
            if (nestHealthSlider.value > (2.0f / 3.0f) * nestHealthSlider.maxValue)
            {
                nestAnim.Play("NestFullHealth");
            }
            else if (nestHealthSlider.value > (1.0f / 3.0f) * nestHealthSlider.maxValue)
            {
                nestAnim.Play("NestTwoThirdsHealth");
                image.color = yellow;
            }
            else
            {
                nestAnim.Play("NestOneThirdHealth");
                image.color = red;            }


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

    IEnumerator deathTime() {
        
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("DeathScene");

    }
}
