using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject webPrefab;
    public float webPlacementTime = 2f;
    private float currentTime = 0f;
    public PlayerMovement movement;

    private bool isPlacingWeb = false;
    private bool isInWeb = false;

    // Update is called once per frame
    void Update()
    {
        isPlacingWeb = Input.GetKey(KeyCode.Space);
        if (isPlacingWeb)
        {
            //movement.moveSpeed = 2f;
            currentTime += Time.deltaTime;
            if (currentTime >= webPlacementTime)
            {
                PlaceWeb();
                currentTime = 0f;
            }
        }
        else
        {
            //movement.moveSpeed = 5f;
            currentTime = 0f;
        }

        handleSpeed();
    }

    void PlaceWeb()
    {
        Instantiate(webPrefab, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Web"))
        {
            //Debug.Log("Enter Web Collision");
            isInWeb = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Web"))
        {
            //Debug.Log("Exit Web Collision");
            isInWeb = false;
        }
    }

    void handleSpeed()
    {
        float modifier = 1;
        if (isPlacingWeb)
        {
            modifier *= 0.3f;
        }
        if (isInWeb)
        {
            modifier *= 0.5f;
        }
        //Debug.Log(modifier);
        movement.moveSpeed = 5 * modifier;
    }
}
