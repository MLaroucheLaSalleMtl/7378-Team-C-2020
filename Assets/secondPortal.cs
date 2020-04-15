using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondPortal : MonoBehaviour
{
    private GameManager code;
    // Start is called before the first frame update
    void Start()
    {
        code = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(code.secondClear ==true)
        {
            gameObject.SetActive(false);
        }
        
    }
}
