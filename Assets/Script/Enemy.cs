using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyFx;
    [SerializeField] Transform parent;

    [SerializeField] int scoreInc = 12;
    //[SerializeField] int enemyHealth = 100;
    [SerializeField] int hits = 10;
  
    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddBoxColliderWithOutTrigger();
    }

    private void AddBoxColliderWithOutTrigger()
    {
        Collider addBoxCollider = gameObject.AddComponent<BoxCollider>();
        addBoxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreTextInc(scoreInc);
        hits--;
        if (hits <= 1)
        {
            KillEnemy();
        }
    }
    private void KillEnemy()
    {
        
        GameObject fx = Instantiate(enemyFx, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(this.gameObject);
    }
}
