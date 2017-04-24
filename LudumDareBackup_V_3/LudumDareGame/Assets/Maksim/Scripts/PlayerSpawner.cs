using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    float timePassed;
    float timeLimit = 2;

    public GameObject ObjectToSpawn;
    public Transform parentObject;
	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {

        timePassed += Time.deltaTime;
        if(timePassed > timeLimit && !TeamCounter.isGameOver)
        {
            timePassed = 0;
            Instantiate(ObjectToSpawn, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), Quaternion.identity);
        }

	}
}
