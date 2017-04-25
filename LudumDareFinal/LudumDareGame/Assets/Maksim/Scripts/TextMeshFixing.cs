using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshFixing : MonoBehaviour {
    Renderer rend;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        rend.sortingOrder = 100;

    }
}
