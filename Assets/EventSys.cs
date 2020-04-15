using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSys : MonoBehaviour
{
    [SerializeField]private int action = 0;
    public static EventSys instance = null;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerAtk input;

    [SerializeField] private GameObject ProgressBar;
    [SerializeField] private ProgressBarScript progress;
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
                Time.timeScale = 0;
                progress.loadScenes = 3;
                ProgressBar.SetActive(true);
                //SceneManager.LoadScene(3);
                player.transform.position = new Vector3(70, 35, 53);
                break;
            case 2:
                Time.timeScale = 0;
                progress.loadScenes = 4;
                ProgressBar.SetActive(true);
                player.transform.position = new Vector3(50, 10, 35);
                break;
            case 3:
                 Time.timeScale = 0;
                progress.loadScenes = 5;
                ProgressBar.SetActive(true);
                player.transform.position = new Vector3(9, 2, 24);
                break;
            case 4:
                input.isTalking = true;
                break;
            case 5:
                Time.timeScale = 0;
                progress.loadScenes = 2;
                ProgressBar.SetActive(true);
                player.transform.position = new Vector3(46, 32, 64);
                break;



        }
        action = 0;

    }
}
