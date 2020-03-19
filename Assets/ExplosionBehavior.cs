using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.transform.parent != null)
        {
            gameObject.transform.parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
