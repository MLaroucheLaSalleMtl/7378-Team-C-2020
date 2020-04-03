using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horValue = Input.GetAxis("Horizontal");
        float verValue = Input.GetAxis("Vertical");
        transform.Translate(horValue * Time.timeScale * speed, verValue * Time.timeScale * speed, 0);
    }
}
