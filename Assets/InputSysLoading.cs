using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputSysLoading : MonoBehaviour
{

    private static InputSysLoading instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);//only one exist

        }
        DontDestroyOnLoad(this.gameObject);


    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       
        if (scene.buildIndex == 0)
        {
            
            Destroy(gameObject);
        }
    }
}
