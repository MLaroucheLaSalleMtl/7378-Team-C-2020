using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyHit : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            
            // Destroy(other.gameObject,1f);
            other.GetComponent<EnemyStats>().TakeDamage(50);
            
            Debug.Log("hit");
            Destroy(gameObject);
        }
        if (other.tag == "SummonedEnermies")
        {

            // Destroy(other.gameObject,1f);
            other.GetComponent<MinionStats>().TakeDamage(50);

            Debug.Log("hit");
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
