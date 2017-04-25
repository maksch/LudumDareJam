using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
public class Movingcharacters : MonoBehaviour {

    public GameObject movingObj;
    private Rigidbody2D body2D;
    public float timeBeforeDirSwap = 1f;
    public float speed = 2f;
    public List<Vector2> directions = new List<Vector2>();
    private bool complete = true;
    private int Index = 0;
    private Vector3 origin;
    public bool reload = false;

    private void OnEnable() {
        origin = movingObj.transform.position;
        body2D = movingObj.GetComponent<Rigidbody2D>();
        body2D.gravityScale = 0;
    }
    private void Update() {
        body2D.velocity = Vector2.zero;
        if (complete) {
            Index++;
            if(Index > directions.Count -1) {
                Index = 0;
            }
            complete = false;
            StartCoroutine( Timer());

        }
        body2D.velocity = new Vector2(directions[Index].x, directions[Index].y) * speed;
    }
    private void OnDisable() {
        body2D.velocity = Vector2.zero;
        movingObj.transform.position = origin;
        complete = true;
    }

    private IEnumerator Timer() {
        yield return new WaitForSeconds(timeBeforeDirSwap);
        complete = true;
        if(reload == true) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    }
}
