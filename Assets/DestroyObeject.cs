﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObeject : MonoBehaviour
{
    [SerializeField] private float timer=1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
