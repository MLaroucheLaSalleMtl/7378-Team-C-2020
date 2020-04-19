using System.Collections;
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
    private bool isSmoking = false;
    private bool explode=false;
    private bool isFlip = false;
    private bool isWalking = false;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject kick;
    private EnemyStats stats;
    private float hp;
    [SerializeField] private GameObject portal;
    private GameManager code;
    private EventSys sys;
    private float rotateSpeed = 3;

    [SerializeField] GameObject grenade;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tp = GameObject.FindGameObjectWithTag("TP").transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        stats = GetComponent<EnemyStats>();
        code = GameManager.instance;
        sys = EventSys.instance;

    }

    // Update is called once per frame
    void Update()
    {
        hp = stats.hp;
        if (isDead == false)
        {
            // transform.LookAt(player.transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                 Quaternion.LookRotation(player.transform.position - transform.position)
                                                 , rotateSpeed * Time.deltaTime);
        }
        CheckDistance();
        CheckWalk();
        if (hp <= 0 && isDead == false)
        {
            isDead = true;
            anim.SetBool("IsDead", isDead);
            anim.SetTrigger("Death");
            nav.speed = 0f;
            portal.SetActive(true);
            code.secondClear = true;
            sys.accolyteTalk = 6;
            
        }


        if(isDodging==true)
        {
            transform.Translate(Vector3.back * dodgeSpeed*anim.GetFloat("Speed") * Time.deltaTime);
    
        }

        if (checkCooldown == false && isAtking == false)
        {
            StartCoroutine("RandomCheck");
        }



        if (distance >= 5 && isDead == false && behavior >= 30 && isAtking==false && isSmoking == false && isFlip == false)
        {
            StartCoroutine("Shoot");
        }

        if(distance<5 && isDead==false&& behavior<50 && isAtking==false&& isDodging==false && dodgeCount<4 && isSmoking==false && isFlip == false)
        {
            StartCoroutine("Dodge");
        }
        if (distance < 4 && isDead == false && behavior > 50 && behavior <=70 && isAtking == false && isDodging == false && dodgeCount < 4 && isSmoking == false && isFlip==false)
        {
            
            StartCoroutine("Flip");
            if (explode == false)
            {
                Instantiate(grenade, gameObject.transform);
                explode = true;
            }
            
        }
        if (distance < 5 && isDead == false && behavior > 70 && behavior <= 90 && isAtking == false && isDodging == false && dodgeCount < 4 && isSmoking == false && isFlip == false)
        {
            StartCoroutine("Kick");
        }

        if (distance < 5 && isDead == false && behavior < 90 && isAtking == false && isDodging == false && dodgeCount>=4 && isSmoking == false && isFlip == false)
        {
            StartCoroutine("Smoke");
        }
    }

    private void CheckWalk()
    {
        if(distance>10&&isAtking==false&&isDodging==false&&isFlip==false&&isSmoking==false&&isWalking==false)
        {
            nav.speed = 3.5f * anim.GetFloat("Speed");
            isWalking = true;
        }
        if (distance <= 10 && isWalking == true)
        {
            nav.speed = 0;
            isWalking = false;
        }
        anim.SetBool("Walk", isWalking);
    }

    private void CheckDistance()
    {
        this.distance = Vector3.Distance(transform.position, player.transform.position);
    }

    IEnumerator RandomCheck()
    {

        checkCooldown = true;

        behavior = Random.Range(0, 100);
        
        yield return new WaitForSeconds(2.5f / anim.GetFloat("Speed"));
        checkCooldown = false;


    }
    IEnumerator Shoot()
    {
        isAtking = true;
        anim.SetTrigger("Atk");
        yield return new WaitForSeconds(3f/anim.GetFloat("Speed"));
        Instantiate(arrow, gameObject.transform);
        yield return new WaitForSeconds(1f);  
        isAtking = false;
    }

    IEnumerator Dodge()
    {
        isDodging = true;
        isFlip = true;
        anim.SetTrigger("BackDodge");
        yield return new WaitForSeconds(2.0f / anim.GetFloat("Speed"));
        isDodging = false;
        yield return new WaitForSeconds(1.0f);
        isFlip = false;
        dodgeCount += 1;
    }

    IEnumerator Kick()
    {
        isAtking = true;
        
        anim.SetTrigger("Melee");
        yield return new WaitForSeconds(0.75f);
        Instantiate(kick, transform);
        yield return new WaitForSeconds(0.75f);
        isDodging = true;
        yield return new WaitForSeconds(2.5f / anim.GetFloat("Speed"));
        isDodging = false;
        isAtking = false;
        dodgeCount += 1;

    }
    IEnumerator Flip()
    {
        isFlip = true;
        anim.SetTrigger("BackFlip");
        Debug.Log("trig");
        yield return new WaitForSeconds(1.5f);
        isDodging = true;
        yield return new WaitForSeconds(2.5f / anim.GetFloat("Speed"));
        isDodging = false;
        explode = false;
        dodgeCount += 1;
        isFlip = false;
    }


    IEnumerator Smoke()
    {
        isSmoking = true;
        yield return new WaitForSeconds(1f);
        
        transform.position = tp.position;
        dodgeCount = 0;
        yield return new WaitForSeconds(3f );
        isSmoking = false;
    }
}
