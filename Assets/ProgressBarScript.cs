using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class ProgressBarScript : MonoBehaviour
{
    public int loadScenes;
    private Image slider;
    private AsyncOperation async;
    private int sceneToLoad;
    [SerializeField] private Text progress;
    private float value;
    [SerializeField] private GameObject heathBar;

    [SerializeField] private GameObject panel;



    // Start is called before the first frame update
    void Start()
    {
        if(heathBar != null)
        {
            heathBar.SetActive(false);
        }
      
        sceneToLoad = loadScenes;
        slider = gameObject.GetComponent<Image>();
        async = SceneManager.LoadSceneAsync(sceneToLoad);
        print("async = " + async.progress);
        async.allowSceneActivation = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(sceneToLoad);
        slider.fillAmount += async.progress / 100;
        if (SplashScreen.isFinished && slider.fillAmount == 1f)
        {
            async.allowSceneActivation = true;
        }
        value = slider.fillAmount;
        progress.text = value * 100 + "%";
        if(async.progress >= 0.9)
        {
            heathBar.SetActive(true);
            Time.timeScale = 1;
            panel.SetActive(false);
        }
    }
}
