using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ButtonActionScript : MonoBehaviour
{
    [SerializeField] private GameObject progressBar;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject inGameMenu;
    [SerializeField] private GameObject character;
  

    public void OpenMenu(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            inGameMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetButtonDown("Cancel"))
        //{
        //    inGameMenu.SetActive(true);
        //    Time.timeScale = 0;
        //}
    }
    
    //StartMenu Button
    public void LoadingCharactorChoosing()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void PlayGame()
    {
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
        
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
