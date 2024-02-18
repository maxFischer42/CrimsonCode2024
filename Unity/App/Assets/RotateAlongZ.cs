using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateAlongZ : MonoBehaviour
{
    public float change = -0.5f;
    public float currentZ = 0;
    RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        currentZ += change;
        rect.rotation = Quaternion.Euler(90, 0f, currentZ);
    }
}
