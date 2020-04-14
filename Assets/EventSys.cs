using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSys : MonoBehaviour
{
    [SerializeField]private int action = 0;
    public static EventSys instance = null;
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
        
    }
    public void SetAction(int x)
    {
        action = x;
    }

    public void interact()
    {
        switch (action)
        {
            case 1:
                SceneManager.LoadSceneAsync(3);
                break;
            case 2:
                SceneManager.LoadSceneAsync(4);
                break;
            case 3:
                SceneManager.LoadSceneAsync(5);
                break;

        }
        action = 0;

    }
}
