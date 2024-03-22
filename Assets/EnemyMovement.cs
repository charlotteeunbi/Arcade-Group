using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 Target;
    public float speed = 1f;
    private bool EnemyInWeb = false;

    public WebController webController;

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
        if (other.CompareTag("Web") && !webController.webInUse)
        {
            EnemyInWeb = true;
            webController.webInUse = true;
            transform.position = other.transform.position;
            //TODO: play an animation
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Web"))
        {
            EnemyInWeb = false;
            webController.webInUse = false;
            //TODO: stop animation
        }
    }


}
