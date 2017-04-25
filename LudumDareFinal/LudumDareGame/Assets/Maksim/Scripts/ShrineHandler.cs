using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineHandler : MonoBehaviour {
    public Sprite[] redShrineSprites = new Sprite[4];
    public Sprite[] blueShrineSprites = new Sprite[4];
    public Sprite[] greenShrineSprites = new Sprite[4];
    Sprite[] thisSprites;
    string myTag;

    public GameObject winGraphic;
    public AudioSource gameMusic;
    public AudioSource winMusic;
    public float myFloat;

    SpriteRenderer myRend;

    public static float redShrine = 0;
    public static float blueShrine = 0;
    public static float greenShrine = 0;

    public static bool gameWon;


    // Use this for initialization
    void Start () {
        gameWon = false;
        redShrine = 0;
        blueShrine = 0;
        greenShrine = 0;
        myTag = gameObject.tag;
        myRend = GetComponent<SpriteRenderer>();
        if (myTag == "GreenPlayer") { thisSprites = greenShrineSprites; }
        if (myTag == "RedPlayer") { thisSprites = redShrineSprites; }
        if (myTag == "BluePlayer") { thisSprites = blueShrineSprites; }
    }
	
	// Update is called once per frame
	void Update () {
        if(redShrine > 1000 && blueShrine > 1000 && greenShrine > 1000)
        {
            gameWon = true;
            print("winners :)");
            winGraphic.active = true;
            gameMusic.enabled = false;
            winMusic.enabled = true;
        }
        if (myTag == "GreenPlayer"){ myFloat = greenShrine; }
        if (myTag == "RedPlayer") { myFloat = redShrine; }
        if (myTag == "BluePlayer") { myFloat = blueShrine; }
        if (myFloat < 200)
        {
            myRend.sprite = thisSprites[0];
        }
        else if (myFloat < 400)
        {
            myRend.sprite = thisSprites[1];
        }
        else if(myFloat < 600)
        {
            myRend.sprite = thisSprites[2];
        }
        else if (myFloat < 800)
        {
            myRend.sprite = thisSprites[3];
        }
    }
}
