using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderFlip : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject slider;
    public LayerMask boundaryLayer;
    public Transform bCheck;
    private Vector3 CurrentPos;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        CurrentPos = new Vector3 (player.transform.position.x-0.3659999f, player.transform.position.y+0.07146013f, 0);

        if (touchingLeft() == true)
        {
            slider.transform.rotation = Quaternion.Euler(0, 180f, 0);
            slider.transform.position = new Vector3(CurrentPos.x+0.7659999f, CurrentPos.y, CurrentPos.z);
        }
        else
        {
            slider.transform.rotation = Quaternion.Euler(0, 0, 0);
            slider.transform.position = CurrentPos;
        }
    }

    public bool touchingLeft()
    {
        return Physics2D.OverlapCircle(bCheck.position, 0.3f, boundaryLayer);
    }
}
