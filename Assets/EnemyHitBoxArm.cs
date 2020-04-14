using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBoxArm : MonoBehaviour
{
    private float dmg = 25f;
    public bool harmful = false;


    public void GetDmg(float value)
    {
        dmg = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerStats>().isInvince == false && harmful == true)
        {
            
            Debug.Log("Ouch");
            if (other.GetComponent<PlayerStats>().super == false)
            {
                other.GetComponent<Animator>().SetTrigger("Falling");
                other.GetComponent<PlayerStats>().GettingUp();
            }
            other.GetComponent<PlayerStats>().TakeDamage(dmg);
        }
    }
}
