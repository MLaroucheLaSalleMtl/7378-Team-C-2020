using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmoving : MonoBehaviour
{
    private float countdown;
    private float movespeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        countdown = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown>0)
        {
            countdown -= Time.deltaTime;
        }
        if(countdown>0)
        {
            transform.Translate(Vector3.back*movespeed*Time.deltaTime);
        }
    }
}
