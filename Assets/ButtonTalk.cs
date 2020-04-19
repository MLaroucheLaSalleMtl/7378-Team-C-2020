using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTalk : MonoBehaviour
{
    private EventSys sys;

    // Start is called before the first frame update
    void Start()
    {
        sys = EventSys.instance;
    }
    
    public void Onclick()
    {
        sys.EndTalk();
        Time.timeScale = 1;
      
   
    }
}
