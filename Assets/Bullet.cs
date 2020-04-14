using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        if (other.tag == "Target")
        {
            other.GetComponent<EnemyStats>().TakeDamage(15f);
            Destroy(gameObject, 0.2f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
