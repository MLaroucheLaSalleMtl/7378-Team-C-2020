using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotDestroyAtLoading : MonoBehaviour
{

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void Awake()
    {

        DontDestroyOnLoad(this.gameObject);


    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // here you can use scene.buildIndex or scene.name to check which scene was loaded
        if (scene.buildIndex==0)
        {
            // Destroy the gameobject this script is attached to
            Destroy(gameObject);
        }

    }

}
