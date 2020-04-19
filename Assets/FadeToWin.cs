using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToWin : MonoBehaviour
{
    [SerializeField] private GameObject win;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        StartCoroutine("WinActivate");
    }
    IEnumerator WinActivate()
    {
        yield return new WaitForSeconds(2.5f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        win.SetActive(true);
     
    }
}
