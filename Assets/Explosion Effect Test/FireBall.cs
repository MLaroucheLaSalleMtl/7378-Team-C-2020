using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefabs;
    [SerializeField] private GameObject explosionImpact;
    //[SerializeField] private bool onlyOnce = false;
    GameObject copy;

    GameObject firePosition;
    Transform fireTrans;
    float delay = 3f;
    float count;
    bool hasExplode = false;
    void Start()
    {
        firePosition = GameObject.Find("FirePosition");
        fireTrans = firePosition.GetComponent<Transform>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //skill cooldown
        count -= Time.timeScale * 0.01f;


        if (count <= 0 && !hasExplode)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                copy =
                 Instantiate(explosionPrefabs,
                             fireTrans.position,
                             Quaternion.identity
                             );

                Rigidbody body = copy.GetComponent<Rigidbody>();

                body.AddForce(fireTrans.forward * 200);
                //hasExplode = true;
                count = delay;
            }

        }
        //prevent the skill go outside map and never destory
        Destroy(copy, 4f);
    }
}
