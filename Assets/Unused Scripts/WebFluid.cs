using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebFluid : MonoBehaviour
{
    public GameObject dynamicBar;
    public float maxFluid = 100f;
    public float regenRate = 5f;
    public float webCost = 15f;

    public PlayerController playerController;

    private float currentFluid;
    private Vector3 originalScale;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentFluid = maxFluid;
        originalScale = dynamicBar.transform.localScale;
        originalPosition = dynamicBar.transform.localPosition;
        updateBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFluid < maxFluid)
        {
            currentFluid += regenRate * Time.deltaTime;
            currentFluid = Mathf.Min(maxFluid, currentFluid);
        }
        if (currentFluid >= webCost && playerController.isPlacingWeb)
        {
            useFluid(webCost);
        }

        updateBar();
    }

    public void useFluid(float amount)
    {
        currentFluid -= amount * Time.deltaTime;
        currentFluid = Mathf.Max(0, currentFluid);
        updateBar();
    }

    private void updateBar()
    {
        //currentFluid / maxFluid * number of frames
        float ratio = currentFluid / maxFluid;
        dynamicBar.transform.localScale = new Vector3(originalScale.x, originalScale.y * ratio, originalScale.z);
        dynamicBar.transform.localPosition = new Vector3(originalPosition.x, originalPosition.y - originalScale.y * ratio, originalPosition.z);
    }
}
