using System;
using System.Collections;   
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float movementSpeed = 4f;
    [Tooltip("In m")][SerializeField] float xRange = 5f;
    [Tooltip("In m")][SerializeField] float yRange = 5f;

    [Header("Control-Positional Factor")]
    [SerializeField] float positionalPitchFactor = -5f;
    [SerializeField] float positionalYawFactor = 5f;
    [SerializeField] float controlFactor = -29f;

    float xThrow, yThrow;

    bool isControlEnabled = true;

    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    void OnPlayerDeath() // Called By String Reference
    {
        isControlEnabled = false;   
    }
    private void ProcessRotation()
    {
        float pitchDueToYposition = transform.localPosition.y * positionalPitchFactor + yThrow * controlFactor;
        //float pitchDueToXposition = transform.localPosition.x * positionalFactor + xThrow * controlFactor;
        float pitch = pitchDueToYposition;
        float yaw = transform.localPosition.x * positionalYawFactor;
        float roll = xThrow * controlFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        yThrow = Input.GetAxis("Vertical");
        xThrow = Input.GetAxis("Horizontal");
        float xOffset = xThrow * movementSpeed * Time.deltaTime;
        float yOffset = yThrow * movementSpeed * Time.deltaTime;
        float xNewPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);
        float yNewPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);

        transform.localPosition = new Vector3(xNewPos, yNewPos, transform.localPosition.z);
    }
}
