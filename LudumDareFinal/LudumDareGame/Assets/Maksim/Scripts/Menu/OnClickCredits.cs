using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class OnClickCredits : MonoBehaviour {

    private void OnMouseDown() {
        MenuController.SetToCredits();
    }
}
