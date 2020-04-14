using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyStats : MonoBehaviour
{
    public float hp = 600;
    public float maxHp = 600;
    [SerializeField] private float Duration;
    [SerializeField] private Image health;

    public void Slow()
    {
        GetComponent<Animator>().SetFloat("Speed", 0.5f);
        Duration = 8f;

    }

    public void TakeDamage(float dmg)
    {
        hp -= dmg;
        health.fillAmount = hp / maxHp;
       
    }


    // Start is called before the first frame update
    void Start()
    {
        health.fillAmount = hp / maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        health.fillAmount = hp / maxHp;
        if(Duration >= 0)
        {
            Duration -= Time.deltaTime;
        }
        if(Duration <=0 && GetComponent<Animator>().GetFloat("Speed")<1)
        {
            GetComponent<Animator>().SetFloat("Speed", 1);
        }
    }
}
