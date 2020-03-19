using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerAtk : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject subject;
    private int count;
    public float atkInterval;
    public float atkReset;
    public float dodgingReset;
    public float atkcooldown;
    public float globalatkcooldown;
    private Animator anim;
    float dodging = 0f;
    private ThirdPersonUserControl control;
    private float skillCD = 0f;
    private float maxCount ;


    private GameManager code;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject atkEffect;
    [SerializeField] private GameObject powEffect;
    [SerializeField]private GameObject atkHit;
    private Vector3 offset = new Vector3(0.3f, 1.3f, 0.6f);


    IEnumerator PlayEffect()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(atkEffect);
       
    }
    IEnumerator ActivePowerEffect()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(powEffect,subject.transform);

    }
    IEnumerator ActivePowerEffect2()
    {
        yield return new WaitForSeconds(1.0f);
        Collider[] colliders = Physics.OverlapSphere(subject.transform.position, 15);
        foreach (Collider col in colliders)
        {


            if (col.transform.tag == "Target" )
            {
                col.GetComponent<EnemyStats>().Slow();
                Debug.Log("Boom");
            }
        }
    }

    public void OnSupport(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (skillCD <= 0f && subject.GetComponent<PlayerStats>().isDown==false && anim.GetInteger("Tree")==0)
            {
                anim.SetTrigger("Casting");
                skillCD = 15f;
                subject.GetComponent<PlayerStats>().ActiveSkill();
            }
            else if (skillCD <= 0f && subject.GetComponent<PlayerStats>().isDown == false && anim.GetInteger("Tree") == 1)
            {
                anim.SetTrigger("Casting");
                skillCD = 15f;
                subject.GetComponent<PlayerStats>().ActiveSkill();
            }
        }
    }

    public void OnWalk(InputAction.CallbackContext context)
    {
       control.walk = context.performed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (anim.GetFloat("ComboCount") <= 0 && subject.GetComponent<PlayerStats>().isDown==false)
        {


            Vector2 value = context.ReadValue<Vector2>();
            control.h = value.x;
            control.v = value.y;
        }
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        
        if (context.started)
        {
            if (dodging <= 0f&&subject.GetComponent<PlayerStats>().isDown==false)
            {
                
                subject.GetComponent<PlayerStats>().Dodging();
                anim.SetTrigger("Dodge");
                dodging = dodgingReset;
                count = 0;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        code = GameManager.instance;
        control = subject.GetComponent<ThirdPersonUserControl>();
        anim = subject.GetComponent<Animator>();
        
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if (subject.GetComponent<PlayerStats>().isDown == false)
            {
                dodging = dodgingReset;
                if (count < maxCount && atkcooldown <= 0f)
                {
                    count++;
                    atkcooldown = atkInterval;
                    globalatkcooldown = atkReset;
                    Debug.Log("ComboCount" + count);
                    if (anim.GetInteger("Tree") == 0)
                    {
                        Instantiate(atkHit, subject.transform);
                        //Instantiate(atkEffect);
                        StartCoroutine("PlayEffect");
                    }
                    else if(anim.GetInteger("Tree")==1)
                    {
                        Instantiate(bullet, subject.transform);
                    }

                }
            }
        }
    }



    public void OnPower(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if(atkcooldown <=0f)
            {
                if (anim.GetInteger("Tree") == 0)
                {
                    subject.GetComponent<Animator>().SetTrigger("Power");
                    atkcooldown = 2.5f;
                    StartCoroutine("ActivePowerEffect");
                }

                if (anim.GetInteger("Tree") == 1)
                {
                    subject.GetComponent<Animator>().SetTrigger("Power");
                    atkcooldown = 2.5f;
                    StartCoroutine("ActivePowerEffect2");
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {


        UpdateTree();
        if (skillCD >0)
        {
            skillCD -= Time.deltaTime;
        }
        if (dodging > 0)
        {
            dodging -= Time.deltaTime;
        }

        if (atkcooldown >= 0f)
        {
            atkcooldown -= Time.deltaTime;
        }
        if (globalatkcooldown >= 0f)
        {
            globalatkcooldown -= Time.deltaTime;
        }
        if (count >= maxCount && atkcooldown <= 0f)
        {
            count = 0;
            Debug.Log("reset");
        }
        if (count > 0 && count < maxCount && globalatkcooldown <= 0f)
        {
            count = 0;
            Debug.Log("unfinished combo");
        }

        subject.GetComponent<Animator>().SetFloat("ComboCount", count);

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    if (count < 3 && atkcooldown <= 0f)
        //    {
        //        count++;
        //        atkcooldown = 2.0f;
        //        globalatkcooldown = 3.0f;
        //        Debug.Log("ComboCount" + count);

        //    }

        //}
    }
    private void UpdateTree()
    {
        anim.SetInteger("Tree", code.tree);
        atkInterval = code.atkCooldown;
        atkReset = code.globalCooldown;
        dodgingReset = code.dodging;
        maxCount = code.maxCount;
    }
}
