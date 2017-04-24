using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineHandler : MonoBehaviour {
    public Sprite[] redShrineSprites = new Sprite[4];
    public Sprite[] blueShrineSprites = new Sprite[4];
    public Sprite[] greenShrineSprites = new Sprite[4];
    Sprite[] thisSprites;
    string myTag;
    SpriteRenderer myRend;

    public static float redShrine = 0;
    public static float blueShrine = 0;
    public static float greenShrine = 0;
    // Use this for initialization
    void Start () {
        myTag = gameObject.tag;
        myRend = GetComponent<SpriteRenderer>();
        if (myTag == "GreenPlayer") { thisSprites = greenShrineSprites; }
        if (myTag == "RedPlayer") { thisSprites = redShrineSprites; }
        if (myTag == "BluePlayer") { thisSprites = blueShrineSprites; }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
