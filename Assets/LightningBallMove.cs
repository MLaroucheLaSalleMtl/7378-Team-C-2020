using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBallMove : MonoBehaviour
{
    private float speed = 3f;
    private Rigidbody rigid;
    [SerializeField] private GameObject LightningExplosion;
    [SerializeField] private bool onlyOnce = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(transform.forward, ForceMode.Impulse);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(LightningExplosion,gameObject.transform);
        Destroy(gameObject,0.2f);
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos,2);
        foreach (Collider col in colliders)
        {


            if (col.transform.tag == "Target" && onlyOnce==false)
            {
                onlyOnce = true;
               col.GetComponent<EnemyStats>().TakeDamage(30);
                Debug.Log("Boom");
            }
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
