using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class MenuScript : MonoBehaviour
{

    [SerializeField] private GameObject progressBar;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject inGameMenu;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private ProgressBarScript progress;
    [SerializeField] private GameObject viensMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Debug.Log("resumed");
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

    public void VienChoose()
    {
        viensMenu.SetActive(true);
        inGameMenu.SetActive(false);
        healthBar.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
