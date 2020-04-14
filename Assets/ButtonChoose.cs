using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChoose : MonoBehaviour
{
    [SerializeField] private GameObject progressBar;
    [SerializeField] private GameObject character;
    [SerializeField] private ProgressBarScript progress;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        progress.loadScenes = 2;
        progressBar.SetActive(true);
        character.SetActive(false);
    }
}
