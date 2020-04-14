using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject progressBar;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject inGameMenu;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private ProgressBarScript progress;

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





    public void OpenMenu(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            inGameMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void LoadingCharactorChoosing()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void PlayGame()
    {
        progress.loadScenes = 2;
        progressBar.SetActive(true);
        character.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    //InGame Menu Button
    public void Resume()
    {
        inGameMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ReturnToMenu()
    {
        //SceneManager.LoadSceneAsync(0);
        progress.loadScenes = 0;
        progressBar.SetActive(true);
        inGameMenu.SetActive(false);
        healthBar.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        progress.loadScenes = 0;
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
