using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeController : MonoBehaviour
{

    public float speed = 3f;
    public Rigidbody2D rb;
    public Animator anim;
   // public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = Vector3.zero;
        Vector2 direction = (target - transform.position).normalized;

        rb.velocity = direction * speed;

        if (direction != Vector2.zero) {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }

   
        anim.SetFloat("Speed", rb.velocity.magnitude);


    }
}
