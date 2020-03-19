using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class ProgressBarScript : MonoBehaviour
{
    private Image slider;
    private AsyncOperation async;
    private int sceneToLoad;
    [SerializeField] private Text progress;
    private float value;
    // Start is called before the first frame update
    void Start()
    {
        sceneToLoad = 2;
        slider = gameObject.GetComponent<Image>();
        async = SceneManager.LoadSceneAsync(sceneToLoad);
        print("async = " + async.progress);
        async.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        slider.fillAmount += async.progress / 100;
        if (SplashScreen.isFinished && slider.fillAmount == 1f)
        {
            async.allowSceneActivation = true;
        }
        value = slider.fillAmount;
        progress.text = value * 100 + "%";
    }
}
