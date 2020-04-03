using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeImpact : MonoBehaviour
{
    [SerializeField] private float force = 300f;
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
        if(collision.gameObject.tag == "Explode")
        {
            Debug.Log("Activate");
            Rigidbody body = gameObject.GetComponent<Rigidbody>();
            body.AddForce(gameObject.transform.forward * force);
        }
     
    }
}
