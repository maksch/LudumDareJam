using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickMenu : MonoBehaviour {

    public int levelID;
    bool load = false;
    private void Update() {
        if (load) {
            SceneManager.LoadScene(levelID);
        }
    }
    private void OnMouseDown() {
        load = MenuMusicControl.Instance.StopPlayback();
        load = true;
    }
}
