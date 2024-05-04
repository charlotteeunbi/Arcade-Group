using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 Target;
    public float speed = 1f;
    public bool EnemyInWeb = false;

    //public WebController webController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!EnemyInWeb)
        {
            moveToTarget();
        }
    }

    public void SetTarget(Vector3 target)
    {
        Target = target;
    }

    void moveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Web"))
        {
            Debug.Log("enemy enter web");
            //Debug.Log(webController.webInUse);
        }
        //if (other.CompareTag("Web") && !webController.webInUse)
        if (other.CompareTag("Web"))
        {
            EnemyInWeb = true;
            //webController.webInUse = true;
            transform.position = other.transform.position;
            //TODO: play an animation
        }
    }
    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Web"))
        {
            Debug.Log("enemy exit web");
            Debug.Log(webController.webInUse);
        }
        if (other.CompareTag("Web") && EnemyInWeb)
        {
            EnemyInWeb = false;
            webController.webInUse = false;
            //TODO: stop animation
        }
    }*/


}
