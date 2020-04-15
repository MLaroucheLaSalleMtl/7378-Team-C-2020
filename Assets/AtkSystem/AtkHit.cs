using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkHit : MonoBehaviour
{
    private bool onlyOnce = false;
    [SerializeField] private PlayerStats stats;

    public void OnTriggerEnter(Collider other)
    {
        if(!onlyOnce)
        {
            if (other.tag == "Target")
            {
                onlyOnce = true;
                // Destroy(other.gameObject,1f);
                other.GetComponent<EnemyStats>().TakeDamage(stats.playerAtk);
                Debug.Log("hit");
            }
            if (other.tag == "SummonedEnermies")
            {
                onlyOnce = true;
                // Destroy(other.gameObject,1f);
                other.GetComponent<MinionStats>().TakeDamage(stats.playerAtk);
                Debug.Log("hit");
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        Destroy(gameObject, 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
