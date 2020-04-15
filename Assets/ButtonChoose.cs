using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChoose : MonoBehaviour
{
    [SerializeField] private GameObject progressBar;
    [SerializeField] private GameObject character;
    [SerializeField] private ProgressBarScript progress;
    private int choosedVien;
     private GameManager viens;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        viens = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void PlayGame()
    {
        if (gameObject.CompareTag("tree1"))
        {
            choosedVien = 1;
        }
        if (gameObject.CompareTag("tree2"))
        {
            choosedVien = 2;
        }
        if (gameObject.CompareTag("tree3"))
        {
            choosedVien = 3;
        }
        viens.tree = choosedVien;
        if(progress != null)
        {
            progress.loadScenes = 2;
            progressBar.SetActive(true);
        }
       
        character.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
