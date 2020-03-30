﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PirateBehavior : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private bool checkCooldown = false;
    private float distance;
    private bool isAtking = false;
    [SerializeField]private bool isDodging = false;
    [SerializeField]private int behavior;
    private NavMeshAgent nav;
    private bool isDead = false;
    private Animator anim;
    private float dodgeSpeed = 3;
    private Rigidbody rigid;
    private Transform tp;
    private int dodgeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tp = GameObject.FindGameObjectWithTag("TP").transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        CheckDistance();
        if(isDodging==true)
        {
            transform.Translate(Vector3.back * dodgeSpeed * Time.deltaTime);
    
        }

        if (checkCooldown == false && isAtking == false)
        {
            StartCoroutine("RandomCheck");
        }



        if (distance >= 5 && isDead == false && behavior >= 50 && isAtking==false)
        {
            StartCoroutine("Shoot");
        }

        if(distance<5 && isDead==false&& behavior<50 && isAtking==false&& isDodging==false && dodgeCount<3)
        {
            StartCoroutine("Dodge");
        }
        if (distance < 5 && isDead == false && behavior < 90 && isAtking == false && isDodging == false && dodgeCount>=3)
        {
            StartCoroutine("Smoke");
        }
    }

    private void CheckDistance()
    {
        this.distance = Vector3.Distance(transform.position, player.transform.position);
    }

    IEnumerator RandomCheck()
    {

        checkCooldown = true;

        behavior = Random.Range(0, 100);
        yield return new WaitForSeconds(2.5f);
        checkCooldown = false;


    }
    IEnumerator Shoot()
    {
        isAtking = true;
        anim.SetTrigger("Atk");
        yield return new WaitForSeconds(3f);
        isAtking = false;
    }

    IEnumerator Dodge()
    {
        isDodging = true;
        anim.SetTrigger("BackDodge");
        yield return new WaitForSeconds(1.2f);
        isDodging = false;
        dodgeCount += 1;
    }

    IEnumerator Smoke()
    {
        yield return new WaitForSeconds(1f);
        transform.position = tp.position;
        dodgeCount = 0;
    }
}
