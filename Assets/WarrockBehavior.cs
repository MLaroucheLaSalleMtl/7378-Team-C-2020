using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WarrockBehavior : MonoBehaviour
{
    [SerializeField] GameObject player;
    private float distance = 0f;
    [SerializeField] private int RandomBehavior;
    private Animator anim;
    private bool isAtking = false;
    private bool checkCooldown = false;
    private NavMeshAgent nav;
    [SerializeField] GameObject body;
    [SerializeField] float hp ;
    private float maxHp ;
    private bool isDead = false;
    [SerializeField] GameObject rightArm;
    [SerializeField] GameObject leftArm;
    [SerializeField] private Image monsterHealth;
    [SerializeField] AudioSource atkSound;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource roar;
    private EnemyStats stats;
    [SerializeField] private GameObject portal;

    [SerializeField] GameObject win;
    private GameManager code;
 
    //public void TakeDamage(float dmg)
    //{
    //    hp -= dmg;
    //    monsterHealth.fillAmount = hp / 600;
    //}
    
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<EnemyStats>();
        Time.timeScale = 1;
        roar = GetComponent<AudioSource>();
        StartCoroutine("Roaring");
        player = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        nav = gameObject.GetComponent<NavMeshAgent>();
        code = GameManager.instance;
        
        //monsterHealth.fillAmount =  maxHp / 600;
    }

    // Update is called once per frame
    void Update()
    {
        hp = stats.hp;
        maxHp = stats.maxHp;
        //monsterHealth.fillAmount = hp / 600;

        if (hp<=0 && isDead==false)
        {
            isDead = true;
            anim.SetBool("IsDead", isDead);
            anim.SetTrigger("Death");
            nav.speed = 0f;
            Invoke("EnemyDeath", 3f);
            portal.SetActive(true);
            code.firstClear = true;
        }
        CheckDistance();
        if (distance >= 3.3 && nav.speed == 0 && isDead == false)
        {
            nav.speed = 0.5f;
        }



        if (distance >= 3 && anim.GetBool("IsDead") == false && isAtking == false && isDead == false)
        {
            if (anim.GetBool("IsWalking") == false)
            {
                anim.SetBool("IsWalking", true);
            }
            if(checkCooldown == false && isAtking==false)
            {
                StartCoroutine("RandomCheck");
            }
           
            if(RandomBehavior <=10)
            {
                isAtking = true;
                StartCoroutine("Charging");
            }
            if(RandomBehavior >10 && RandomBehavior <=20)
            {
                isAtking = true;
                StartCoroutine("JumpAtk");
            }
        }
        if(distance < 3 && anim.GetBool("IsDead") == false && isAtking == false && player.GetComponent<PlayerStats>().isInvince==false && isDead==false)
        {
            int closeCheck = 0;
            closeCheck = Random.Range(0,10);

            if (closeCheck <= 7)
            {
                isAtking = true;
                anim.SetBool("IsWalking", false);
                StartCoroutine("Swip");
            }
            else
            {
                isAtking = true;
                anim.SetBool("IsWalking", false);
                StartCoroutine("Smashing");
            }
        }
    }
    IEnumerator RandomCheck()
    {
        
        checkCooldown = true;
        
        RandomBehavior = Random.Range(0, 100);
        yield return new WaitForSeconds(2.5f);
        checkCooldown = false;
        

    }

    IEnumerator Charging()
    {
        StartCoroutine("Roaring");
        leftArm.GetComponent<EnemyHitBoxArm>().harmful = true;
        rightArm.GetComponent<EnemyHitBoxArm>().harmful = true;
        body.GetComponent<EnemyHitBoxBody>().harmful = true;
        nav.speed = 0f;
        anim.SetBool("IsWalking", false);
        anim.SetTrigger("Charge");
        nav.stoppingDistance = 0.1f;
        yield return new WaitForSeconds(7f);
        leftArm.GetComponent<EnemyHitBoxArm>().harmful = false;
        rightArm.GetComponent<EnemyHitBoxArm>().harmful = false;
        body.GetComponent<EnemyHitBoxBody>().harmful = false ;
        nav.stoppingDistance = 2.5f;
        nav.speed = 0.5f;
        isAtking = false;
        

    }
    IEnumerator JumpAtk()
    {
        StartCoroutine("JumpSound");
        leftArm.GetComponent<EnemyHitBoxArm>().harmful = true;
        rightArm.GetComponent<EnemyHitBoxArm>().harmful = true;
        body.GetComponent<EnemyHitBoxBody>().harmful = true;
        nav.speed = 0f;
        anim.SetBool("IsWalking", false);
        anim.SetTrigger("JumpAtk");
        yield return new WaitForSeconds(5f);
        leftArm.GetComponent<EnemyHitBoxArm>().harmful = false;
        rightArm.GetComponent<EnemyHitBoxArm>().harmful = false;
        body.GetComponent<EnemyHitBoxBody>().harmful = false;
        nav.speed = 0.5f;
        isAtking = false;
        anim.SetBool("IsWalking", true);


    }
    IEnumerator Swip()
    {
        StartCoroutine("AtkSound");
        leftArm.GetComponent<EnemyHitBoxArm>().harmful = true;
        nav.speed = 0f;
        anim.SetBool("IsWalking", false);
        anim.SetTrigger("Swip");
        yield return new WaitForSeconds(2f);
        leftArm.GetComponent<EnemyHitBoxArm>().harmful = false;
        if(distance>=3)
        {
            nav.speed = 0.5f;
        }
        
        isAtking = false;
        anim.SetBool("IsWalking", true);


    }
    IEnumerator Smashing()
    {
        StartCoroutine("AtkSound");
        nav.speed = 0f;
        anim.SetBool("IsWalking", false);
        anim.SetTrigger("Smash");
        yield return new WaitForSeconds(1.0f);
        leftArm.GetComponent<EnemyHitBoxArm>().harmful = true;
        rightArm.GetComponent<EnemyHitBoxArm>().harmful = true;
        yield return new WaitForSeconds(1.0f);
        leftArm.GetComponent<EnemyHitBoxArm>().harmful = false;
        rightArm.GetComponent<EnemyHitBoxArm>().harmful = false;
        if (distance >= 3)
        {
            nav.speed = 0.5f;
        }

        isAtking = false;
        anim.SetBool("IsWalking", true);

    }

    IEnumerator Roaring()
    {
        yield return new WaitForSeconds(1.0f);
        roar.Play();
    }
    IEnumerator AtkSound()
    {
        yield return new WaitForSeconds(0.5f);
        atkSound.Play();
    }
    IEnumerator JumpSound()
    {
        yield return new WaitForSeconds(0.7f);
        jumpSound.Play();
    }

    private void CheckDistance()
    {
        this.distance = Vector3.Distance(transform.position, player.transform.position);
    }

    void EnemyDeath()
    {
        portal.SetActive(true);
        code.firstClear = true;
        //win.SetActive(true);
        //Time.timeScale = 0;
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
    }
}
