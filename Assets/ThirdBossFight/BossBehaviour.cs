using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossBehaviour : MonoBehaviour
{
    private NavMeshAgent nav;
    private bool isDead;
    public float playerDistance;
    [SerializeField] GameObject player;
    private Animator anim;
    private float count = 3f;
    private bool checkCooldown = false;
    private bool isAttacking = false;
    [SerializeField] private int random;
    [SerializeField] private Transform summonPoint;
    [SerializeField] private bool isSummon = false;
    [SerializeField] private Transform responEnermyPosition;
    [SerializeField] private GameObject summonedEnermys;
    [SerializeField] private GameObject[] clone;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        nav = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
        summonPoint =  GameObject.FindGameObjectWithTag("Summon").transform;
        responEnermyPosition = GameObject.FindGameObjectWithTag("Respon").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] clone = new GameObject[4];
    }

    // Update is called once per frame
    void Update()
    {
        clone = GameObject.FindGameObjectsWithTag("SummonedEnermies");

        //transform.LookAt(player.transform.position);
        //Debug.Log(random);
        if (isDead == false)
        {
            nav.speed = 0;
            anim.SetBool("isWalking", false);

        }
        CheckDistance();

        if (playerDistance > 2.5f && nav.speed == 0 && isSummon == false)
        {
           
            count -= Time.timeScale / 100;
            //Debug.Log(count);
            //playing walking animation
            if(count <= 0 && isAttacking == false)
            {
                anim.SetBool("isWalking", true);
            }
        }

      

        //short distance attack
        if (playerDistance <= 3f && nav.speed == 0 && isAttacking == false)
        {
            if (checkCooldown == false)
            {

                if (clone.Length >= 4)
                {
                    StartCoroutine("RandomCheck2");
                }
                if (clone.Length < 4)
                {
                    StartCoroutine("RandomCheck");
                }
            }

            if (random > 0 && random <= 10 && playerDistance <= 3f)
            {
                StartCoroutine("MeleeAttack1");
            }
            if (random > 10 && random <= 20 && playerDistance <= 3f)
            {
                StartCoroutine("MeleeAttack2");
            }

            //summon enermies
            if (random < 40 && random > 30 && isAttacking == false && nav.speed == 0)
            {
                isSummon = true;
                isAttacking = true;
                if (isSummon == true && isAttacking == true)
                {
                    StartCoroutine("Teleport");
                    isSummon = false;
                }
            }

        }

        //long distance attack
        if (playerDistance < 4f && playerDistance > 3f && isAttacking == false)
        {
            if (checkCooldown == false)
            {
                if (clone.Length >= 4)
                {
                    StartCoroutine("RandomCheck2");
                }
                if (clone.Length < 4)
                {
                    StartCoroutine("RandomCheck");
                }
            }

            //random = 20;
            if (random <10)
            {
                StartCoroutine("Attack1");
            }
          
            if(random >= 10 && random < 20)
            {
                StartCoroutine("Attack2");
            }
            if(random < 30 && random >= 20)
            {
                StartCoroutine("Attack3");
            }

            //summon enermies
            if (random < 40 && random > 37 && isAttacking == false && nav.speed == 0)
            {
                isSummon = true;
                isAttacking = true;
                if (isSummon == true && isAttacking == true)
                {
                    StartCoroutine("Teleport");
                    Invoke("Teleport", 3f);
                    isSummon = false;
                }
            }

        }
    }

    private void CheckDistance()
    {
        this.playerDistance = Vector3.Distance(gameObject.transform.position, player.transform.position);
    }

    //Teleport boss to specific area to summon enermies
     IEnumerator Teleport()
     {
        //give some time to teleport
        yield return new WaitForSeconds(1.5f);
        gameObject.transform.position = summonPoint.position;
        StartCoroutine("Summon");
     }

    IEnumerator Summon()
    {
        nav.speed = 0;
        isAttacking = true;
        anim.SetBool("Summon", true);
        anim.SetBool("isWalking", false);
        //reset count, give time to summon 
        count = 6;
        //Debug.Log(count);
        yield return new WaitForSeconds(3f);
        
        if (anim.GetBool("Summon") == true)
        {
            Instantiate(summonedEnermys, responEnermyPosition);
            anim.SetBool("Summon", false);
        }
        isSummon = false;
        isAttacking = false;
    }
    IEnumerator MeleeAttack1()
    {
        isAttacking = true;
        //Debug.Log("attack1");
        anim.SetBool("MeleeAttack1", true);
        nav.speed = 0;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("MeleeAttack1", false);
        yield return new WaitForSeconds(1.5f);
        isAttacking = false;
        

    }
    IEnumerator MeleeAttack2()
    {
        isAttacking = true;
        //Debug.Log("attack2");
        anim.SetBool("MeleeAttack2", true);
        nav.speed = 0;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("MeleeAttack2", false);
        yield return new WaitForSeconds(1.5f);
        isAttacking = false;
      
    }
    IEnumerator Attack1()
    {
        nav.speed = 0;
        isAttacking = true;
        //Debug.Log("attack3");
        anim.SetBool("Attack1", true);
        yield return new WaitForSeconds(3f);
        anim.SetBool("Attack1", false);
        yield return new WaitForSeconds(2f);
        isAttacking = false;
       
    }
    IEnumerator Attack2()
    {
        nav.speed = 0;
        isAttacking = true;
        anim.SetBool("Attack2", true);
        yield return new WaitForSeconds(3f);
        anim.SetBool("Attack2", false);
        yield return new WaitForSeconds(2f);
        isAttacking = false;
    }
    IEnumerator Attack3()
    {
        nav.speed = 0;
        isAttacking = true;
        anim.SetBool("Attack3", true);
        yield return new WaitForSeconds(3f);
        anim.SetBool("Attack3", false);
        yield return new WaitForSeconds(2f);
        isAttacking = false;
    }


    IEnumerator RandomCheck()
    {
        random = Random.Range(0, 40);
        yield return new WaitForSeconds(3.5f);
    }

    IEnumerator RandomCheck2()
    {
        random = Random.Range(0, 30);
        yield return new WaitForSeconds(3.5f);
    }

}
