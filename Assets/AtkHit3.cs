﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkHit3 : MonoBehaviour
{
    private bool onlyOnce = false;
    [SerializeField] private PlayerStats stats;

    public void OnTriggerEnter(Collider other)
    {
        if (!onlyOnce)
        {
            if (other.tag == "Target")
            {
                onlyOnce = true;
                
                other.GetComponent<EnemyStats>().TakeDamage(stats.playerAtk);
                if(stats.super==true)
                {
                    stats.LifeVamp();
                }
                Debug.Log("hit");
                Destroy(gameObject);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        Destroy(gameObject, 1.3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}