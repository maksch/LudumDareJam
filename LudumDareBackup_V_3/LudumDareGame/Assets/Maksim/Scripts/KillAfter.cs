using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAfter : MonoBehaviour
{
    public float killAfterSeconds;
    float timePassed = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timePassed += Time.deltaTime;
        if (timePassed > killAfterSeconds)
        {
            Destroy(gameObject);
        }
    }
}
