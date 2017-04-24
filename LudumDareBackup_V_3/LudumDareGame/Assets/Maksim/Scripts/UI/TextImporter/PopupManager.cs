using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Grinless.UI {
    public class PopupManager : MonoBehaviour {


        private static PopupManager popupManager;
        //Used to create easy reference to popupmanager. Makes calling methods easier.
        public static PopupManager instance {
            get {
                if (popupManager == null) {
                    GameObject objManager = new GameObject();
                    objManager.name = "Popup manager";
                    popupManager = objManager.AddComponent<PopupManager>();
                }
                return popupManager;
            }
            private set { popupManager = value; }
        }

        public List<string> dialougeLines = new List<string>();

        public static void ImportTextFile(TextAsset textFile) {
            string textStart = textFile.text;
            List<string> lines = new List<string>(0);
            lines.AddRange(textStart.Split("\n"[0]));
            popupManager.dialougeLines = lines;
        }

        //Call this to create new popup.
        public static void CreatePopup(Transform _transform, GameObject objToSpawn, float time) {
            GameObject textPopup;
            Text _text;

            //Check if we have a prefab.
            if (objToSpawn != null) {
                textPopup = (GameObject)Instantiate(objToSpawn);
            } else {
                textPopup = new GameObject();
            }

            textPopup.name = "--TextPopup--";

            popupManager.SetTransform(_transform, textPopup);
            if (!textPopup.GetComponent<Text>()) {
                _text = textPopup.AddComponent<Text>();
                _text.color = Color.white;
            } else { _text = textPopup.GetComponent<Text>(); }

            int rand = Randomiser();
            _text.text = popupManager.dialougeLines[rand];
            popupManager.ObjectCall(time, textPopup);
        }
        public void SetTransform(Transform trans, GameObject obj) {
            obj.transform.parent = trans;
            obj.transform.position = new Vector3(trans.position.x, trans.position.y, obj.transform.position.z);
        }
        public void ObjectCall(float time, GameObject obj) {
            StartCoroutine(Despawn(time, obj));
        }
        public static int Randomiser() {
            int random1 = Random.Range(1, popupManager.dialougeLines.Count - 1);
            if (random1 < 1) {
                random1 = 1;
            }
            return random1;
        }
        private IEnumerator Despawn(float time, GameObject obj) {
            yield return new WaitForSeconds(time);
            Destroy(obj);
            SettingsScript.SetInactive();
        }
    }
}