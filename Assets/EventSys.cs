using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSys : MonoBehaviour
{
    [SerializeField]private int action = 0;
    public static EventSys instance = null;
    [SerializeField] private GameObject ProgressBar;
    [SerializeField] private ProgressBarScript progress;
    [SerializeField] private GameObject heathBar;



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
                progress.loadScenes = 3;
            
                ProgressBar.SetActive(true);
                
                //SceneManager.LoadSceneAsync(3);
                break;
            case 2:
                progress.loadScenes = 4;
             
                ProgressBar.SetActive(true);
                //SceneManager.LoadSceneAsync(4);
                break;
            case 3:
                progress.loadScenes = 5;
        
                ProgressBar.SetActive(true);
                //SceneManager.LoadScene(5);
                break;

        }
        action = 0;

    }
}
