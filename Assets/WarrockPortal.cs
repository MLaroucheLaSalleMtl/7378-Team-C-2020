using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WarrockPortal : MonoBehaviour
{
    private GameObject player;
    private float distance;
    private EventSys sys;
    private bool onlyOnce = true;
    [SerializeField]  Text portalTxt;
    [SerializeField] private int action;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sys = EventSys.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(sys==null)
        {
            sys = EventSys.instance;
        }
        CheckDistance();
        if(distance<=5 && onlyOnce ==true)
        {
            sys.SetAction(action);
            onlyOnce = false;
            portalTxt.gameObject.SetActive(true);
        }
        if(distance>5 && onlyOnce ==false)
        {
            sys.SetAction(0);
            onlyOnce = true;
            portalTxt.gameObject.SetActive(false);
        }
        
    }
    private void CheckDistance()
    {
        this.distance = Vector3.Distance(transform.position, player.transform.position);
    }
}
