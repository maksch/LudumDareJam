using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAfter : MonoBehaviour {
    public Animator componentToActivate;
    public float ActivateAfterSeconds;
    float timePassed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;
        if(timePassed > ActivateAfterSeconds)
        {
            componentToActivate.enabled = true;
        }
	}
}
