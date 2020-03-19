using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent != null)
        {
            transform.parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
