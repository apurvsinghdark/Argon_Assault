using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
    [Tooltip("In m")][SerializeField] float xRange = 5f;
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float xNewPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);


        transform.localPosition = new Vector3(xNewPos, transform.localPosition.y,transform.localPosition.z);
    }
}
