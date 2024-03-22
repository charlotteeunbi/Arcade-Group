using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebController : MonoBehaviour
{
    public Slider webHealthSlider;


    public float webLife = 20f;
    private float time = 0f;

    public bool webInUse = false;

    public EnemyMovement enemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        webHealthSlider.maxValue = webLife;
        webHealthSlider.value = webLife;
        webInUse = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= webLife) {
            Destroy(gameObject);
            webInUse = false;
            enemyMovement.EnemyInWeb = false;
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
}
