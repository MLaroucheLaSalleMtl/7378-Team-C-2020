using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject explosionImpact;
   
    public bool isTouch = true;
 
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void Explode()
    {
        if (isTouch == true)
        {
            //if (collision.gameObject.tag == "Surface")
            //{

            GameObject clone;
            clone = Instantiate(explosionImpact, gameObject.transform.position, Quaternion.identity);

            Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, 3);
            foreach (Collider col in colliders)
            {
                //if (col.transform.tag == "Surface")
                //{

                //    //col.GetComponent<EnemyStats>().TakeDamage(30);
                //    Debug.Log("Boom");
                //}
                if (col.transform.tag == "Player")
                {

                    Debug.Log("Boom");
                    if (col.GetComponent<PlayerStats>().super == false)
                    {
                        col.GetComponent<Animator>().SetTrigger("Falling");
                        col.GetComponent<PlayerStats>().GettingUp();
                    }
                    
                    col.GetComponent<PlayerStats>().TakeDamage(20);
                    col.GetComponent<Rigidbody>().AddExplosionForce(10f, gameObject.transform.position, 10f, 1f, ForceMode.VelocityChange);
                }
            }
            Destroy(gameObject);
            Destroy(clone, 2f);
            isTouch = false;


            //}
        }

        //if (collision.gameObject.tag == "Target")
        //{
        //    Rigidbody body = target.GetComponent<Rigidbody>();
        //    target.transform.position = Vector3.forward;
        //}


    }


    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explode",2f);
        
       
    }
}
