using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class MenuScript : MonoBehaviour
{

    [SerializeField] private GameObject progressBar;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject inGameMenu;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private ProgressBarScript progress;
    [SerializeField] private GameObject viensMenu;
    [SerializeField] private GameObject deathPannel;
    [SerializeField] private PlayerStats playerHealth;
    [SerializeField] private GameObject option;


    public static MenuScript instance = null;
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


    public void PlayGame()
    {
        progress.loadScenes = 2;
        progressBar.SetActive(true);
        character.SetActive(false);
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

    public void Rertry()
    {
        
        progress.loadScenes = 2;
        progressBar.SetActive(true);
        deathPannel.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        //reset player's health and position
        playerHealth.Hp = 100;
        player.transform.position = new Vector3(46, 35, 64);
    }
    public void Option()
    {
        healthBar.SetActive(false);
        inGameMenu.SetActive(false);
        option.SetActive(true);

    }
    public void Return()
    {
        
        option.SetActive(false);
        inGameMenu.SetActive(true);
        healthBar.SetActive(true);
    }

}
