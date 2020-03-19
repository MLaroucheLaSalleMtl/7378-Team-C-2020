using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBoxBody : MonoBehaviour
{
    private float dmg = 35f;
    public bool harmful = false;
    // Start is called before the first frame update
    public void GetDmg(float value)
    {
        dmg = value;
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (harmful == true)
        {
            if (other.tag == "Player" && other.GetComponent<PlayerStats>().isInvince == false)
            {
                Debug.Log("Ouch");
                other.GetComponent<Animator>().SetTrigger("Falling");
                other.GetComponent<PlayerStats>().GettingUp();
                other.GetComponent<PlayerStats>().TakeDamage(dmg);
            }
        }
    }
}
