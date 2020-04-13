using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateKickHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerStats>().isInvince == false)
        {

            Debug.Log("Ouch");
            other.GetComponent<Animator>().SetTrigger("Falling");
            other.GetComponent<PlayerStats>().GettingUp();
            other.GetComponent<PlayerStats>().TakeDamage(20);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
