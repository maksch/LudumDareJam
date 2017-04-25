using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    float timePassed;
    float timeLimit = 8;

    public GameObject ObjectToSpawn;
    public Transform parentObject;
	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
        if (TeamCounter.totalBlueStatic + TeamCounter.totalGreenStatic + TeamCounter.totalRedStatic < 60)
        {
            timePassed += Time.deltaTime;
            if (timePassed > timeLimit && (!TeamCounter.isGameOver && !ShrineHandler.gameWon))
            {
                timePassed = 0;
                Instantiate(ObjectToSpawn, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), Quaternion.identity);
            }
        }
	}
}
