using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{

    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(transform.up, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerStats>().isInvince == false )
        {

            Debug.Log("Ouch");
            other.GetComponent<Animator>().SetTrigger("Falling");
            other.GetComponent<PlayerStats>().GettingUp();
            other.GetComponent<PlayerStats>().TakeDamage(20);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
