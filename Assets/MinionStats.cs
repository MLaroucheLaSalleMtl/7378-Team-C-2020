using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionStats : MonoBehaviour
{
    public float hp = 600;
    public float maxHp = 600;
    [SerializeField] private float Duration;


    public void Slow()
    {
        GetComponent<Animator>().SetFloat("Speed", 0.5f);
        Duration = 8f;

    }

    public void TakeDamage(float dmg)
    {
        hp -= dmg;


    }


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        if (Duration >= 0)
        {
            Duration -= Time.deltaTime;
        }
        if (Duration <= 0 && GetComponent<Animator>().GetFloat("Speed") < 1)
        {
            GetComponent<Animator>().SetFloat("Speed", 1);
        }
    }
}
