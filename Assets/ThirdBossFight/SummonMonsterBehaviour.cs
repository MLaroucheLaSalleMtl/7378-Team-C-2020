using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SummonMonsterBehaviour : MonoBehaviour
{
    private NavMeshAgent nav;
    private bool isDead;
    private Animator anim;
    [SerializeField] private float playerDistance;
    private GameObject player;
    private bool isAttacking = false;
    private bool checkCooldown = false;


    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        nav = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            nav.speed = 0;
            anim.SetBool("isWalking", false);

        }

        CheckDistance();

        if (playerDistance > 1f && nav.speed == 0)
        {
            anim.SetBool("isWalking", true);
            //nav.speed = 0.5f;
        }

        if (playerDistance <= 1f && nav.speed == 0 && isAttacking == false)
        {
            StartCoroutine("SummonsAttack1");
        }
    }

    private void CheckDistance()
    {
        this.playerDistance = Vector3.Distance(gameObject.transform.position, player.transform.position);

    }

    IEnumerator SummonsAttack1()
    {
        nav.speed = 0;
        isAttacking = true;
        anim.SetBool("SummonsAttack1", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("SummonsAttack1", false);
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
}