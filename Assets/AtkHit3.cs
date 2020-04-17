using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkHit3 : MonoBehaviour
{
    private bool onlyOnce = false;
    [SerializeField]private AudioSource sound;
    [SerializeField] private PlayerStats stats;

    public void OnTriggerEnter(Collider other)
    {
        if (!onlyOnce)
        {
            if (other.tag == "Target")
            {
                onlyOnce = true;
                sound.Play();
                other.GetComponent<EnemyStats>().TakeDamage(stats.playerAtk);
                if(stats.super==true)
                {
                    stats.LifeVamp();
                }
                Debug.Log("hit");
                Destroy(gameObject);
            }
            if (other.tag == "SummonedEnermies")
            {
                sound.Play();
                onlyOnce = true;
                // Destroy(other.gameObject,1f);
                other.GetComponent<MinionStats>().TakeDamage(stats.playerAtk);
                if (stats.super == true)
                {
                    stats.LifeVamp();
                }
                Debug.Log("hit");
                Destroy(gameObject);
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
