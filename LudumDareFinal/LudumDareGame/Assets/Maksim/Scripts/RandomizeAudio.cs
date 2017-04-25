using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAudio : MonoBehaviour {

    public AudioSource src1;
    public AudioSource src2;
    public AudioSource src3;

    float timePassed;
    // Use this for initialization
    void Awake () {
        Randomize(src1);
        Randomize(src2);
        Randomize(src3);
    }
	
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;
        if(timePassed > 1 && !src1.isPlaying && !src2.isPlaying && !src3.isPlaying)
        {
            Randomize(src1);
            Randomize(src2);
            Randomize(src3);
            timePassed = 0;
        }
	}
    void Randomize(AudioSource src)
    {
        src.pitch = Random.Range(0.5f, 1.5f);
        src.volume = Random.Range(0.1f, 0.2f);
    }
}
