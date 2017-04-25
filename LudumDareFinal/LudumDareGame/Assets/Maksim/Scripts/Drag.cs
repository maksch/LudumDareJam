using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

    public static bool isDragging;
    public static int objID;

    GameObject objectSelected;
    float distance = 10;
    public AudioSource AudSrc;
    bool allowDragSound = true;
    void OnMouseDrag()
    {
        if (!TeamCounter.isGameOver && !ShrineHandler.gameWon)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;

            objID = GetInstanceID();
            if (allowDragSound)
            {
                AudSrc.Play();
                allowDragSound = false;
            }

        }
    }
    void OnMouseUp()
    {
        allowDragSound = true;
    }
	// Use this for initialization
	void Start () {
        AudSrc = GameObject.Find("DragPerson").gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    print("mouseclick");
        //    RaycastHit hit = new RaycastHit();
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit, 100.0f))
        //    {

        //        print("hitsomething");
        //        objectSelected = hit.transform.gameObject;
        //        objID = objectSelected.GetInstanceID();
        //    }
        //    isDragging = true;
        //}
        //else if (Input.GetMouseButton(0))
        //{
        //    Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        //    screenPoint.z = -10.0f; //distance of the plane from the camera
        //    Vector3 camPos = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        //    print(screenPoint);
        //    if(objectSelected != null)
        //    {
        //        objectSelected.transform.position = new Vector3(camPos.x, camPos.y, 0);

        //        //transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        //    }
        //    isDragging = true;
        //}
        //else
        //{
        //    objectSelected = null;
        //    objID = -100;
        //    isDragging = false;
        //}
	}
}
