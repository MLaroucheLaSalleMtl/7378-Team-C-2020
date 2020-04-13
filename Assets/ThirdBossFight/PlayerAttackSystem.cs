using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerAttackSystem : MonoBehaviour
{
    [SerializeField] private int count = 0;
    [SerializeField] private int slowAttackcount = 0;
    public GameObject subject;
    private Animator anim;
    [SerializeField] private float cooldown = 1f; 
    [SerializeField] private float cooldown2 = 1f; 
    [SerializeField] private float skillcooldown = 0.2f;
    [SerializeField] private float slowAttackSkillcooldown = 0.2f;
    [SerializeField] private bool isDodge = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = subject.GetComponent<Animator>();
   
    }

    // Update is called once per frame
    void Update()
    {
        slowAttackSkillcooldown -= Time.timeScale * 0.01f;
        skillcooldown -= Time.timeScale * 0.01f;
        cooldown -= Time.timeScale * 0.02f;
        cooldown2 -= Time.timeScale * 0.02f;
        // if player do not attack for a while, reset anim
        if (cooldown < 0)
        {
            anim.SetInteger("ComboCount", 0);
       
            count = 0;

            //reset cooldown
            if (skillcooldown < -2f)
            {
                skillcooldown = 0.2f;
            }
            if (cooldown < -2f)
            {
                cooldown = 1f;
            }
        }
        if (cooldown2 < 0)
        {

            anim.SetInteger("ComboCount2", 0);
            slowAttackcount = 0;

            //reset cooldown
            if (slowAttackSkillcooldown < -2f)
            {
                slowAttackSkillcooldown = 0.2f;
            }
            if (cooldown2 < -2f)
            {
                cooldown2 = 1f;
            }
        }
        
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (skillcooldown <= 0 )
            {
                count++;
            }

            switch (count)
            {
                case 1:
                    if(true)
                    {
                        anim.SetInteger("ComboCount", count);
                        skillcooldown = 0.5f;
                        cooldown = 2.5f;
                    }
                    break;
                case 2:
                    anim.SetInteger("ComboCount", count);
                    skillcooldown = 1f;
                    cooldown = 3f;
                    break;
                case 3:
                    anim.SetInteger("ComboCount", count);
                    skillcooldown = 1f;
                    cooldown = 2f;
                    break;
                default:
                    {
                        skillcooldown = 0.2f;
                        cooldown = 1f;
                    }
                    break;
            }
        }

    }

    public void SlowAttck(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            if (slowAttackSkillcooldown <= 0)
            {
                slowAttackcount++;
            }

            switch (slowAttackcount)
            {
                case 1:
                    if (true)
                    {
                        anim.SetInteger("ComboCount2", slowAttackcount);
                        slowAttackSkillcooldown = 0.7f;
                        cooldown2 = 2.5f;
                    }
                    break;
                case 2:
                    anim.SetInteger("ComboCount2", slowAttackcount);
                    slowAttackSkillcooldown = 1f;
                    cooldown2 = 3f;
                    break;
                case 3:
                    anim.SetInteger("ComboCount2", slowAttackcount);
                    slowAttackSkillcooldown = 1f;
                    cooldown2 = 2.5f;
                    break;
                default:
                    {
                        slowAttackSkillcooldown = 0.2f;
                        cooldown2 = 1f;
                    }
                    break;
            }
        }

    }


    public void Roll(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if(isDodge == false)
            {
                StartCoroutine("Dodge");
            }
          
        }
    }

    IEnumerator Dodge()
    {
        isDodge = true;
        anim.SetTrigger("Dodge");
        yield return new WaitForSeconds(0.8f);
        isDodge = false;
    }
  
}
