using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebController : MonoBehaviour
{
    public Slider webHealthSlider;
    private FluidController fluidController; //the player's fluid controller

    public float webLife;
    private float time = 0f;
    public float webDamage; //how much the web gets damaged by

    //public bool webInUse = false;

    //public EnemyMovement enemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        webHealthSlider.maxValue = webLife;
        webHealthSlider.value = webLife;
        //webInUse = false;

        fluidController = GameObject.Find("Player").GetComponent<FluidController>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= webLife) {
            Destroy(gameObject);
            //webInUse = false;
            //enemyMovement.EnemyInWeb = false;
            //Debug.Log("Setting EnemyInWeb to false");
        }
        else {
            webHealthSlider.value = webLife - time;
        }


    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Web collide with enemy");
            if (!webInUse)
            {
                webInUse = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            webInUse = false;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Centipede"))
        {
            fluidController.fluidSlider.value += fluidController.fluidCost * 0.6f; //add back some web fluid

            time += webDamage;
            if (time >= webLife)
            {
                StartCoroutine(WebGone());
            }
            else
            {
                webHealthSlider.value = webLife - time;
            }
        }
    }
   
   IEnumerator WebGone() {

        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
   }
}
