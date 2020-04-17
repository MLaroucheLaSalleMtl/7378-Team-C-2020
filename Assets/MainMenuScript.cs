using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject option;
    
    // Start is called before the first frame update
    public void LoadingCharactorChoosing()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Option()
    {
        option.SetActive(true);
        menu.SetActive(false);
      
    }
    public void Return()
    {
        menu.SetActive(true);
        option.SetActive(false);

    }

}
