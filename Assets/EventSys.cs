using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventSys : MonoBehaviour
{
    [SerializeField]private int action = 0;
    public static EventSys instance = null;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerAtk input;
    [SerializeReference] private GameObject talkPanel;
    [SerializeField] private GameObject ProgressBar;
    [SerializeField] private ProgressBarScript progress;
    public int accolyteTalk = 1;
    [SerializeField] private Text accolyteTxt;
    [SerializeField] private GameObject panelEnd;
    private GameManager code;
    public void EndTalk()
    {
        if (input.isTalking == true && code.allClear == false)
        {
            input.isTalking = false;
        }

        talkPanel.SetActive(false);
        switch(accolyteTalk)
        {
            case 1:
                accolyteTalk = 2;
                break;
            case 2:
                accolyteTalk = 3;
                break;
            case 3:
                accolyteTalk = 4;
                break;
            case 4:
                accolyteTalk = 2;
                break;
            case 5:
                accolyteTalk = 2;
                break;
            case 6:
                accolyteTalk = 2;
                break;
            case 7:
                accolyteTalk = 2;
                break;
        }
        if(code.allClear==true)
        {
            panelEnd.SetActive(true);
        }

    }

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
        code = GameManager.instance;
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
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                talkPanel.SetActive(true);
                switch(accolyteTalk)
                {
                    case 1:
                        accolyteTxt.text = "Ah, once again, our chosen one has awake. it seems you have lost part of memory since your last awakening. I am the acolyte of the lady and you are her chosen one. we are here to break the seal to free our lady.";
                        break;
                    case 2:
                        accolyteTxt.text = "Don't worry, no matter how many time you fail, our lady will bring you back to life";
                        break;
                    case 3:
                        accolyteTxt.text = "The guardian are also bounded by the seal, we have plenty of time to defeat them";
                        break;
                    case 4:
                        accolyteTxt.text = "You need to defeat all guardians before i can start the ritual";
                        break;
                    case 5:
                        accolyteTxt.text = "The forest has burned to ground, the temple brought to ruin, and now, the ancient warrior fall to sleep";
                        break;
                    case 6:
                        accolyteTxt.text = "Ashes to ashed, dust to dust, the hunter has been hunted";
                        break;
                    case 7:
                        accolyteTxt.text = "Behind the plate, hides the shadow, the noble knight has fall long time ago";
                        break;
                }
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
