﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public int damage = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy"){
            EnemyHealthManager  enemyHealth;
            enemyHealth = other.gameObject.GetComponent<EnemyHealthManager>();
            enemyHealth.TakeDamage(damage);
        }
    }
}
