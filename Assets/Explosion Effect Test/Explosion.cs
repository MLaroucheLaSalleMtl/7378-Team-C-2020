using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject explosionImpact;
    [SerializeField] private GameObject target;
    public bool isTouch = true;
 
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    
    private void OnCollisionEnter(Collision collision)
    {

        if (isTouch == true)
        {
            if (collision.gameObject.tag == "Surface")
            {

                GameObject clone;
                clone = Instantiate(explosionImpact, gameObject.transform.position, Quaternion.identity);

                Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, 2);
                foreach (Collider col in colliders)
                {
                    if (col.transform.tag == "Surface")
                    {
                       
                        //col.GetComponent<EnemyStats>().TakeDamage(30);
                        Debug.Log("Boom");
                    }
                }
                Destroy(gameObject);
                Destroy(clone, 2f);
                isTouch = false;


            }
        }

        //if (collision.gameObject.tag == "Target")
        //{
        //    Rigidbody body = target.GetComponent<Rigidbody>();
        //    target.transform.position = Vector3.forward;
        //}


    }
}
