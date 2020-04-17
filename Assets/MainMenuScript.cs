using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    
    // Start is called before the first frame update
    public void LoadingCharactorChoosing()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
