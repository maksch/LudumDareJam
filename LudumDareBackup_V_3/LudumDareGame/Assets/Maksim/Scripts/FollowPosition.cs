using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour {

    Transform objToFollow;
	// Use this for initialization
	void Start () {
        objToFollow = transform.parent.transform.Find("Soldier");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(objToFollow.position.x, objToFollow.position.y + 0.5f, objToFollow.position.z - 0.001f);
	}
}
