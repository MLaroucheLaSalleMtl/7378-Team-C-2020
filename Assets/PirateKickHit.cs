using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateKickHit : MonoBehaviour
{
    private bool onlyonce = false;
    private AudioSource sound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerStats>().isInvince == false && onlyonce==false)
        {
            onlyonce = true;
            sound.Play();
            Debug.Log("Ouch");
            if (other.GetComponent<PlayerStats>().super == false)
            {
                other.GetComponent<Animator>().SetTrigger("Falling");
                other.GetComponent<PlayerStats>().GettingUp();
            }
            other.GetComponent<PlayerStats>().TakeDamage(20);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
