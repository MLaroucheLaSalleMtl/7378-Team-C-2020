using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotDestroyAtLoading : MonoBehaviour
{
    private static NotDestroyAtLoading instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);//only one exist

        }
        DontDestroyOnLoad(this.gameObject);


    }
    
}
