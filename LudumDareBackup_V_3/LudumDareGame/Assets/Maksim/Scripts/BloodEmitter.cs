using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEmitter : MonoBehaviour {

    public GameObject[] bloodTypes = new GameObject[5];
    GameObject currentObj;
    BulletMovement currentMove;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < 10; i++)
        {
            currentObj = Instantiate(bloodTypes[Random.Range(0, 4)], gameObject.transform);
            currentMove = currentObj.GetComponent<BulletMovement>();
            currentMove.xMove = Random.Range(-1f, 1f);
            currentMove.yMove = Random.Range(-1f, 1f);
            currentMove.mag = Random.Range(0.001f, 0.03f);
            currentMove = null;
            currentObj = null;
            //
        }
	}
	
	// Update is called once per frame
	void Update () {
    }
}
