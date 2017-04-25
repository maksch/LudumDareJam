using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicControl : MonoBehaviour {
    private static MenuMusicControl inst;
    public static MenuMusicControl Instance {
        get { return inst; }
        private set { inst = value; }
    }
    private AudioSource menuSource;
    public AudioClip clipToPlay;
    private bool fadeInCompelete = false, fadeOutComplete = false;
    public float fadeInOutRate = 0.1f, fadeInVolIncrementAmmount = 0.01f;

    private void Awake() {
        inst = this;
        menuSource = gameObject.GetComponent<AudioSource>();
        fadeOutComplete = true;
        menuSource.volume = 0;
    }

    public void StartPlayback() {
        if (inst.fadeInCompelete) { return; }
        StartCoroutine(inst.SettingToPlayback());
    }
    public bool StopPlayback() {
        if (inst.fadeOutComplete) {
            return false;
        }
        StartCoroutine(inst.SettingToCease());
        return true;
    }
    IEnumerator SettingToPlayback() {
        menuSource.clip = clipToPlay;
        menuSource.Play();
        while (menuSource.volume != 1) {
            yield return new WaitForSeconds(fadeInOutRate);
            menuSource.volume += fadeInVolIncrementAmmount;
        }
    }
    IEnumerator SettingToCease() {
        while (menuSource.volume != 0) {
            yield return new WaitForSeconds(fadeInOutRate);
            menuSource.volume -= fadeInVolIncrementAmmount;
            menuSource.Stop();
        }
    }
}
