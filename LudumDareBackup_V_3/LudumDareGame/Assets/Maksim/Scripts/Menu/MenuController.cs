using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum menuState {
    title, 
    sceneSelect, 
}

public class MenuController : MonoBehaviour {

    public string sceneToLoadName;
    public float titleLoadInTime = 0.1f;
    bool titlePhasedIn = false;
    menuState state = new menuState();
    public GameObject TitleObject, SelectObject;
    public GameObject option1, option2;
    public Camera camera;

    private void Start() {
        state = menuState.title;
        TitleObject.SetActive(true);
        SelectObject.SetActive(false);
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

    private void UpdateMenu() {
        switch (state) {
            case menuState.title: {
                    if (Input.anyKey && titlePhasedIn) {
                        state = menuState.sceneSelect;
                    }
                    break;
                }

            case menuState.sceneSelect: {
                    TitleObject.SetActive(false);
                    SelectObject.SetActive(true);
                    Debug.Log("OnSceneSelect");
                    break;
                }
        }
    }
}
