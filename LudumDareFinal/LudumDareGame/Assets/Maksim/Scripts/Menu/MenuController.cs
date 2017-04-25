using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum menuState {
    title, 
    sceneSelect, 
    credits,
}

public class MenuController : MonoBehaviour {
    public static MenuController inst;
    public float titleLoadInTime = 0.1f;
    bool titlePhasedIn = false;
    menuState state = new menuState();
    public GameObject TitleObject, SelectObject, creditsObject;
    public Camera camera;

    private void Start() {
        inst = this;
        state = menuState.title;
        TitleObject.SetActive(true);
        SelectObject.SetActive(false);
        creditsObject.SetActive(false);
        StartCoroutine(TitlePhasedInCounter());
        MenuMusicControl.Instance.StartPlayback();
    }

    private void Update() {
        UpdateMenu();
    }

    IEnumerator TitlePhasedInCounter() {
        yield return new WaitForSeconds(titleLoadInTime);
        titlePhasedIn = true;
    }
    public static void SetToCredits() {
        inst.state = menuState.credits;
    }
    public static void SetToSelect() {
        inst.state = menuState.sceneSelect;
    }
    private void UpdateMenu() {
        switch (state) {
            case menuState.title: {
                    if (Input.anyKey && titlePhasedIn) {
                        state = menuState.sceneSelect;
                    }
                    break;
                }

            case menuState.sceneSelect: {
                    StartCoroutine(TitlePhasedInCounter());
                    TitleObject.SetActive(false);
                    SelectObject.SetActive(true);
                    break;
                }
            case menuState.credits: {
                    StartCoroutine(TitlePhasedInCounter());
                    TitleObject.SetActive(false);
                    SelectObject.SetActive(false);
                    creditsObject.SetActive(true);
                    break;
                }
        }
    }
}
