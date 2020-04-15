﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitboxthird : MonoBehaviour
{
    private bool onlyonce = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerStats>().isInvince == false && onlyonce == false)
        {
            onlyonce = true;
            Debug.Log("Ouch");
            if (other.GetComponent<PlayerStats>().super == false)
            {
                other.GetComponent<Animator>().SetTrigger("Falling");
                other.GetComponent<PlayerStats>().GettingUp();
            }
            other.GetComponent<PlayerStats>().TakeDamage(20);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

}
