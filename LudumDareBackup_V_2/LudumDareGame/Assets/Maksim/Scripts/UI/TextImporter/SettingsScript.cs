using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour {

    private PopupManager popupManager;
    public static SettingsScript inst;

    public TextAsset asset;
    public GameObject objectToSpawn;
    public Transform spawnTrans;
    public float despawnTime = 7.0f;
    public Sprite redPlayer, bluePlayer, greenPlayer;
    public Image sprite1, sprite2;
    public GameObject panel;
    public Transform SpawnTrans {
        get { return spawnTrans; }
        set { spawnTrans = value; }
    }

    private void Awake() {
        inst = this;
        popupManager = PopupManager.instance;
        popupManager = null;
        panel.SetActive(false);
        sprite1.enabled = false;
        sprite2.enabled = false;
    }

    // Use this for initialization
    void Start () {
        PopupManager.ImportTextFile(asset);
    }
    void Spawn() {
        int ran = Random.Range(1, 3);
        Sprite selected = bluePlayer;
        switch (ran) {
            case 1: {
                    selected = redPlayer;
                    break;
                }
            case 2: {
                    selected = bluePlayer;
                    break;
                }
            case 3: {
                    selected = greenPlayer;
                    break;
                }
        }
        sprite1.sprite = selected;
        sprite2.sprite = selected;
        panel.SetActive(true);
        sprite1.enabled = true;
        sprite2.enabled = true;
        PopupManager.CreatePopup(spawnTrans, objectToSpawn, despawnTime);
    }

    public static void SetInactive() {
        
        inst.panel.SetActive(false);
        inst.sprite1.enabled = false;
        inst.sprite2.enabled = false;
    }
}
