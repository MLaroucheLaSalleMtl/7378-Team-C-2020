using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{

    public bool firstClear = false;
    public bool secondClear = false;
    public bool thirdClear = false;
    public bool allClear = false;


    public int tree = 1;
    public float atkCooldown;
    public float globalCooldown;
    public float dodging;
    public float maxCount;
    public bool buffed = false;

    private int action = 0;
    

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
        if(firstClear==true&&secondClear==true&&thirdClear==true)
        {
            allClear = true;
        }

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
                case 2:
                    atkCooldown = atkCooldown = 1.0f;
                    globalCooldown = 3f;
                    dodging = 1f;
                    maxCount = 3f;
                    break;

            }
        }
    }

}
