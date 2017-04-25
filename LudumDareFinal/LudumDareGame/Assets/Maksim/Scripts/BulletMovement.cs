using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {
    public float xMove;
    public float yMove;
    public float mag = 0.000001f;
    public int shooterId;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(xMove * mag, yMove * mag, 0);
	}
}
