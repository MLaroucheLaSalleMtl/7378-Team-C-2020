using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public bool isInvince = false;
    public bool isDown = false;
    [SerializeField] private float hp = 100f;
    private float maxHp = 100f;
    private Animator anim;
    public float playerAtk = 30f;
    public GameObject shield;
    public bool isShield = false;
    private bool isDead = false;
    private float shieldDuration;
    private GameManager code;
    public bool super=false;
    private float superDuration;

    private float accelo;
    private float speedMod = 2;

    


    [SerializeField] private Image heathBar;
    [SerializeField] private GameObject death;

    public float Hp { get => hp; set => hp = value; }

    IEnumerator DodgingInvince()
    {
        isInvince = true;
        yield return new WaitForSeconds(0.8f);
        isInvince = false;
    }

    IEnumerator GettingUpCheck()
    {
        isDown = true;
        isInvince = true;
        yield return new WaitForSeconds(4.5f);
        isInvince = false;
        isDown = false;
    }
    public void ActiveSkill()
    {
        if (code.tree == 0)
        {
            isShield = true;
            shieldDuration = 6.0f;
        }
        else if(code.tree==1)
        {
            anim.SetFloat("Speed", 2);
            accelo = 7.0f;
            code.atkCooldown = 0.3f/2;
            code.globalCooldown = 1.6f/2f;
            code.dodging = 0.3f/2;
            code.buffed = true;
            hp += 20;
        }
        else if(code.tree==2)
        {
            super = true;
            superDuration = 10;
        }
    }
    public void Dodging()
    {
        StartCoroutine("DodgingInvince");
    }
    public void GettingUp()
    {
        StartCoroutine("GettingUpCheck");
    }
    public void TakeDamage(float dmg)
    {
        if (isShield == false)
        {
            hp -= dmg;
            heathBar.fillAmount = hp/100;
            
        }

        else
        {
            isShield = false;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        code = GameManager.instance;
        anim = GetComponent<Animator>();
        heathBar.fillAmount = maxHp/100;
        Time.timeScale = 1;
    }



    // Update is called once per frame
    void Update()
    {
        if(accelo>0)
        {
            accelo -= Time.deltaTime;
        }
        if(accelo<=0 && anim.GetFloat("Speed")>1f)
        {
            anim.SetFloat("Speed", 1f);
            code.atkCooldown = 0.3f;
            code.globalCooldown = 1.6f;
            code.dodging = 1f;
            code.buffed = false;
        }
        if(hp>=maxHp)
        {
            hp = maxHp;
            heathBar.fillAmount = hp/100;
        }
        if(isShield == true && shieldDuration >0 )
        {
            shield.SetActive(true);
            if(hp<maxHp)
            {
                hp += Time.deltaTime * 5;
                heathBar.fillAmount = hp/100;
            }
        }
        if (isShield == true&& shieldDuration <=0)
        {
            isShield = false;
        }
        if (isShield ==false)
        {
            shield.SetActive(false);
        }
        if(shieldDuration>0)
        {
            shieldDuration -= Time.deltaTime;
        }
       if(hp<=0 && isDead==false)
        {
            isDead = true;
            anim.SetTrigger("Falling");
            anim.SetBool("IsDead", true);
            Invoke("Death", 2f);
        }
       if(superDuration>0)
        {
            superDuration -= Time.deltaTime;
        }
       if(super==true&&superDuration<=0)
        {
            super = false;
        }
    }

    public void LifeVamp()
    {
        hp += playerAtk;
    }

    void Death()
    {
        death.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
