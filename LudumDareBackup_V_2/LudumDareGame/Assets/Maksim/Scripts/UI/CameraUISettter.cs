using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class CameraUISettter {
    
	public static void LoadUI () {
        SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
    }
}
