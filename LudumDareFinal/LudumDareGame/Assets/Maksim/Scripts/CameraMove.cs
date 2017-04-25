using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float mag;
    float shiftMag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!TeamCounter.isGameOver && !ShrineHandler.gameWon)
        {
         if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                shiftMag = 2;
            }
            else
            {
                shiftMag = 1;
            }

            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && transform.position.x > -5)
            {
                transform.Translate(-1 * mag * shiftMag, 0, 0);
            }
            else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position.x < 5)
            {
                transform.Translate(1 * mag * shiftMag, 0, 0);
            }
            if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && transform.position.y > -5)
            {
                transform.Translate(0, -1 * mag * shiftMag, 0);
            }
            else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && transform.position.y < 5)
            {
                transform.Translate(0, 1 * mag * shiftMag, 0);
            }
        }
    }
}
