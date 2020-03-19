using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int tree = 1;
    public float atkCooldown;
    public float globalCooldown;
    public float dodging;
    public float maxCount;
    public bool buffed = false;

    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);//only one exist

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buffed == false)
        {
            switch (tree)
            {
                case 0:
                    atkCooldown = 1f;
                    globalCooldown = 2.6f;
                    dodging = 1f;
                    maxCount = 3f;
                    break;
                case 1:
                    atkCooldown = 0.5f;
                    globalCooldown = 1.6f;
                    dodging = 1f;
                    maxCount = 4f;
                    break;

            }
        }
    }
}
