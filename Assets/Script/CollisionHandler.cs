using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In Seconds")] [SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX preFeb on Player")][SerializeField] GameObject deathFx;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathReference();
        deathFx.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void StartDeathReference()
    {
       // print("Death");
        SendMessage("OnPlayerDeath");
    }

    void ReloadScene() //String Referenced
    {
        SceneManager.LoadScene(1);
    }    
}
